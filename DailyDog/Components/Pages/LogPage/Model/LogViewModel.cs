using DailyDog.Domain;

namespace DailyDog.Components.Pages.LogPage.Model;

public class LogViewModel
{
    public Household Household { get; set; }

    public List<Activity> Activities { get; set; }

    public List<Dog> Dogs { get; set; }

    public DogOwner DogOwner { get; set; }

    public List<Log> Logs { get; set; }
}
