using System.Data;
using System.Data.SqlClient;

namespace DailyDog.Persistence;

public class DapperDbConnection(IConfiguration configuration)
{
    public readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
