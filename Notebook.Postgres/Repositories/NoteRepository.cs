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
        var sql = @"INSERT INTO notes (id, title, content, creationtime, userid)
                VALUES (@Id, @Title, @Content, @CreationTime, @UserId);";
            
        connection.Execute(sql, note);
    }

    public Note? Get(Guid noteId, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"select * from get_note(@id, @user_id);";
            
        var note = connection.QueryFirstOrDefault<Note>(sql, new { id = noteId, user_id = userId });
        return note;
    }

    public IEnumerable<Note> GetAll(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"select * from notes
                    where userid = @UserId";
        
        var notes = connection.Query<Note>(sql, new { UserId = userId });
        return notes;
    }

    public bool Update(Note note, Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"delete from notes
                    where id = @NoteId
                    and userid = @UserId"; 
        var result = connection.Execute(sql, new { NoteId = id, UserId = userId });
        return Convert.ToBoolean(result);
    }
}