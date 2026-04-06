using HabitTracker.Data;
using HabitTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker.Services
{
    public class HabitService: ICRUD
    {
        private HabitContext HabitContext;

        public HabitService(HabitContext habitContext)
        {
            HabitContext = habitContext;
        }

        public void AddHabit(Habit habit)
        {
            HabitContext.Habits.Add(habit);
            HabitContext.SaveChanges();
        }

        public void DeleteHabit(Habit habit)
        {
            HabitContext.Habits.Remove(habit);
            HabitContext.SaveChanges();
        }

        public Habit GetHabitByID(int id)
        {
            return HabitContext.Habits.Find(id);
        }

        public List<Habit> GetHabits()
        {
            return HabitContext.Habits.ToList();
        }

        public void UpdateHabit(Habit habit)
        {
            HabitContext.Habits.Update(habit);
            HabitContext.SaveChanges();
        }

    }
}
