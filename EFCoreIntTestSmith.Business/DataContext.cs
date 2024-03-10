using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EFCoreIntTestSmith.Business;

[ExcludeFromCodeCoverage]
public class DataContext : DbContext
{
    public DbSet<Brand> Brands { get; set; } = null!;

    public DbSet<Phone> Phones { get; set; } = null!;

    public DbSet<Tag> Tags { get; set; } = null!;

    public DbSet<PhoneTag> PhoneTags { get; set; } = null!;

    public DataContext()
    { }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            const string ConnectionString = "Data Source=(localdb)\\ProjectModels;" +
            "Initial Catalog=EFCoreIntegrationTest;Integrated Security=True;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().Property(x => x.Price).HasPrecision(9, 2);
        modelBuilder.Entity<PhoneTag>().HasKey(pt => new { pt.PhoneId, pt.TagId });
        modelBuilder.Entity<PhoneTag>().HasOne(p => p.Phone).WithMany(p => p.Tags).HasForeignKey(pt => pt.PhoneId);
        modelBuilder.Entity<PhoneTag>().HasOne(p => p.Tag).WithMany(p => p.Phones).HasForeignKey(pt => pt.TagId);
        modelBuilder.Entity<Phone>().Navigation(p => p.Tags).AutoInclude();
        modelBuilder.Entity<PhoneTag>().Navigation(pt => pt.Tag).AutoInclude();
    }
}