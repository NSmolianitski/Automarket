using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum;

public enum CarType
{
    [Display(Name = "Легковой автомобиль")]
    Passenger,
    [Display(Name = "Седан")]
    Sedan,
    [Display(Name = "Хэтчбек")]
    HatchBack,
    [Display(Name = "Минивэн")]
    Minivan,
    [Display(Name = "Спортивная машина")]
    SportsCar,
    [Display(Name = "Внедорожник")]
    Suv
}