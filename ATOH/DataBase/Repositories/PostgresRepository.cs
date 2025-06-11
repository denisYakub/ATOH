using ATOH.DataBase.DbContexts;
using ATOH.Entities;
using ATOH.Entities.Exceptions;
using ATOH.Interfaces;

namespace ATOH.DataBase.Repositories
{
    public class PostgresRepository(PostgresDbContext context) : IRepository<User>
    {
        public void Create(User user) =>
            context.Users.Add(user);

        public void CreateToken(Guid id) =>
            context.UserTokens.Add(new UserToken(id)); 

        public void Delete(User user) =>
            context.Users.Remove(user);

        public void DeleteToken(Guid id)
        {
            var token = 
                context
                .UserTokens
                .FirstOrDefault(t => t.UserGuid == id);

            if (token != null)
            {
                context.UserTokens.Remove(token);
            }
        }

        public User Get(string login, string password)
        {
            var user = 
                context
                .Users
                .FirstOrDefault(user => user.Login == login && user.Password == password);

            return user ?? throw new BadRequestException("Can not find user with this login and password");
        }

        public User Get(Guid token)
        {
            var user =
                context
                .Users
                .Join(
                    context.UserTokens,
                    user => user.Guid,
                    token => token.UserGuid,
                    (u, t) => new { User = u, Token = t })
                .FirstOrDefault(userToken => userToken.Token.Token == token);

            if (user == null) 
                throw new BadRequestException($"Can not find user with this token {token}");

            return user.User;
        }

        public User Get(string login)
        {
            var user =
                context
                .Users
                .FirstOrDefault(user => user.Login == login);

            return user ?? throw new BadRequestException("Can not find user with this login");
        }

        public IEnumerable<User> GetAllActive()
        {
            var users =
                context
                .Users
                .Where(user => user.RevokedBy == null);

            if (!users.Any())
                throw new BadRequestException("No active users");

            return users;
        }

        public IEnumerable<User> GetAllOlder(DateTime date)
        {
            var users =
                context
                .Users
                .Where(user => user.Birthday.HasValue && user.Birthday < date);

            if (!users.Any())
                throw new BadRequestException($"No users older then {date}");

            return users;
        }

        public Guid GetToken(Guid id)
        {
            var token = 
                context
                .UserTokens
                .FirstOrDefault(token => token.UserGuid == id);

            if (token == null)
                throw new BadRequestException($"No token for user with id {id}");

            return token.Token;
        }

        public bool IsAdminToken(Guid token)
        {
            var it = 
                context
                .AdminTokens
                .FirstOrDefault(item => item.Token == token);

            if (it == null)
                return false;

            return true;
        }

        public bool IsLoginUnique(string login)
        {
            var sameLogin = 
                context
                .Users
                .FirstOrDefault (user => user.Login == login);

            if (sameLogin == null)
                return true;

            return false;
        }

        public void SaveChanges() =>
            context.SaveChanges();

        public void Update(User user) =>
            context.Update(user);
    }
}
