using Notebook.Domain.Models;

namespace Notebook.Domain.Interfaces;

public interface ISessionRepository
{
    void Create(Session session);
    Session? GetById(Guid id);
    Session? GetByToken(string token);
    IEnumerable<Session> GetAllForUser(Guid userId);
    void DeactivateById(Guid id);
    void DeactivateAllByUserId(Guid id);
    void DeactivateByToken(string token);
    void DeactivateExpired();
}