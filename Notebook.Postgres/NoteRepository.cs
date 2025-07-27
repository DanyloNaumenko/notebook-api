using System.Data;
using Dapper;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Postgres;

public class NoteRepository : INoteRepository
{
    private readonly IDbContext _dbContext;
    private IDbConnection _dbConnection;

    public NoteRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public void Create(Note note)
    {
        throw new NotImplementedException();
    }

    public Note? Get(Guid noteId, Guid userId)
    {
        using (_dbConnection = _dbContext.CreateConnection())
        {
            var sql = "select * from get_note(@id, @user_id);";
            
            var note = _dbConnection.QueryFirstOrDefault<Note>(sql, new { id = noteId, user_id = userId });
            return note;
        }
    }

    public ICollection<Note> GetAll(Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool Update(Note note, Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}