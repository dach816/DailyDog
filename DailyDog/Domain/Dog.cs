namespace DailyDog.Domain;

public class Dog
{
    public Guid Id { get; set; }

    public Guid HouseholdId { get; set; }

    public string Name { get; set; }
}
