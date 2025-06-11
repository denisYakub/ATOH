using ATOH.Entities;
using ATOH.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ATOH.Interfaces
{
    public interface IUserService
    {
        void UpdateField(Guid token, UpdateUserFieldRequest request);
        JsonResult GetUser(string login, string password);
    }
}
