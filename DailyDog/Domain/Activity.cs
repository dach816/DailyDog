namespace DailyDog.Domain;

public class Activity
{
    public Guid Id { get; set; }

    public Guid? HouseholdId { get; set; }

    public string Text { get; set; }

    public string Emoji { get; set; }
}
