using Microsoft.Extensions.Logging;
using Notebook.Application.DTOs.NoteDTO;
using Notebook.Application.Interfaces;
using Notebook.Domain.Interfaces.Repositories;

namespace Notebook.Application.Services;

public class NoteService : INoteService
{

    private INoteRepository _noteRepository;
    private ILogger<NoteService> _logger;
    public NoteService(INoteRepository noteRepository ,ILogger<NoteService> logger)
    {
        _noteRepository = noteRepository;
        _logger = logger;
    }
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
