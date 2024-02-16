namespace DailyDog.Domain;

public class User
{
    public Guid Id { get; set; }

    public Guid HouseholdId { get; set; }

    public string Name { get; set; }

    public string Color { get; set; }
}
