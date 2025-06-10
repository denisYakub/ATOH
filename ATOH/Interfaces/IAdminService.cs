using ATOH.Entities;
using ATOH.Entities.DTOs;

namespace ATOH.Interfaces
{
    public interface IAdminService
    {
        bool IsAdmin(Guid key);
        void Create(CreateUserRequest request);
        void Recover();
        User Get(string login);
        IEnumerable<User> GetActiveUsers();
        IEnumerable<User> GetOlderUsers(DateTime Date);
        void Delete(string login, bool soft);
        void UpdateField(UpdateUserFieldRequest request);
    }
}
