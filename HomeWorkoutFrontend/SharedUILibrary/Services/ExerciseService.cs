using HomeWorkoutModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
