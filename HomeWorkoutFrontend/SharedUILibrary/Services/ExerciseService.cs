using HomeWorkoutModels.Models;
using System.Net.Http.Json;

namespace SharedUILibrary.Services
{
    public class ExerciseService
    {
        private readonly HttpClient httpClient;
        public List<ExerciseModel> GetExerciseModels()
        {
            List<ExerciseModel> exerciseModels= new List<ExerciseModel>();
            exerciseModels = httpClient.GetFromJsonAsync<List<ExerciseModel>>("api/ExerciseModel").Result;
            return exerciseModels;
        }
    }
}
