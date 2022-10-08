using Microsoft.EntityFrameworkCore;
using TestSupport.EfHelpers;

namespace EFCoreIntTestSmith.Business.IntegrationTests.PhoneServiceTests;
public class Delete
{
    [Fact]
    public void Deleting_a_phone_with_unique_brand_should_delete_both_phone_and_brand()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);

        // act
        phoneService.Delete(3);

        // assert
        int newBrandCount = phoneService.GetBrands().Count();
        Assert.Equal(4, newBrandCount);
        Assert.Equal(4, phoneService.Get().Count());
    }

    [Fact]
    public void Deleting_a_non_existing_phone_should_throw_an_error()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);

        // act
        Action invalidDeletion = () => phoneService.Delete(6);

        // assert
        Assert.Throws<InvalidOperationException>(invalidDeletion);
        int newBrandCount = phoneService.GetBrands().Count();
        Assert.Equal(5, newBrandCount);
        Assert.Equal(5, phoneService.Get().Count());
    }

    [Fact]
    public void Deleting_a_phone_should_not_delete_the_brand_if_used_by_another_phone()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);
        phoneService.Add(new() { Type = "iPhone 13", Brand = new Brand { Name = "Apple" } });

        // act
        phoneService.Delete(3);

        // assert
        int newBrandCount = phoneService.GetBrands().Count();
        Assert.Equal(5, newBrandCount);
        Assert.Equal(5, phoneService.Get().Count());
    }
}
