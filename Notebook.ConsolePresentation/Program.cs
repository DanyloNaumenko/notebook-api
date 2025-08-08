// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Notebook.Application.DTOs.NoteDTO;
using Notebook.Application.DTOs.UserDTO;
using Notebook.Application.Services;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;
using Notebook.Postgres;
using Notebook.Postgres.Repositories;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<INoteRepository, NoteRepository>();
serviceCollection.AddScoped<NoteService>();
serviceCollection.AddScoped<UserService>();
serviceCollection.AddScoped<IUserRepository, UserRepository>();
serviceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
serviceCollection.AddScoped<SessionService>();
serviceCollection.AddScoped<ISessionRepository, SessionRepository>();
serviceCollection.AddLogging(config =>
{
    config.AddConsole(); // вывод в консоль
    config.SetMinimumLevel(LogLevel.Information); // можно выбрать Debug, Trace, etc.
});
serviceCollection.AddScoped<IDbContext, DapperContext>(provider =>
{
    var connectionString = configuration.GetConnectionString("Postgres");
    return new DapperContext(connectionString!);
});


Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var provider = serviceCollection.BuildServiceProvider();

var noteService = provider.GetService<NoteService>();
var userService = provider.GetService<UserService>();
var sessionService = provider.GetService<SessionService>();


