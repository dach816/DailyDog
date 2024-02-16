namespace DailyDog.Domain;

public class DogOwner
{
    public Guid Id { get; set; }

    public Guid HouseholdId { get; set; }

    public string Name { get; set; }

    public string Color { get; set; }
}
