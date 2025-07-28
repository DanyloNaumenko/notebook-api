using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.NoteDTO;


public class UpdateNoteDto
{
    public string? Title { get; set; } = null!;
    
    public string? Content { get; set; } = null!;
    
}