using Dapper;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Postgres.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly IDbContext _dbContext;

    public SessionRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public void Create(Session session)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"INSERT INTO sessions(id, user_id, token, created_at, expires_at, is_active)
                    VALUES (@Id, @UserId, @Token, @CreatedAt, @ExpiresAt, @IsActive);";
        
        connection.Execute(sql, session);
    }

    public Session? GetById(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT * FROM sessions WHERE id = @Id AND is_active = true;";
        return connection.QueryFirstOrDefault<Session>(sql, new { Id = id });
    }

    public Session? GetByToken(string token)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"SELECT * FROM sessions 
                    WHERE token = @Token AND is_active = true AND expires_at > now();";
        return connection.QueryFirstOrDefault<Session>(sql, new { Token = token });
    }

    public IEnumerable<Session> GetAllForUser(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT * FROM sessions WHERE user_id = @UserId AND is_active = true;";
        return connection.Query<Session>(sql, new { UserId = userId });
    }

    public void DeactivateById(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "UPDATE sessions SET is_active = false WHERE id = @Id;";
        connection.Execute(sql, new { Id = id });
    }
    public void DeactivateAllByUserId(Guid id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "UPDATE sessions SET is_active = false WHERE user_id = @Id;";
        connection.Execute(sql, new { Id = id });
    }

    public void DeactivateByToken(string token)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "UPDATE sessions SET is_active = false WHERE token = @Token;";
        connection.Execute(sql, new { Token = token });
    }

    public void DeactivateExpired()
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "UPDATE sessions SET is_active = false WHERE expires_at <= now() AND is_active = true;";
        connection.Execute(sql);
    }
}
