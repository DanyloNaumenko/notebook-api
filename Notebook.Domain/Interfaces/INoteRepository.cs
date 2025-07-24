using Notebook.Domain.Models;

namespace Notebook.Domain.Interfaces;

public interface INoteRepository
{
    public void Create(Note note);
    public Note? Get(Guid id, Guid userId);
    public ICollection<Note> GetAll(Guid userId);
    public bool Update(Note note, Guid userId);
    public bool Delete(Guid id, Guid userId);
}