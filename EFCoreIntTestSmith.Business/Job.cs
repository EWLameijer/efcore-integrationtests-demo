using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreIntTestSmith.Business;

public class Job
{
    public long Id { get; set; }

    public string Description { get; set; }

    [ForeignKey("CustomerId")]
    public User Customer { get; set; }

    [ForeignKey("EmployeeId")]
    public User Employee { get; set; }

    public long CustomerId { get; set; }
    public long EmployeeId { get; set; }
}