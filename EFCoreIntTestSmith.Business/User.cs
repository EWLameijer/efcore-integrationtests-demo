namespace EFCoreIntTestSmith.Business;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Job> Jobs { get; set; }
}