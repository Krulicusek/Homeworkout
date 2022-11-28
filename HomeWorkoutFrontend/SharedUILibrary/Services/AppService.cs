using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedUILibrary.Interfaces;
using HomeWorkoutModels.Models;
using System.Net.Http.Json;

namespace SharedUILibrary.Services
{
    public class AppService : IAppService
    {

        private readonly HttpClient httpClient;
        public AppService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string> AuthenticateUser(LoginModel loginModel)
        {
            string returnStr = string.Empty;
         
            var serializedStr = JsonConvert.SerializeObject(loginModel);
            var response = await httpClient.PostAsync(APIs.AuthenticateUser, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }  

            return returnStr;
        }

        public async Task<(bool isSuccess, string errorMessage)> RegistgerUser(RegistrationModel registrationModel)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            var serializedStr = JsonConvert.SerializeObject(registrationModel);
            var response = await httpClient.PostAsync(APIs.RegistrationUser, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage= await response.Content.ReadAsStringAsync();            
                }

            return (isSuccess, errorMessage);
        }
    }
}
