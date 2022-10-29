namespace HomeWorkoutModels.Models
{
    public class ExerciseModel
    {
        public int Id { get; set; }
        public DateTime CreationTime {get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int NumberOfTimes { get; set; }
        public bool IsChoosen { get; set; }
        public int Seconds { get; set; }
        public string ImageSource { get; set; }
        public ExerciseModel()
        {

        }
    }
}