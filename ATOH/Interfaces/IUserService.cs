using ATOH.Entities;
using ATOH.Entities.DTOs;

namespace ATOH.Interfaces
{
    public interface IUserService
    {
        bool IsUser(Guid key);
        User Get(string login, string password);
        void UpdateField(UpdateUserFieldRequest request);
    }
}
