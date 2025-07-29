using Notebook.Domain.Models;

namespace Notebook.Domain.Interfaces;

public interface IUserRepository
{
    public void Create(User user);
    public User? GetByLogin(string login);    
    public User? GetById(Guid id);
    public IEnumerable<User> GetAll();
    public bool Update(User newUser);
    public bool Delete(Guid id);
    public bool ExistsByLogin(string login);
    public bool ExistsById(Guid id);
}