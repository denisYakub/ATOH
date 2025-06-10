using ATOH.DataBase.DbContexts;
using ATOH.DataBase.Repositories;
using ATOH.Entities;
using ATOH.Interfaces;
using ATOH.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IAdminService, AdminService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRepository<User>, PostgresRepository>();

builder.Services.AddControllers();

builder.Services
    .AddDbContext<PostgresDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
