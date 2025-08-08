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
    private readonly ILogger<SessionService> _logger;
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ILogger<SessionService> logger, ISessionRepository sessionRepository)
    {
        _logger = logger;
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
        _logger.LogInformation($"Создана новая сессия для пользователя {userId} " +
                               $"с токеном {session.Token}.");

        return session;
    }

    public Session? GetSessionByToken(string token)
    {
        var session = _sessionRepository.GetByToken(token);

        if (session == null)
        {
            _logger.LogWarning("Сессия не найдена или неактивна: {Token}", token);
        }

        return session;
    }

    public void DeactivateAllForUser(Guid userId)
    {
        _sessionRepository.DeactivateAllByUserId(userId);
        _logger.LogInformation($"Сессии пользователя {userId} деактивированы");
    }
    
    public void DeactivateSessionByToken(string token)
    {
        _sessionRepository.DeactivateByToken(token);
        _logger.LogInformation("Сессия деактивирована: {Token}", token);
    }

    public IEnumerable<Session> GetAllSessionsForUser(Guid userId)
    {
        return _sessionRepository.GetAllForUser(userId);
    }

    public void DeactivateExpiredSessions()
    {
        _sessionRepository.DeactivateExpired();
        _logger.LogInformation("Все просроченные сессии деактивированы");
    }
}