namespace Notebook.Domain.Models;

public record User
{
    public Guid Id { get; init; }
    public string Login { get; init; } = null!;
    public string PasswordHash { get; init; } = null!;
    public ICollection<Note> Notes { get; init; } = new List<Note>();
}