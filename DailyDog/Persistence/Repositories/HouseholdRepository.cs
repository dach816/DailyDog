using DailyDog.Domain;
using Dapper;
using System.Data;

namespace DailyDog.Persistence.Repositories;

public class HouseholdRepository(DapperDbConnection dapperDbConnection)
{
    public async Task<IEnumerable<Household>> GetAllHouseholdsAsync()
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        return await db.QueryAsync<Household>("SELECT * FROM Household");
    }
}
