using TaskManagement.Server.Data;
using TaskManagement.Server.Interface;
using TaskManagement.Server.Models;

namespace TaskManagement.Server.Services
{
    public class UserRegistrationService :IUserRegistrationService
    {
        private readonly DBContextClass _context;

        public UserRegistrationService(DBContextClass context)
        {
            _context = context;
        }

        public UserRegistrationModel GetRegisteredUserByEmail(string userEmail)
        {
            return _context.UserRegistrations.FirstOrDefault(y => y.Name == userEmail);
        }
        public async Task RegisterUser(string userEmail)
        {
            var user = GetRegisteredUserByEmail(userEmail);
            if (user == null)
            {
                UserRegistrationModel entity = new UserRegistrationModel()
                {
                    Name = userEmail,
                    RegistrationDate = DateTime.Now,
                };
                _context.UserRegistrations.Add(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
