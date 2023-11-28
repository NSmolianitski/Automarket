namespace Automarket.Domain.ViewModels;

public class CarViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public double Speed { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateDate { get; set; }
    public string Type { get; set; }
    // public byte[]? Image { get; set; }
}