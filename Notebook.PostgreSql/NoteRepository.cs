using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.PostgreSql;

public class NoteRepository : INoteRepository
{
    public void Create(Note note)
    {
        throw new NotImplementedException();
    }

    public Note? Get(Guid id, Guid userId)
    {
        throw new NotImplementedException();
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