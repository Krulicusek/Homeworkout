using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedUILibrary.Interfaces;
using HomeWorkoutModels.Models;

namespace SharedUILibrary.Services
{
    public class AppService : IAppService
    {
        private string _baseUrl = "https://localhost:7057";
        public async Task<string> AuthenticateUser(LoginModel loginModel)
        {
            string returnStr = string.Empty;
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.AuthenticateUser}";

                var serializedStr = JsonConvert.SerializeObject(loginModel);
                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }
            }
            return returnStr;
        }

        public async Task<(bool isSuccess, string errorMessage)> RegistgerUser(RegistrationModel registrationModel)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.RegistrationUser}";

                var serializedStr = JsonConvert.SerializeObject(registrationModel);
                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage= await response.Content.ReadAsStringAsync();            
                }
            }
            return (isSuccess, errorMessage);
        }
    }
}
