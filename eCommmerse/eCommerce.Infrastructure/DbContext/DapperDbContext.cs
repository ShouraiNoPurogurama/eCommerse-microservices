using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString = configuration.GetConnectionString("PostgresDb");

        DbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection { get; }
}