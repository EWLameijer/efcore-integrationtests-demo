using EFCoreIntTestSmith.Business;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreIntegrationTests.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private PhoneService _phoneService;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(PhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Phone> Get() =>
        Enumerable.Range(1, 5).Select(index => _phoneService.Get(index)!);
}