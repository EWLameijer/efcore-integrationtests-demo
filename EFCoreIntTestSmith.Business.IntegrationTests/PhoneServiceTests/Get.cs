using Microsoft.EntityFrameworkCore;
using TestSupport.EfHelpers;

namespace EFCoreIntTestSmith.Business.IntegrationTests.PhoneServiceTests;

public class Get
{
    [Fact]
    public void Get_should_return_existing_phone()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);

        // act
        Phone phone = phoneService.Get(1)!;

        // assert
        Assert.Equal("P30", phone.Type);
        Assert.Equal("Huawei", phone.Brand.Name);
    }
}