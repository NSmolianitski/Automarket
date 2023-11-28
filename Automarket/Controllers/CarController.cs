using Automarket.Domain.ViewModels;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var response = await _carService.GetCars();
        if (response.StatusCode is Domain.Enum.StatusCode.OK)
            return View(response.Data);

        return RedirectToAction("Error");
    }

    [HttpGet]
    public async Task<IActionResult> GetCar(int id)
    {
        var response = await _carService.GetCar(id);
        if (response.StatusCode is Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [HttpGet, Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CarViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _carService.CreateCar(model);
            if (response.StatusCode is Domain.Enum.StatusCode.OK)
                return View(response.Data);
        }

        return RedirectToAction("Error");
    }
        
    [HttpPut, Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(CarViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _carService.EditCar(model);
            if (response.StatusCode is Domain.Enum.StatusCode.OK)
                return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [HttpDelete, Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _carService.DeleteCar(id);
        if (response.StatusCode is Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetCars");
        }

        return RedirectToAction("Error");
    }
}