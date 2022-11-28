using HomeWorkoutModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
        public HomeworkSequenceModel GetHomeworkSequence(int id)
        {
            HomeworkSequenceModel homeworkSequenceModel = new HomeworkSequenceModel();
            homeworkSequenceModel = httpClient.GetFromJsonAsync<HomeworkSequenceModel>($"/ExerciseModels/{id}").Result;
            return homeworkSequenceModel;
        }
    }
}
