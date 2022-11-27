using HomeWorkoutModels.Models;

namespace SharedUILibrary.Interfaces
{
    public interface IAppService
    {
        Task<string> AuthenticateUser(LoginModel loginModel);
        Task<(bool isSuccess, string errorMessage)> RegistgerUser(RegistrationModel registrationModel);
    }
}
