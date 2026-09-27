using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memo.Models;

namespace Memo.ViewModels;

public partial class GameViewModel : BaseViewModel
{
    private readonly Random _random = new();

    private PeriodicTimer? _timer;
    private CancellationTokenSource? _timerCancellation;

    private DateTime _startTime;

    private Card? _firstSelected;
    private Card? _secondSelected;

    private int _matchedPairs;

    [ObservableProperty]
    private DifficultyLevel? level;

    [ObservableProperty]
    private TimeSpan elapsed;

    [ObservableProperty]
    private int attempts;

    [ObservableProperty]
    private bool gameFinished;

    [ObservableProperty]
    private bool canSelectCards = true;

    public ObservableCollection<Card> Cards { get; } = new();

    public string DifficultyText =>
        Level switch
        {
            DifficultyLevel.Easy => "Łatwy",
            DifficultyLevel.Medium => "Średni",
            DifficultyLevel.Hard => "Trudny",
            _ => string.Empty
        };
    [ObservableProperty]
    public string timeText;
    [ObservableProperty]
    public string attemptsText;
    [ObservableProperty]
    public string resultTimeText;
    [ObservableProperty]
    public string resultAttemptsText;

    public void InitializeGame(DifficultyLevel difficulty)
    {
        StopTimer();

        Level = difficulty;

        Cards.Clear();

        _firstSelected = null;
        _secondSelected = null;
        _matchedPairs = 0;

        Attempts = 0;
        Elapsed = TimeSpan.Zero;

        GameFinished = false;
        CanSelectCards = true;

        InitializeCards(difficulty);

        StartTimer();
    }

    private void InitializeCards(DifficultyLevel difficulty)
    {
        Cards.Clear();

        int numberOfPairs = difficulty switch
        {
            DifficultyLevel.Easy => 4,
            DifficultyLevel.Medium => 6,
            DifficultyLevel.Hard => 8,
            _ => 4
        };

        var cards = new List<Card>();

        for (int i = 0; i < numberOfPairs; i++)
        {
            string imageName = $"card_{i + 1}.png";

            cards.Add(
                new Card(
                    i,
                    imageName,
                    CardSelectedAsync));

            cards.Add(
                new Card(
                    i,
                    imageName,
                    CardSelectedAsync));
        }

        // Losowanie kart.
        foreach (var card in cards.OrderBy(_ => _random.Next()))
        {
            Cards.Add(card);
        }
    }

    private void StartTimer()
    {
        _timerCancellation?.Cancel();
        _timer?.Dispose();

        _timerCancellation = new CancellationTokenSource();

        _timer = new PeriodicTimer(
            TimeSpan.FromSeconds(1));

        _startTime = DateTime.Now;

        _ = TimerLoopAsync(
            _timerCancellation.Token);
    }

    private async Task TimerLoopAsync(
        CancellationToken cancellationToken)
    {
        if (_timer is null)
            return;

        try
        {
            while (
                !GameFinished &&
                await _timer.WaitForNextTickAsync(
                    cancellationToken))
            {
                if (!GameFinished)
                {
                    Elapsed =
                        DateTime.Now - _startTime;
                    TimeText =$"{Elapsed.Minutes:00}:{Elapsed.Seconds:00}";
                }
            }
        }
        catch (OperationCanceledException)
        {}
    }

    public async Task CardSelectedAsync(Card card)
    {
        if (GameFinished)
            return;

        if (!CanSelectCards)
            return;

        if (card.IsMatched)
            return;

        if (_firstSelected is null)
        {
            _firstSelected = card;
            return;
        }

        if (_firstSelected == card)
            return;

        _secondSelected = card;
        CanSelectCards = false;
        Attempts++;
        await Task.Delay(1000);

        if (_firstSelected.PairId ==
            _secondSelected.PairId)
        {
            _firstSelected.IsMatched = true;
            _secondSelected.IsMatched = true;

            _matchedPairs++;
        }
        else
        {
            _firstSelected.IsSelected = false;
            _secondSelected.IsSelected = false;
        }

        _firstSelected = null;
        _secondSelected = null;

        CanSelectCards = true;

        if (_matchedPairs == Cards.Count / 2)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        GameFinished = true;
        CanSelectCards = false;

        TimeText =
        $"{Elapsed.Minutes:00}:{Elapsed.Seconds:00}";

        AttemptsText =
        $"Próby: {Attempts}";

        ResultTimeText =
        $"Czas: {Elapsed.Minutes:00}:{Elapsed.Seconds:00}";

        ResultAttemptsText =
        $"Liczba prób: {Attempts}";

        StopTimer();

    }

    private void StopTimer()
    {
        _timerCancellation?.Cancel();

        _timerCancellation?.Dispose();
        _timerCancellation = null;

        _timer?.Dispose();
        _timer = null;
    }

    [RelayCommand]
    private async Task RestartAsync()
    {
        if (!Level.HasValue)
            return;

        InitializeGame(Level.Value);

        await Task.CompletedTask;
    }

    [RelayCommand]
    private async Task BackToMenuAsync()
    {
        StopTimer();

        await Shell.Current.GoToAsync("..");
    }

    public void Dispose()
    {
        StopTimer();
    }
}
