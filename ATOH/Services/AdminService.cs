using ATOH.Entities;
using ATOH.Entities.DTOs;
using ATOH.Interfaces;

namespace ATOH.Services
{
    public class AdminService(IRepository<User> repository) : IAdminService
    {
        public void Create(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(string login, bool soft)
        {
            throw new NotImplementedException();
        }

        public User Get(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetOlderUsers(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public bool IsAdmin(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Recover()
        {
            throw new NotImplementedException();
        }

        public void UpdateField(UpdateUserFieldRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
