using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkoutModels.Models
{
    public class HomeworkSequenceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EstimatedTimeInMinutes { get; set; }
        public ICollection<HomeworkModel> HomeworkICollection { get; set; }
        
    }
}
