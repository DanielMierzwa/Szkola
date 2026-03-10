using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using to_do.View;
using to_do.Models;//tutaj jest import TaskObject i TaskGroup

namespace to_do.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {



        public List<TaskObject> TaskObjects { get; } = new List<TaskObject>();//lista wszystkich zadań
        public ObservableCollection<TaskGroup> TaskGroups { get; } = new ObservableCollection<TaskGroup>();//zadania podzielone na grupy
        [ObservableProperty]
        string title = "TO DO list";

        public MainViewModel() 
        {
        }

        [RelayCommand]
        private async Task OpenPopUp()
        {
            var popup = new PopUpPage();
            var result = await Application.Current.MainPage.ShowPopupAsync<string>(popup);//tu też trzeba podać typ zwracany przez popup
            if (result != null)
            {
                if (result.Result != null)
                    TaskObjects.Add(new TaskObject { Name = result.Result });

            }
            RefreshTasks();

        }
        private void RefreshTasks()
        {
            var done = new List<TaskObject>();
            var undone = new List<TaskObject>();
            foreach (var taskObject in TaskObjects)//segrerguje taski na zrobione i nie zrobione
            {
                if (taskObject.IsDone == true)
                {
                    done.Add(taskObject);
                }
                else
                {
                    undone.Add(taskObject);
                }
            }
            TaskGroups.Clear();
            if(undone.Count>0)
            TaskGroups.Add(new TaskGroup("Do zrobienia",undone));
            if(done.Count>0)
            TaskGroups.Add(new TaskGroup("Zrobione", done));
        }
        //funkcje do obsługi guzików do każdego zadania
        [RelayCommand]
        private void SetDone(TaskObject task)
        {
            task.Reverse();
            RefreshTasks();
        }
        [RelayCommand]
        private void Delete(TaskObject task)
        {
            TaskObjects.Remove(task);
            RefreshTasks();
        }

        [RelayCommand]
        async void Edit(TaskObject task)
        {
            var popup = new PopUpPage(task);
            var result = await Application.Current.MainPage.ShowPopupAsync<string>(popup);//tu też trzeba podać typ zwracany przez popup
            if (result != null)
            {
                if(result.Result!=null)
                {
                    TaskObjects.Add(new TaskObject { Name = result.Result , IsDone=task.IsDone});
                    TaskObjects.Remove(task);
                }
                
                    



            }
            RefreshTasks();
        }

    }
}
