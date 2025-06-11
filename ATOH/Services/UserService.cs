using ATOH.Entities;
using ATOH.Entities.DTOs;
using ATOH.Entities.Exceptions;
using ATOH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATOH.Services
{
    public class UserService(IRepository<User> repository) : IUserService
    {
        public JsonResult GetUser(string login, string password)
        {
            var user = repository.Get(login, password);

            var token = repository.GetToken(user.Guid);

            return new JsonResult(new {UserInfo = user, Token = token});
        }

        public void UpdateField(Guid token, UpdateUserFieldRequest request)
        {
            if (request.Field == Entities.Enums.FieldsToUpdate.Login)
                if (!repository.IsLoginUnique(request.NewValue))
                    throw new BadRequestException($"Login {request.NewValue} is not unique");

            User user = repository.Get(token);

            user.UpdateField(request.Field, request.NewValue);

            repository.Update(user);
            repository.SaveChanges();
        }
    }
}
