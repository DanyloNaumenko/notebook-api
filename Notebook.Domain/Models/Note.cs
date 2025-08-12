namespace Notebook.Domain.Models;

public record Note
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Content { get; init; } = null!;
    public DateTime CreationTime { get; init; }
    public Guid UserId { get; init; }

    public bool IsActive { get; init; }
}