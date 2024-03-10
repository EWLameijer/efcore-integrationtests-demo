namespace EFCoreIntTestSmith.Business;

public class PhoneTag
{
    public long PhoneId { get; set; }
    public Phone Phone { get; set; } = null!;

    public long TagId { get; set; }

    public Tag Tag { get; set; } = null!;
}