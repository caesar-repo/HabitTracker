using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitTracker.Data;
using HabitTracker.Models;
using HabitTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HabitTracker.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        public readonly ICRUD _habitService;
        Habit newhabit = new Habit();

        [ObservableProperty]
        Habit selectedHabit;


        [ObservableProperty]
        string text; // name of text box for habit

        
        public ObservableCollection<Habit> Items { get; set; } = new ObservableCollection<Habit>(); //collection of habits

        public MainViewModel(ICRUD habitService)
        {
            _habitService = habitService;
            LoadHabits();
           
        }
        [RelayCommand]
        public async void AddHabit()
        {
            if(string.IsNullOrEmpty(Text))
            {
                await App.Current.MainPage.DisplayAlertAsync("Error", "No habit input here","OK");
                return;
            }

            var newHabit = new Habit { Name = Text, Goal = "" };
            _habitService.AddHabit(newHabit);   // saves to DB
            Items.Add(newHabit);                // updates UI
            Text = string.Empty;
        }


        [RelayCommand]
        public void DeleteHabit()
        {
            if (SelectedHabit == null) return;

            _habitService.DeleteHabit(SelectedHabit);
            Items.Remove(SelectedHabit);
            SelectedHabit = null;

        }

        [RelayCommand]
        public void UpdateHabit()
        {
            if (selectedHabit == null)
                return;

            selectedHabit.Name = Text;
            _habitService.UpdateHabit(selectedHabit);

            var index = Items.IndexOf(selectedHabit);
            Items[index] = selectedHabit;

            Text = string.Empty;
            selectedHabit = null;


        }
        private void LoadHabits()
        {
            var habits = _habitService.GetHabits();
            Items.Clear();
            foreach (var habit in habits)
                Items.Add(habit);
        }



        [RelayCommand]
        async Task Tap(Habit habbit)
        {
            selectedHabit = habbit;
            Text = habbit.Name;
        }

    }
}
