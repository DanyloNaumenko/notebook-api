using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.NoteDTO;

public class NoteDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationTime { get; set; }
}