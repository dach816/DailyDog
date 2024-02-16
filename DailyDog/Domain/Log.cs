namespace DailyDog.Domain;

public class Log
{
    public Guid Id { get; set; }

    public Guid DogOwnerId { get; set; }

    public Guid DogId { get; set; }

    public Guid ActivityId { get; set; }

    public DateTime TimestampUtc { get; set; }

    public DateTime TimestampCurrentTimezone => TimestampUtc.ToLocalTime();
}
