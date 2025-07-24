using Notebook.Application.DTOs.NoteDTO;
using Notebook.Application.Interfaces;

namespace Notebook.Application.Services;

public class NoteService : INoteService
{
    public NoteDto Create(CreateNoteDto createNoteDto, Guid userId)
    {
        throw new NotImplementedException();
    }

    public ICollection<NoteDto> GetAll(Guid userId)
    {
        throw new NotImplementedException();
    }

    public NoteDto? GetById(Guid noteId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool Update(Guid noteId, UpdateNoteDto updateNoteDto, Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid noteId, Guid userId)
    {
        throw new NotImplementedException();
    }
}