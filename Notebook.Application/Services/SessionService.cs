using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Notebook.Application.Interfaces;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;
using Notebook.Postgres.Repositories;

namespace Notebook.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public Session CreateSession(Guid userId, TimeSpan duration)
    {
        var session = new Session
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Token = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.Add(duration),
            IsActive = true
        };

        _sessionRepository.Create(session);
        return session;
    }

    public Session? GetSessionByToken(string token)
    {
        var session = _sessionRepository.GetByToken(token);
        
        return session;
    }

    public void DeactivateAllForUser(Guid userId)
    {
        _sessionRepository.DeactivateAllByUserId(userId);
    }
    
    public void DeactivateSessionByToken(string token)
    {
        _sessionRepository.DeactivateByToken(token);
    }

    public void DeactivateExpiredSessions()
    {
        _sessionRepository.DeactivateExpired();
    }

    public Session? GetCurrentUserSession(Guid userId)
    {
        return _sessionRepository.GetCurrentUserSession(userId);
    }
}