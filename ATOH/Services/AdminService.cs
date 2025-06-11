using ATOH.Entities;
using ATOH.Entities.DTOs;
using ATOH.Entities.Exceptions;
using ATOH.Interfaces;

namespace ATOH.Services
{
    public class AdminService(IRepository<User> repository) : IAdminService
    {
        public void CreateUser(Guid token, CreateUserRequest request)
        {
            var admin = repository.Get(token);

            if (!admin.Admin)
                throw new UnAuthException("Only admins can create users");

            if (!repository.IsLoginUnique(request.Login))
                throw new BadRequestException($"Login {request.Login} is not unique");

            var newUser = 
                new User(
                    request.Login, request.Password, 
                    request.Name, request.Gender, 
                    request.Birthday, 
                    request.Admin,
                    admin.Login
                );

            repository.Create(newUser);
            repository.CreateToken(newUser.Guid);
            repository.SaveChanges();
        }

        public void DeleteUser(Guid token, string login, bool soft)
        {
            var admin = repository.Get(token);

            if (!admin.Admin)
                throw new UnAuthException("Only admins can delete users");

            var user = repository.Get(login);

            if (soft)
            {
                user.SoftDelete(admin.Login);

                repository.Update(user);
            }
            else
            {
                repository.Delete(user);
            }

            repository.DeleteToken(user.Guid);

            repository.SaveChanges();
        }

        public IEnumerable<User> GetActiveUsers(Guid token)
        {
            if (!repository.IsAdminToken(token))
                throw new UnAuthException("Only admins can read users");

            return repository.GetAllActive();
        }

        public IEnumerable<User> GetOlderUsers(Guid token, DateTime date)
        {
            if (!repository.IsAdminToken(token))
                throw new UnAuthException("Only admins can read users");

            return repository.GetAllOlder(date);
        }

        public User GetUser(Guid token, string login)
        {
            if (!repository.IsAdminToken(token))
                throw new UnAuthException("Only admins can read users");

            return repository.Get(login);
        }

        public void RecoverUser(Guid token)
        {
            if (!repository.IsAdminToken(token))
                throw new UnAuthException("Only admins can recover users");

            throw new NotImplementedException();
        }
    }
}
