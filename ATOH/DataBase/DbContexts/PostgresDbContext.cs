using ATOH.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATOH.DataBase.DbContexts
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) 
        : DbContext(options)
    {
        public DbSet<User> Users { get; init; }
        public DbSet<AdminKey> AdminKeys { get; init; }
        public DbSet<UserKey> UserKeys { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
