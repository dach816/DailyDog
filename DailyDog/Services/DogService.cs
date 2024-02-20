using DailyDog.Domain;
using DailyDog.Persistence.Repositories;

namespace DailyDog.Services;

public class DogService(
    DogRepository dogRepo,
    DogOwnerRepository dogOwnerRepo,
    ActivityRepository activityRepo,
    HouseholdRepository householdRepo)
{
    public async Task<List<Dog>> GetDogsAsync(Guid householdId)
    {
        return (await dogRepo.GetDogsByHouseholdIdAsync(householdId)).ToList();
    }

    public async Task<DogOwner> GetDogOwnerAsync(Guid householdId)
    {
        return (await dogOwnerRepo.GetDogOwnersByHouseholdIdAsync(householdId)).First();
    }

    public async Task<List<Activity>> GetActivitiesAsync(Guid householdId)
    {
        return (await activityRepo.GetActivitiesByHouseholdIdAsync(householdId)).ToList();
    }

    public async Task<Household> GetHouseholdAsync()
    {
        return (await householdRepo.GetAllHouseholdsAsync()).First();
    }
}
