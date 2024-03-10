using System.Diagnostics.CodeAnalysis;

namespace EFCoreIntTestSmith.Business;

[ExcludeFromCodeCoverage]
public class Phone
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public Brand Brand { get; set; } = null!;

    public int BrandId { get; set; }

    public override string ToString()
    {
        Console.WriteLine($"Number of tags: {Tags.Count}");
        return $"{Brand.Name} {Type} ({Price}) {string.Join(",", Tags.Select(t => t.Description))}";
    }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public ICollection<Tag> Tags { get; set; } = [];
}