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
//      4. Study Smith WHOLE CHAPTER (making notes + drawing relationships on paper then CmapTools)
//      5. Test Get (Full Db)


// See https://aka.ms/new-console-template for more information
using EFCoreIntTestSmith.Business;

Console.WriteLine("Start program!");
PhoneService phoneService = new PhoneService(new DataContext());
Phone? phone = phoneService.Get(3);
Console.WriteLine(phone);
Console.WriteLine("End program!");
