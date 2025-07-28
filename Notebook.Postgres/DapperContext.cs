using System.Data;
using Notebook.Domain.Interfaces;
using Npgsql;

namespace Notebook.Postgres;

public class DapperContext : IDbContext 
{
    private readonly string _connectionString;
    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}