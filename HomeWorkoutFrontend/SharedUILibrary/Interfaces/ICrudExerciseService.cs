using HomeWorkoutModels.Models;

namespace SharedUILibrary.Interfaces
{
    public interface ICrudExerciseService
    {
        Task<bool> EditAsync(ExerciseModel exerciseModel);
    }
}
