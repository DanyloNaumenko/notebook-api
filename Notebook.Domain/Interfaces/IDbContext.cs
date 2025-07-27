using System.Data;

namespace Notebook.Domain.Interfaces;

public interface IDbContext
{
    public IDbConnection CreateConnection();
}