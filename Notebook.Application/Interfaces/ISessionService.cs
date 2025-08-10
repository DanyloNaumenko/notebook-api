using Notebook.Domain.Models;

namespace Notebook.Application.Interfaces;

public interface ISessionService
{
    Session CreateSession(Guid userId, TimeSpan duration);
    Session? GetSessionByToken(string token);
    Session? GetCurrentUserSession(Guid userId);
    void DeactivateAllForUser(Guid userId);
    void DeactivateSessionByToken(string token);
    void DeactivateExpiredSessions();
}

