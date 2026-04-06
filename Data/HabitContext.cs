
using HabitTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker.Data
{
    public class HabitContext: DbContext
    {
        public DbSet<Habit> Habits { get; set; } //this will fetch all seeded habits

        public HabitContext(DbContextOptions<HabitContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>().HasData(GetHabits());

        }

        private Habit[] GetHabits()
        {
            return new Habit[]
            {
                new Habit
                {
                    Id = 1,
                    Name = "Sleep",
                    Goal = "Sleep every day by 8pm and with 7.5+ horus of sleep."

                },

            };
                

        }

    }
}
