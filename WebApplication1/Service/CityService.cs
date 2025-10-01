using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.DataContext;
using WebApplication1.Data.Entities;

namespace WebApplication1.Service;

public class CityService(AppDbContext context) : ICityService
{
  
    // Task 2: Количество людей в каждом городе
    public async Task<List<Person>> GetPeopleInBigCities()
    {
        return await context.People
            .Where(p => p.City.Population > 3_000_000)
            .ToListAsync();
    }
    

    public async Task<List<object>> GetPeopleCountInCities()
    {
        return await context.Cities
            .Select(c => new
            {
                City = c.Name,
                Count = c.People.Count
            })
            .ToListAsync<object>();
    }

    // Task 3: Города, где население > среднего по стране
    public async Task<List<City>> GetCitiesAboveAverageInCountry()
    {
        return await context.Cities
            .Where(c =>
                c.Population >
                context.Cities
                    .Where(x => x.CountryId == c.CountryId)
                    .Average(x => x.Population)
            )
            .ToListAsync();
    }

    // Task 4: Города без людей
    public async Task<List<City>> GetEmptyCities()
    {
        return await context.Cities
            .Where(c => !c.People.Any())
            .ToListAsync();
    }

    // Task 5: Города с макс. населением в каждой стране
    public async Task<List<City>> GetBiggestCityInEachCountry()
    {
        return await context.Cities
            .GroupBy(c => c.CountryId)
            .Select(g => g.OrderByDescending(c => c.Population).First())
            .ToListAsync();
    }

    // Task 6: Все люди + их город и страна
    public async Task<List<object>> GetPeopleWithCityAndCountry()
    {
        return await context.People
            .Include(p => p.City).ThenInclude(c => c.Country)
            .Select(p => new
            {
                Person = p.Name,
                City = p.City.Name,
                Country = p.City.Country.Name
            })
            .ToListAsync<object>();
    }

    // Task 7: Города, где есть человек по имени Dilnoza
    public async Task<List<City>> GetCitiesWithDilnoza()
    {
        return await context.Cities
            .Where(c => c.People.Any(p => p.Name == "Dilnoza"))
            .ToListAsync();
    }

    // Task 8: Самый старый человек в каждом городе
    public async Task<List<object>> GetOldestPersonInEachCity()
    {
        return await context.Cities
            .Select(c => new
            {
                City = c.Name,
                Oldest = c.People.OrderByDescending(p => p.Age).FirstOrDefault()
            })
            .ToListAsync<object>();
    }

    // Task 9a: Люди из города с названием cityname
    public async Task<List<Person>> GetPeopleByCityName(string cityName)
    {
        return await context.People
            .Where(p => p.City.Name == cityName)
            .ToListAsync();
    }

    // Task 9b: Самый молодой человек в каждой стране
    public async Task<List<object>> GetYoungestPersonInEachCountry()
    {
        return await context.Countries
            .Select(c => new
            {
                Country = c.Name,
                Youngest = c.Cities
                    .SelectMany(city => city.People)
                    .OrderBy(p => p.Age)
                    .FirstOrDefault()
            })
            .ToListAsync<object>();
    }

    // Task 10: Город с макс. людей в диапазоне возраста
    public async Task<City?> GetCityWithMostPeopleInAgeRange(int minAge, int maxAge)
    {
        return await context.Cities
            .OrderByDescending(c => c.People.Count(p => p.Age >= minAge && p.Age <= maxAge))
            .FirstOrDefaultAsync();
    }
}