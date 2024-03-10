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
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
context.SaveChanges();
context.SeedForDeveloper();
PhoneService phoneService = new(context);
for (int i = 1; i <= 4; i++)
{
    Phone? phone = phoneService.Get(i);
    Console.WriteLine(phone);
}
Console.WriteLine("End program!");
Console.ReadLine();

// Okay. So the big problem is that the many-to-many-relationship,
// while present in memory, is not persisted

// How to address that?
// 1. 15 min: try traditional many-to-many
//      Round 1
// 2. 15 min: Read EF Core book to gain better understanding
// 3. If Failing with the traditional many-to-many, consult Mark!