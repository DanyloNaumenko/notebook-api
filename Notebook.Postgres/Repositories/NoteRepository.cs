using Dapper;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Postgres.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly IDbContext _dbContext;

    public NoteRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public void Create(Note note)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"INSERT INTO notes (id, title, content, creation_time, user_id)
                VALUES (@Id, @Title, @Content, @CreationTime, @UserId);";
            
        connection.Execute(sql, note);
    }

    public Note? Get(Guid noteId, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"select * from notes where id = @Id and user_id = @UserId and is_active = true;";
            
        var note = connection.QueryFirstOrDefault<Note>(sql, new { Id = noteId, UserId = userId });
        return note;
    }

    public IEnumerable<Note> GetAll(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"select * from notes
                    where user_id = @UserId";
        
        var notes = connection.Query<Note>(sql, new { UserId = userId });
        return notes;
    }

    public bool Update(Note note, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        var updateSql = @"UPDATE notes
                            SET title = @Title,               
                            content = @Content,             
                            creation_time = @CreationTime,
                            is_active = @IsActive
                            WHERE id = @Id AND user_id = @UserId;";
        
        var result = connection.Execute(updateSql, note);
        return Convert.ToBoolean(result);
    }


    public bool Delete(Guid id, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"UPDATE notes
                    set  is_active = false
                    where id = @NoteId
                    and user_id = @UserId"; 
        var result = connection.Execute(sql, new { NoteId = id, UserId = userId });
        return Convert.ToBoolean(result);
    }
}