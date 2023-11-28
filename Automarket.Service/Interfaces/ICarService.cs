using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels;

namespace Automarket.Service.Interfaces;

public interface ICarService
{
    Task<IBaseResponse<CarViewModel>> GetCar(int id);
    Task<IBaseResponse<Car>> GetCarByName(string name);
    Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel);
    Task<IBaseResponse<Car>> EditCar(CarViewModel model);
    Task<IBaseResponse<bool>> DeleteCar(int id);
    Task<IBaseResponse<IEnumerable<Car>>> GetCars();
}