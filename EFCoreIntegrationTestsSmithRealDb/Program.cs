// integration tests
// EF Core
// real database
// method: Smith

// DONE phase 1: create a database
// DONE phase 2: let EF Core create the tables (mini-Phoneshop)
//      1. Installed Microsoft.EntityFrameworkCore.SqlServer
//      2. Install other package(s?)
// DONE phase 3: seed data (look at student examples)
//      DONE 2. Seed phone data
// phase 4: use primitive functionality in Program, and make Business-logic to match
//      *1. Create PhoneService
//      *1b. Make Git repo for this project
//      *2. Create Get(id)
//      *3. Test Get (Console)
//      *3a. seed test database
//      4. tot p537:17.5.2 Study Smith WHOLE CHAPTER (making notes + drawing relationships on paper then CmapTools)
//      5. Test Get (Full Db)

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
PhoneService phoneService = new(new DataContext(options));
Phone? phone = phoneService.Get(4);
Console.WriteLine(phone);
Console.WriteLine("End program!");