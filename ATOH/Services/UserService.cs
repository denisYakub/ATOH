using ATOH.Entities;
using ATOH.Entities.DTOs;
using ATOH.Interfaces;

namespace ATOH.Services
{
    public class UserService(IRepository<User> repository) : IUserService
    {
        public User Get(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUser(Guid key)
        {
            throw new NotImplementedException();
        }

        public void UpdateField(UpdateUserFieldRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
