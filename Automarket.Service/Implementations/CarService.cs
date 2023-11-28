using System.Net;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels;
using Automarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations;

public class CarService : ICarService
{
    private readonly IBaseRepository<Car> _carRepository;

    public CarService(IBaseRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
    {
        try
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
            if (car is null)
            {
                baseResponse.Description = "Машина не найдена.";
                baseResponse.StatusCode = StatusCode.NoContent;
            }
            else
            {
                baseResponse.StatusCode = StatusCode.OK;
                
                var carViewModel = new CarViewModel
                {
                    Name = car.Name,
                    Model = car.Model,
                    CreateDate = car.CreateDate,
                    Speed = car.Speed,
                    Type = car.Type.ToString(),
                    Price = car.Price
                };
                
                baseResponse.Data = carViewModel;
            }

            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<CarViewModel>
            {
                Description = $"[GetCar] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<Car>> GetCarByName(string name)
    {
        try
        {
            var baseResponse = new BaseResponse<Car>();
            var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Name == name);
            if (car is null)
            {
                baseResponse.Description = "Машина не найдена.";
                baseResponse.StatusCode = StatusCode.NoContent;
            }
            else
            {
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = car;
            }
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Car>
            {
                Description = $"[GetCarByName] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel)
    {
        try
        {
            var baseResponse = new BaseResponse<bool>();

            var car = new Car
            {
                Name = carViewModel.Name,
                Model = carViewModel.Model,
                CreateDate = carViewModel.CreateDate,
                Speed = carViewModel.Speed,
                Type = (CarType)Convert.ToInt32(carViewModel.Type),
                Price = carViewModel.Price
            };

            await _carRepository.Create(car);
            
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = true;
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>
            {
                Description = $"[CreateCar] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Car>> EditCar(CarViewModel model)
    {
        try
        {
            var baseResponse = new BaseResponse<Car>();

            var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == model.Id);
            if (car is null)
            {
                baseResponse.StatusCode = StatusCode.NoContent;
                baseResponse.Description = "Car not found.";
            }
            else
            {
                car.Name = model.Name;
                car.Model = model.Model;
                car.CreateDate = model.CreateDate;
                car.Speed = model.Speed;
                car.Type = (CarType) Convert.ToInt32(model.Type);
                car.Price = model.Price;

                await _carRepository.Update(car);
                
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = car;
            }
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Car>
            {
                Description = $"[EditCar] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCar(int id)
    {
        try
        {
            var baseResponse = new BaseResponse<bool>();
            
            var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
            if (car is null)
            {
                baseResponse.Description = "Машина не найдена.";
                baseResponse.StatusCode = StatusCode.NoContent;
                baseResponse.Data = false;
            }
            else
            {
                await _carRepository.Delete(car);
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = true;
            }

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>
            {
                Description = $"[DeleteCar] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
    {
        try
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();
            var cars = await _carRepository.GetAll().ToListAsync();
            if (cars.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов.";
                baseResponse.StatusCode = StatusCode.NoContent;
            }
            else
            {
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = cars;
            }
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Car>>
            {
                Description = $"[GetCars] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}