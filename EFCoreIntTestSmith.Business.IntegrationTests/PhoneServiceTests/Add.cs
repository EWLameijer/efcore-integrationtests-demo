using Microsoft.EntityFrameworkCore;
using TestSupport.EfHelpers;

namespace EFCoreIntTestSmith.Business.IntegrationTests.PhoneServiceTests;

public class Add
{
    [Fact]
    public void Phone_should_not_be_added_if_brand_type_combo_already_in_database()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);
        Phone iPhone = new() { Brand = new Brand { Name = "Apple" }, Type = "iPhone 11" };

        // act
        Action shouldThrow = () => phoneService.Add(iPhone);

        // assert
        Assert.Throws<ArgumentException>(shouldThrow);
    }

    [Fact]
    public void Existing_brand_should_not_be_added()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);
        string brandName = "Apple";
        string typeName = "iPhone 13";
        Phone iPhone13 = new() { Brand = new Brand { Name = brandName }, Type = typeName };

        // act
        phoneService.Add(iPhone13);

        // assert
        int newBrandCount = phoneService.GetBrands().Count();
        Assert.Equal(5, newBrandCount);
        Assert.Equal(6, phoneService.Get().Count());
        Assert.NotNull(phoneService.GetByBrandAndType(brandName, typeName));

    }

    [Fact]
    public void Adding_phone_with_new_brand_creates_both_phone_and_brand()
    {
        // arrange
        DbContextOptions<DataContext> options = this.CreateUniqueClassOptions<DataContext>();
        using DataContext context = new(options);
        context.Database.EnsureClean();
        PhoneService phoneService = new(context);
        string brandName = "Pear";
        string typeName = "MePhone 1";
        Phone iPhone13 = new() { Brand = new Brand { Name = brandName }, Type = typeName };

        // act
        phoneService.Add(iPhone13);

        // assert
        int newBrandCount = phoneService.GetBrands().Count();
        Assert.Equal(6, newBrandCount);
        Assert.Equal(6, phoneService.Get().Count());
        Assert.NotNull(phoneService.GetByBrandAndType(brandName, typeName));
    }
}