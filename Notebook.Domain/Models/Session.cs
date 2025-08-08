namespace Notebook.Domain.Models;

public record Session
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Token { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
    public bool IsActive { get; init; }
}