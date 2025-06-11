using ATOH.DataBase.DbContexts;
using ATOH.Entities;

namespace ATOH.DataBase.Inits
{
    public static class DbInitializer
    {
        public static void SeedInitialUser(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();

            if (!context.Users.Any())
            {
                var user = new User(
                    login: "admin",
                    password: "admin123",
                    name: "Initial Admin",
                    gender: 0,
                    birthday: null,
                    admin: true,
                    createBy: "system"
                );
                var token = new UserToken(user.Guid);

                context.Users.Add(user);
                context.UserTokens.Add(token);

                context.SaveChanges();
            }
        }
    }
}
