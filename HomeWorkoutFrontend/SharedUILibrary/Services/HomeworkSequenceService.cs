using HomeWorkoutModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharedUILibrary.Services
{
    public class HomeworkSequenceService
    {
        private readonly HttpClient httpClient;
        public HomeworkSequenceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HomeworkSequenceModel> GetHomeworkSequenceByUserId(string userId)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<HomeworkSequenceModel>($"{APIs.GetSequenceModelByUserId}/{userId}");
                return response;
            }
            catch
            {

            }
            return null;

        }
        public void AddHomeworkSequence(HomeworkSequenceModel homeworkSequence)
        {
            httpClient.PostAsJsonAsync<HomeworkSequenceModel>($"{APIs.AddSequenceModel}", homeworkSequence);
        }
    }
}
