using Notebook.Domain.Models;

namespace Notebook.Domain.Interfaces;

public interface IUserRepository
{
    public void Create(User user);
    public User? GetByLogin(string login);    
    public User? GetById(Guid id);
    public ICollection<User> GetAll();
    public bool Update(User newUser, Guid id);
    public bool Delete(Guid id);
}