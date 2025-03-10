using TaskManagement.Server.Models;

namespace TaskManagement.Server.Interface
{
    public interface IUserRegistrationService
    {
        Task RegisterUser(string userId);
        UserRegistrationModel GetRegisteredUserByEmail(string userEmail);

    }
}
