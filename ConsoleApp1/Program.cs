

using ConsoleApp1;

Console.WriteLine("Hello, World!");

List<Country> countries = [
    new Country { Id = 1, Name = "Uzbekistan" },
    new Country { Id = 2, Name = "Tajikistan" },
    new Country { Id = 3, Name = "Kazakhstan" }
];

List<City> cities = [
    new City { Id = 1, Name = "Tashkent", Population = 3_000_000, CountryId = 1 },
    new City { Id = 2, Name = "Samarkand", Population = 585_000, CountryId = 1 },

    // Tajikistan
    new City { Id = 3, Name = "Dushanbe", Population = 1_000_000, CountryId = 2 },
    new City { Id = 4, Name = "Khujand", Population = 144_000, CountryId = 2 },

    // Kazakhstan
    new City { Id = 5, Name = "Almaty", Population = 2_000_000, CountryId = 3 },
    new City { Id = 6, Name = "Astana", Population = 1_300_000, CountryId = 3 }
];

List<Person> persons = [
    new Person { Id = 1, Name = "Ali", Age = 25, CityId = 1 },
    new Person { Id = 2, Name = "Dilnoza", Age = 30, CityId = 1 },

    // Samarkand
    new Person { Id = 3, Name = "Javlon", Age = 28, CityId = 2 },

    // Dushanbe
    new Person { Id = 4, Name = "Farzona", Age = 22, CityId = 3 },
    new Person { Id = 5, Name = "Rustam", Age = 35, CityId = 3 },

    // Khujand
    new Person { Id = 6, Name = "Shahnoza", Age = 27, CityId = 4 },

    // Almaty
    new Person { Id = 7, Name = "Yerlan", Age = 40, CityId = 5 },
    new Person { Id = 8, Name = "Aruzhan", Age = 29, CityId = 5 },

    // Astana
    new Person { Id = 9, Name = "Nursultan", Age = 33, CityId = 6 },
    new Person { Id = 10, Name = "Dana", Age = 26, CityId = 6 }
];

Console.WriteLine("first task");
var allpeople = from person in persons
    join city in cities on person.CityId equals city.Id
    where city.Population >= 3_000_000
    select new
    {
        person.Name,
        CityName = city.Name,
        city.Population
    };

foreach (var p in allpeople)
{
    Console.WriteLine(p.Name);
}


Console.WriteLine("Second task");
var count = 