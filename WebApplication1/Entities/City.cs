namespace WebApplication1.Data.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Population { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
    public ICollection<Person> People { get; set; } = new List<Person>();
}