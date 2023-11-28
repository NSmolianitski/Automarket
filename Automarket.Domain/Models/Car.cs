using Automarket.Domain.Enum;

namespace Automarket.Domain.Entity;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public double Speed { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateDate { get; set; }
    public CarType Type { get; set; }
    // public byte[]? Image { get; set; }
}