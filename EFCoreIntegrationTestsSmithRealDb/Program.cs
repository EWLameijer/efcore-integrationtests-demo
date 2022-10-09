// integration tests
// EF Core
// real database
// method: Smith

// See https://aka.ms/new-console-template for more information
using EFCoreIntTestSmith.Business;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Start program!");
const string ConnectionString = "Data Source=(localdb)\\ProjectModels;" +
        "Initial Catalog=EFCoreIntegrationTest;Integrated Security=True;Connect Timeout=30;" +
        "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
        "MultiSubnetFailover=False";

DbContextOptionsBuilder<DataContext> builder = new();
builder.UseSqlServer(ConnectionString);
DbContextOptions<DataContext> options = builder.Options;
DataContext context = new(options);

// below code to ensure development database is updated after a migration
//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();
//context.SaveChanges();
//context.SeedForDeveloper();
PhoneService phoneService = new(context);
Phone? phone = phoneService.Get(4);
Console.WriteLine(phone);
Console.WriteLine("End program!");