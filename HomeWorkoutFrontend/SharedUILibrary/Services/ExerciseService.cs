using HomeWorkoutModels.Models;
using System.Net.Http.Json;

namespace SharedUILibrary.Services
{
    public class ExerciseService
    {
        private readonly HttpClient httpClient;
        public ExerciseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<ExerciseModel> GetExerciseModels()
        {
            List<ExerciseModel> exerciseModels = new List<ExerciseModel>();
            exerciseModels = httpClient.GetFromJsonAsync<List<ExerciseModel>>("/ExerciseModels").Result;
            return exerciseModels;
        }
        public ExerciseModel GetExerciseModel(int id)
        {
            ExerciseModel exercise = httpClient.GetFromJsonAsync<ExerciseModel>($"ExerciseModels/{id}").Result;
            return exercise;
        }
    }
}
