using System.Diagnostics.CodeAnalysis;

namespace EFCoreIntTestSmith.Business;

[ExcludeFromCodeCoverage]
public class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;
}