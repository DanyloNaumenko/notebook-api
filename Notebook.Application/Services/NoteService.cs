using Microsoft.Extensions.Logging;
using Notebook.Application.DTOs.NoteDTO;
using Notebook.Application.Interfaces;
using Notebook.Domain.Interfaces.Repositories;
using Notebook.Domain.Models;

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
        var note = new Note
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = createNoteDto.Title,
            Content = createNoteDto.Content,
            CreationTime = DateTime.Now,
        };
        
        _noteRepository.Create(note);
        
        var noteDto = new NoteDto
        {
            Id = note.Id,
            Title = note.Title, 
            Content = note.Content,
            CreationTime = note.CreationTime,
        };
        return noteDto;
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
