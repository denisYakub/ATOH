using ATOH.Entities;
using ATOH.Entities.DTOs;

namespace ATOH.Interfaces
{
    public interface IAdminService
    {
        void CreateUser(Guid token, CreateUserRequest request);
        void RecoverUser(Guid token);
        IEnumerable<User> GetActiveUsers(Guid token);
        User GetUser(Guid token, string login);
        IEnumerable<User> GetOlderUsers(Guid token, DateTime date);
        void DeleteUser(Guid token, string login, bool soft);
    }
}
