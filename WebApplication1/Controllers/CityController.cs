using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

[ApiController]
[Route("api/[controller]")]
public class CityController(CityService service) : ControllerBase
{
    
    [HttpGet("task1")]
    public async Task<IActionResult> Task1() => Ok(await service.GetPeopleInBigCities());

    [HttpGet("task2")]
    public async Task<IActionResult> Task2() => Ok(await service.GetPeopleCountInCities());

    [HttpGet("task3")]
    public async Task<IActionResult> Task3() => Ok(await service.GetCitiesAboveAverageInCountry());

    [HttpGet("task4")]
    public async Task<IActionResult> Task4() => Ok(await service.GetEmptyCities());

    [HttpGet("task5")]
    public async Task<IActionResult> Task5() => Ok(await service.GetBiggestCityInEachCountry());

    [HttpGet("task6")]
    public async Task<IActionResult> Task6() => Ok(await service.GetPeopleWithCityAndCountry());

    [HttpGet("task7")]
    public async Task<IActionResult> Task7() => Ok(await service.GetCitiesWithDilnoza());

    [HttpGet("task8")]
    public async Task<IActionResult> Task8() => Ok(await service.GetOldestPersonInEachCity());

    [HttpGet("task9/people/{cityName}")]
    public async Task<IActionResult> Task9People(string cityName) => Ok(await service.GetPeopleByCityName(cityName));

    [HttpGet("task9/youngest")]
    public async Task<IActionResult> Task9Youngest() => Ok(await service.GetYoungestPersonInEachCountry());

    [HttpGet("task10/{minAge}/{maxAge}")]
    public async Task<IActionResult> Task10(int minAge, int maxAge) => Ok(await service.GetCityWithMostPeopleInAgeRange(minAge, maxAge));
}