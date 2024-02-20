using DailyDog.Domain;
using Dapper;
using System.Data;

namespace DailyDog.Persistence.Repositories;

public class LogRepository(DapperDbConnection dapperDbConnection)
{
    public async Task<IEnumerable<Log>> GetLogsByHouseholdIdAsync(Guid householdId)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = @"
            SELECT
                l.Id,
                l.DogOwnerId,
                l.DogId,
                l.ActivityId,
                l.TimestampUtc
            FROM Log l
                JOIN DogOwner o ON l.DogOwnerId = o.Id
            WHERE o.HouseholdId = @HouseholdId
            GROUP BY
                l.Id,
                l.DogOwnerId,
                l.DogId,
                l.ActivityId,
                l.TimestampUtc";
        return await db.QueryAsync<Log>(query, new { HouseholdId = householdId });
    }

    public async Task CreateLogAsync(Log Log)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = @"
            INSERT INTO Log (Id, DogOwnerId, DogId, ActivityId, TimestampUtc)
                VALUES (@Id, @DogOwnerId, @DogId, @ActivityId, @TimestampUtc)";
        await db.ExecuteAsync(query, Log);
    }

    public async Task UpdateLogAsync(Log Log)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = @"
            UPDATE Log
                SET Id = @Id, 
                SET DogOwnerId = @DogOwnerId, 
                SET DogId = @DogId, 
                SET ActivityId = @ActivityId, 
                SET TimestampUtc = @TimestampUtc, 
            WHERE Id = @Id";
        await db.ExecuteAsync(query, Log);
    }

    public async Task DeleteLogAsync(int id)
    {
        using IDbConnection db = dapperDbConnection.CreateConnection();
        const string query = "DELETE FROM Log WHERE Id = @Id";
        await db.ExecuteAsync(query, new { Id = id });
    }
}
