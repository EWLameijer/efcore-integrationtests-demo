using Microsoft.EntityFrameworkCore;

namespace EFCoreIntTestSmith.Business;

public class DataContext : DbContext
{
    public DbSet<Brand> Brands { get; set; } = null!;

    public DbSet<Phone> Phones { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Brand huawei = new() { Id = 1, Name = "Huawei" };
        Brand samsung = new() { Id = 2, Name = "Samsung" };
        Brand apple = new() { Id = 3, Name = "Apple" };
        Brand google = new() { Id = 4, Name = "Google" };
        Brand xiaomi = new() { Id = 5, Name = "Xiaomi" };

        modelBuilder.Entity<Brand>().HasData(huawei, samsung, apple, google, xiaomi);

        Phone p30 = new() { Id = 1, BrandId = huawei.Id, Type = "P30" };
        Phone galaxy = new() { Id = 2, BrandId = samsung.Id, Type = "Galaxy A52" };
        Phone iPhone = new() { Id = 3, BrandId = apple.Id, Type = "iPhone 11" };
        Phone pixel = new() { Id = 4, BrandId = google.Id, Type = "Pixel 4a" };
        Phone redmi = new() { Id = 5, BrandId = xiaomi.Id, Type = "Redmi Note 10 Pro" };

        modelBuilder.Entity<Phone>().HasData(p30, galaxy, iPhone, pixel, redmi);
    }
}