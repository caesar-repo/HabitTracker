using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HabitTracker.Models
{
    public class Habit
    {
        [Key]
        public int Id { get; set; } // GET FETCH
        public string Name { get; set; } // Name of the habit (e.g., "Exercise")
        public string Goal { get; set; }  // Description 

    }
}
