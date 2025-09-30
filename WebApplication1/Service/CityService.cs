using WebApplication1.Data.DataContext;
using WebApplication1.Data.Entities;

namespace WebApplication1.Service;

public class CityService(AppDbContext context) : ICityService
{
    public List<Object> GetAllPeople()
    {
        var getall = (from person in context.People
            join city in context.Cities on person.CityId equals city.Id
            where city.Population >= 3_000_00
            select new
            {
                person.Name,
                CityName = city.Name,
                city.Population

            }).ToList();
        return [getall];
    }
}