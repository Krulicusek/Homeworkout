using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HomeWorkoutModels.Models
{
    public class HomeworkModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    
        public int PlaceInSequence { get; set; }
        public int NumberOfTimes { get; set; }
        public int Seconds { get; set; }

        [ForeignKey("ExerciseModel")]
        public int ExerciseModelId { get; set; }
    }
}
