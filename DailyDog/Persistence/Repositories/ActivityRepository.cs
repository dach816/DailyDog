using DailyDog.Domain;
using Dapper;
using System.Data;

namespace DailyDog.Persistence.Repositories;

public class ActivityRepository(DapperDbConnection dapperDbConnection)
{
    public async Task<IEnumerable<Activity>> GetActivitiesByHouseholdIdAsync(Guid householdId)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = @"
            SELECT * FROM Activity
            WHERE HouseholdId = @HouseholdId OR HouseholdId IS NULL";
        return await db.QueryAsync<Activity>(query, new { HouseholdId = householdId });
    }
}
