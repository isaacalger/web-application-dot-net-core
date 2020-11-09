using WebApplication.Server.DTOModels;

namespace WebApplication.Server.Services.RegistrationService
{
    public interface IRegistrationService
    {
        void RegisterUser(RegisterUserAccountDto model);

        void SendRegistrationEmail(string email);
    }
}
