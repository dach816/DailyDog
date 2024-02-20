using DailyDog.Domain;
using Dapper;
using System.Data;

namespace DailyDog.Persistence.Repositories;

public class DogRepository(DapperDbConnection dapperDbConnection)
{
    public async Task<IEnumerable<Dog>> GetDogsByHouseholdIdAsync(Guid householdId)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = "SELECT * FROM Dog WHERE HouseholdId = @HouseholdId";
        return await db.QueryAsync<Dog>(query, new { HouseholdId = householdId });
    }
}
