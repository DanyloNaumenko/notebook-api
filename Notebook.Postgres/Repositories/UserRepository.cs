using System.Data;
using Dapper;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Postgres.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;
    public UserRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public void Create(User user)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"INSERT INTO users (id, login, passwordHash)
                VALUES (@Id, @Login, @PasswordHash);";
            
        connection.Execute(sql, user);
    }

    public User? GetByLogin(string login)
    {
        using var connection = _dbContext.CreateConnection();
        
        var sql = @"SELECT * FROM users WHERE login = @Login;";
        
        var user = connection.QueryFirstOrDefault<User>(sql, new { Login = login });
        return user;
    }

    public User? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(User newUser, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool ExistsByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public bool ExistsById(Guid id)
    {
        throw new NotImplementedException();
    }
}