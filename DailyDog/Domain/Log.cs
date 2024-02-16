namespace DailyDog.Domain;

public class Log
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid DogId { get; set; }

    public Guid ActivityId { get; set; }

    public DateTime Timestamp { get; set; }
}
