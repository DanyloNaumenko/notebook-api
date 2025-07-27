using System.Data;
using Notebook.Domain.Interfaces;
using Npgsql;

namespace Notebook.PostgreSql;

public class DapperContext : IDbContext
{
    private NpgsqlConnection _connection;
    public DapperContext(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    
    public IDbConnection CreateConnection()
    {
        _connection.Open();
        return _connection;
    }
}