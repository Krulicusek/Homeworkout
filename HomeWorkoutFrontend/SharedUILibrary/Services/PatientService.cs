using HomeWorkoutModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SharedUILibrary.Services
{
    public class PatientService
    {
        private readonly HttpClient httpClient;
        public PatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<UserBasicDetail> GetPhysiotherapists()
        {
           return httpClient.GetFromJsonAsync<List<UserBasicDetail>>($"/Patient/GetPhysiotherapists").Result;
        }
        public  List<UserBasicDetail> GetPatients(string physioId)
        {
            try
            {
                var response =  httpClient.GetFromJsonAsync<List<UserBasicDetail>>($"/Patient/GetPatients/{physioId}").Result;
                return response;
            }
            catch { }
            return null;
        }
    }
}
