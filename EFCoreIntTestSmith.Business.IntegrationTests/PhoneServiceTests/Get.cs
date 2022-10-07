using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestSupport.Helpers;

namespace EFCoreIntTestSmith.Business.IntegrationTests.PhoneServiceTests;

public class Get
{
    [Fact]
    public void Get_should_return_existing_phone()
    {
        // arrange
        IConfigurationRoot config = AppSettings.GetConfiguration();
        string connectionString = config.GetConnectionString("UnitTestConnection");
        DbContextOptionsBuilder<DataContext> builder = new();
        builder.UseSqlServer(connectionString);
        using DataContext context = new(builder.Options);
        PhoneService phoneService = new(context);

        // act
        Phone phone = phoneService.Get(1)!;

        // assert
        Assert.Equal("P31", phone.Type);
        Assert.Equal("Huawee", phone.Type);
    }
}