namespace EFCoreIntTestSmith.Business;

public class Tag
{
    public long Id { get; set; }

    public string Description { get; set; } = null!;

    public ICollection<PhoneTag> Phones { get; set; }
}