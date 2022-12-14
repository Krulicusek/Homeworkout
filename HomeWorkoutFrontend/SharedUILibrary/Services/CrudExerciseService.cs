using HomeWorkoutModels.Models;
using SharedUILibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SharedUILibrary.Services
{
    public class CrudExerciseService : ICrudExerciseService
    {
        private readonly HttpClient httpClient;
        public CrudExerciseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        async Task<bool> ICrudExerciseService.EditAsync(ExerciseModel exerciseModel)
        {
            var result = await httpClient.PutAsJsonAsync(APIs.BaseUrl + APIs.EditExerciseModel + $"/{exerciseModel.Id}", exerciseModel);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
