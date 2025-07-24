using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.NoteDTO;

public class CreateNoteDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;
    
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = null!;
}