using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    private void AddCars() // TODO: REMOVE!
    {
        var car = new Car()
        {
            Name = "Lada (ВАЗ)",
            Model = "Vesta Cross",
            Type = CarType.Sedan,
            Speed = 120,
            Price = 1883900m,
            CreateDate = DateTime.Parse("01/01/2023")
        };
        
        var car2 = new Car()
        {
            Name = "BMW",
            Model = "X5 M50d",
            Type = CarType.Suv,
            Speed = 200,
            Price = 8750000m,
            CreateDate = DateTime.Parse("01/01/2020")
        };
        
        var car3 = new Car()
        {
            Name = "Nissan",
            Model = "X-Trail",
            Type = CarType.Suv,
            Speed = 190,
            Price = 2470770m,
            CreateDate = DateTime.Parse("01/01/2019")
        };
        
        var car4 = new Car()
        {
            Name = "Opel",
            Model = "Mokka",
            Type = CarType.Suv,
            Speed = 170,
            Price = 1200000m,
            CreateDate = DateTime.Parse("01/01/2014")
        };
        
        var car5 = new Car()
        {
            Name = "Ford",
            Model = "Mustang",
            Type = CarType.Minivan,
            Speed = 220,
            Price = 4690000m,
            CreateDate = DateTime.Parse("01/01/2021")
        };
        
        Cars.AddRange(car,car2,car3,car4,car5);
        SaveChanges();
    }
}