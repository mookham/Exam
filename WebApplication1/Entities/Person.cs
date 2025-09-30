namespace WebApplication1.Data.Entities;


public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

    public int CityId { get; set; }
    public City City { get; set; } = null!;
}