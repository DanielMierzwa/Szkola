using System.Net.Http.Json;

using CollectionsChat.Client.Data;
using CollectionsChat.Shared.Collections;
using CollectionsChat.Shared.Collections.Interfaces;
using CollectionsChat.Shared.Models;

namespace CollectionsChat.Client.Services
{
    /// <summary>
    /// Dostarcza współdzielone kolekcje dla komponentów (wiadomości, użytkownicy, logi).
    /// </summary>
    public class DataProvider
    {
        //todo: Wpisz tutaj otrzymane dane logowania
        private const string USERNAME = "danielm";
        private const string PASSWORD = "Dnm18243";

        private readonly JwtAuthenticationStateProvider _authProvider;
        private readonly HttpClient _httpClient;
        private bool _loggedIn;

        public string CurrentUserName { get; private set; } = "Anonim";

        public DataProvider(JwtAuthenticationStateProvider authProvider, HttpClient httpClient)
        {
            _authProvider = authProvider;
            _httpClient = httpClient;
        }

        #region Metody do uzupełnienia - to jest Twoje zadanie :)

        //todo: Stwórz klasy dla poniższych interfejsów kolekcji oraz wykorzystaj je tutaj.

        public ISmartLinkedList<ChatMessage> Messages { get; }  = new SmartLinkedList<ChatMessage>();
        public ISmartLinkedList<ChatUser> ActiveUsers { get; }  = new SmartLinkedList<ChatUser>();
        public ISmartCircularCollection<SystemLog> Logs { get; }  = new SmartCircularCollection<SystemLog>(10);

        //todo: Wywołuj odpowiednie zdarzenia po zaistnieniu opisanych zmian
        public event Action? MessagesChanged; // <-- kiedy zmienią się wiadomości
        public event Action? ActiveUsersChanged; // <-- kiedy zmienią się aktywni użytkownicy
        public event Action? LogsChanged; // <-- kiedy dodana zostanie nowa pozycja do logów

        public async Task LoadHistoryAsync(IChatGateway gateway)
        {
            //Ta metoda jest w zasadzie gotowa - nic nie musisz zmieniać. Jest tutaj tylko dla kontekstu.
            var history = await gateway.GetHistoryAsync(); // <-- To jest operacja asynchroniczna, nie przejmuj się na razie tym 'await'
            ReplaceMessages(history);
        }

        public void ReplaceMessages(IEnumerable<ChatMessage> messages)
        {
            //todo: Zaimplementuj tę metodę tak, aby zastąpić wszystkie wiadomości nowymi i wywołać odpowiednie zdarzenie.
            Messages.Clear();
            foreach (var message in messages)
            {
                Messages.AddLast(message);
            }
            MessagesChanged?.Invoke();
        }

        public void HandleMessageReceived(ChatMessage message)
        {
            //todo: Dodaj wiadomość do odpowiedniej kolekcji i wywołaj adekwatne zdarzenie.
            Messages.AddLast(message);
            MessagesChanged?.Invoke();
        }

        public void HandleActiveUsersChanged(IEnumerable<ChatUser> users)
        {
            //todo: Zastąp użytkowników w odpowiedniej kolekcji (wszystkich) i wywołaj odpowiadające temu zdarzenie.
            ActiveUsers.Clear();
            foreach (var user in users)
            {
                ActiveUsers.AddLast(user);
            }
            ActiveUsersChanged?.Invoke();
        }

        public void HandleSystemLog(string log, Severity severity = Severity.Info)
        {
            var systemLog = new SystemLog(DateTime.Now, log, severity);

            //todo: Dodaj log do odpowiedniej kolekcji i wywołaj adekwatne zdarzenie.
            Logs.Add(systemLog);
            LogsChanged?.Invoke();
        }

        #endregion

        #region Zarządzenie połączeniem SignalR i inne - tego nie musisz edytować :)

        public async Task EnsureLoggedInAsync()
        {
            if (_loggedIn)
            {
                return;
            }

            if (_authProvider is JwtAuthenticationStateProvider jwtProvider)
            {
                var existing = await jwtProvider.GetTokenAsync();
                if (string.IsNullOrWhiteSpace(existing))
                {
                    try
                    {
                        var response = await _httpClient.PostAsJsonAsync("/api/auth/login", new LoginRequest
                        {
                            Login = USERNAME,
                            Password = PASSWORD
                        });
                        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                        if (result?.IsSuccess == true && !string.IsNullOrWhiteSpace(result.Token))
                        {
                            await jwtProvider.SetTokenAsync(result.Token);
                        }
                        else
                        {
                            HandleSystemLog(result?.ErrorMessage ?? "Nie udało się zalogować automatycznie.", Severity.Danger);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleSystemLog($"Błąd logowania: {ex.Message}", Severity.Danger);
                    }
                }
            }

            await RefreshCurrentUserNameAsync();
            _loggedIn = true;
        }

        public async Task RefreshCurrentUserNameAsync()
        {
            var state = await _authProvider.GetAuthenticationStateAsync();
            CurrentUserName = state.User.Identity?.Name ?? "Anonim";
        }

        public async Task SendMessageAsync(IChatGateway gateway, string html, string? imageBase64)
        {
            await EnsureLoggedInAsync();
            await gateway.SendMessageAsync(CurrentUserName, html, imageBase64);
        }

        public async Task EnsureConnectedAsync(IChatGateway gateway)
        {
            await EnsureLoggedInAsync();
            await gateway.EnsureConnectedAsync();
        }

        public IReadOnlyCollection<ChatMessage> GetMessagesSnapshot() => Messages.ToList();
        public IReadOnlyCollection<ChatUser> GetActiveUsersSnapshot() => ActiveUsers.ToList();
        public IReadOnlyCollection<SystemLog> GetLogsSnapshot() => Logs.ToList();

        #endregion
    }
}
