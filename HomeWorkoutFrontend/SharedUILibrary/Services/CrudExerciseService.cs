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

        public async Task<bool> AddAsync(ExerciseModel exerciseModel)
        {
            var result = await httpClient.PostAsJsonAsync(APIs.BaseUrl + APIs.AddExerciseModel, exerciseModel);
            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await httpClient.DeleteAsync(APIs.BaseUrl + APIs.DeleteExerciseModel + $"/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
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
