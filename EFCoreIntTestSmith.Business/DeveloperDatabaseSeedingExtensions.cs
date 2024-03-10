using System.Diagnostics.CodeAnalysis;

namespace EFCoreIntTestSmith.Business;

[ExcludeFromCodeCoverage]
public static class DeveloperDatabaseSeedingExtensions
{
    public static void SeedForDeveloper(this DataContext context)
    {
        Brand huawei = new() { Name = "Huawei" };
        Brand samsung = new() { Name = "Samsung" };
        Brand apple = new() { Name = "Apple" };
        Brand google = new() { Name = "Google" };
        Brand xiaomi = new() { Name = "Xiaomi" };

        Tag cool = new() { Description = "cool" };
        Tag hot = new() { Description = "hot" };
        context.Add(cool);
        context.Add(hot);

        Phone p30 = new()
        {
            Brand = huawei,
            Type = "P30",
            Price = 100M,
            Stock = 20,
            Tags = [cool, hot]
        };
        Phone galaxy = new()
        {
            Brand = samsung,
            Type = "Galaxy A52",
            Price = 200M,
            Stock = 25,
            Tags = [cool]
        };
        Phone iPhone = new()
        {
            Brand = apple,
            Type = "iPhone 11",
            Price = 500M,
            Stock = 0,
            Tags = [hot]
        };
        Phone pixel = new()
        {
            Brand = google,
            Type = "Pixel 4a",
            Price = 400M,
            Stock = 15
        };
        Phone redmi = new()
        {
            Brand = xiaomi,
            Type = "Redmi Note 10 Pro",
            Price = 300M,
            Stock = 3
        };

        List<Phone> phones = [p30, galaxy, iPhone, pixel, redmi];
        context.AddRange(phones);
        context.SaveChanges();

        //context.Tags.
        context.ChangeTracker.Clear();
    }
}