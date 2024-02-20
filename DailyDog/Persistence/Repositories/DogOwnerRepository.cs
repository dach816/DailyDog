using DailyDog.Domain;
using Dapper;
using System.Data;

namespace DailyDog.Persistence.Repositories;

public class DogOwnerRepository(DapperDbConnection dapperDbConnection)
{
    public async Task<IEnumerable<DogOwner>> GetDogOwnersByHouseholdIdAsync(Guid householdId)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = "SELECT * FROM DogOwner WHERE HouseholdId = @HouseholdId";
        return await db.QueryAsync<DogOwner>(query, new { HouseholdId = householdId });
    }
}
