using WebApplication1.Data.Entities;

namespace WebApplication1.Service;

public interface ICityService
{
    Task<List<Person>> GetPeopleInBigCities();
    Task<List<object>> GetPeopleCountInCities();
    Task<List<City>> GetCitiesAboveAverageInCountry();
    Task<List<City>> GetEmptyCities();
    Task<List<City>> GetBiggestCityInEachCountry();
    Task<List<object>> GetPeopleWithCityAndCountry();
    Task<List<City>> GetCitiesWithDilnoza();
    Task<List<object>> GetOldestPersonInEachCity();
    Task<List<Person>> GetPeopleByCityName(string cityName);
    Task<List<object>> GetYoungestPersonInEachCountry();
    Task<City?> GetCityWithMostPeopleInAgeRange(int minAge, int maxAge);

}