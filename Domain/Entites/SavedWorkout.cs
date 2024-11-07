using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class SavedWorkout
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public DateTime SavedDate { get; set; }
        public string Notes { get; set; }

        public User User { get; set; }
        public WorkOut Workout { get; set; }
    }

}
