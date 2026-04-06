using HabitTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker.Services
{
    public interface ICRUD
    {
        void AddHabit(Habit habit);
        List<Habit> GetHabits();
        Habit GetHabitByID(int id);
        void UpdateHabit(Habit habit);

        void DeleteHabit(Habit habit);
    }
}
