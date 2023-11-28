using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Repositories;

public class CarRepository : IBaseRepository<Car>
{
    private readonly ApplicationDbContext _db;

    public CarRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Car model)
    {
        await _db.Cars.AddAsync(model);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Car> GetAll()
    {
        return _db.Cars;
    }

    public async Task<bool> Delete(Car model)
    {
        _db.Cars.Remove(model);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Car> Update(Car model)
    {
        _db.Cars.Update(model);
        await _db.SaveChangesAsync();
        return model;
    }
}