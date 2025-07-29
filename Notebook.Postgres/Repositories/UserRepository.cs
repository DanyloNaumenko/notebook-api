using System.Data;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Postgres.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;
    public UserRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public void Create(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public User? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(User newUser, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool ExistsByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public bool ExistsById(Guid id)
    {
        throw new NotImplementedException();
    }
}