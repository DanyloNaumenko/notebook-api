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
        var sql = @"INSERT INTO users (id, login, password_hash)
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
        using var connection = _dbContext.CreateConnection();
        var sql = @"SELECT * FROM users WHERE id = @Id;";
        var user = connection.QueryFirstOrDefault<User>(sql, new { Id = id });
        return user;
    }

    public IEnumerable<User> GetAll()
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"SELECT * FROM users;";
        var users = connection.Query<User>(sql);
        return users;
    }

    public bool Update(User newUser)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"UPDATE users
                    set login = @Login,
                    password_hash = @PasswordHash
                    WHERE id = @Id;";
        var result = connection.Execute(sql, newUser);
        return Convert.ToBoolean(result);
    }

    public bool Delete(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var sqlToDeleteNotes = @"DELETE FROM notes WHERE user_id = @Id;";
        connection.Execute(sqlToDeleteNotes, new { Id = id });
        var sql = @"DELETE FROM users WHERE id = @Id;";
        var result = connection.Execute(sql, new { Id = id });
        return Convert.ToBoolean(result);
    }

    public bool ExistsByLogin(string login)
    {
        var user = GetByLogin(login);
        return user != null;
    }

    public bool ExistsById(Guid id)
    {
        var user = GetById(id);
        return user != null;
    }
}