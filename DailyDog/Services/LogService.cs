﻿using DailyDog.Domain;
using DailyDog.Persistence.Repositories;

namespace DailyDog.Services;

public class LogService(LogRepository logRepo)
{
    public async Task AddLogAsync(Activity activity, List<Dog> dogs, DogOwner dogOwner)
    {
        foreach (var dog in dogs)
        {
            var log = new Log
            {
                Id = Guid.NewGuid(),
                ActivityId = activity.Id,
                DogId = dog.Id,
                DogOwnerId = dogOwner.Id,
                TimestampUtc = DateTime.UtcNow
            };
            await logRepo.CreateLogAsync(log);
        }
    }

    public async Task<List<Log>> GetLogsAsync(Guid householdId)
    {
        return (await logRepo.GetLogsByHouseholdIdAsync(householdId)).ToList();
    }
}
