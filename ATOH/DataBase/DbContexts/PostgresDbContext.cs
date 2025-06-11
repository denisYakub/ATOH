using ATOH.DataBase.Views;
using ATOH.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATOH.DataBase.DbContexts
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) 
        : DbContext(options)
    {
        public DbSet<User> Users { get; init; }
        public DbSet<UserToken> UserTokens { get; init; }
        public DbSet<AdminTokenView> AdminTokens { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AdminTokenView>(pc =>
            {
                pc.HasNoKey();
                pc.ToView("view_admin_tokens");
            });
        }
    }
}
