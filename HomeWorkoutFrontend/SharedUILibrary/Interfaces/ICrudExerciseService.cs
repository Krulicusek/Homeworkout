using HomeWorkoutModels.Models;

namespace SharedUILibrary.Interfaces
{
    public interface ICrudExerciseService
    {
        Task<bool> EditAsync(ExerciseModel exerciseModel);
        Task<bool> DeleteAsync(int id);
        Task<bool> AddAsync(ExerciseModel exerciseModel);
    }
}
