using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkoutModels.Models
{
    public class ExerciseSequenceModel
    {
        [Key]
        public int Id { get; set; } 
        public int EstimatedTimeInMinutes { get; set; }
        public ICollection<ExerciseModel> Exercises { get; set; }
        
    }
}
