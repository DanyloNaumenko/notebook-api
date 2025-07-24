using Notebook.Domain.Models;

namespace Notebook.Domain.Interfaces.Repositories;

public interface INoteRepository
{
    public bool Create(Note note);
    public Note? Get(Guid id, Guid userId);
    public bool Update(Note note, Guid userId);
    public bool Delete(Guid id, Guid userId);
}