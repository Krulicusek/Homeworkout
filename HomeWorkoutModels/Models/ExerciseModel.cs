using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkoutModels.Models
{
    public class ExerciseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int NumberOfTimes { get; set; }
        public int Seconds { get; set; }
        public string ImageSource { get; set; }
        public  ExerciseSequenceModel Sequence { get; set; }
        public ExerciseModel()
        {

        }
    }
}