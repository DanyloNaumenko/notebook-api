using Notebook.Application.DTOs.NoteDTO;
using Notebook.Domain.Models;

namespace Notebook.Application.Interfaces;

public interface INoteService
{
    public NoteDto Create(CreateNoteDto createNoteDto, Guid userId);
    public ICollection<NoteDto> GetAll(Guid userId);
    public NoteDto? GetById(Guid noteId, Guid userId);
    public bool Update(Guid noteId, UpdateNoteDto updateNoteDto, Guid userId);
    public bool Delete(Guid noteId, Guid userId);
}