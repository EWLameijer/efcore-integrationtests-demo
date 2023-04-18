namespace EFCoreIntTestSmith.Business;

public class Job
{
    public long Id { get; set; }

    public string Description { get; set; }

    public User Customer { get; set; }
    public User Employee { get; set; }
}