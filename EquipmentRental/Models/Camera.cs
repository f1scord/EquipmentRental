namespace EquipmentRental.Models;

public class Camera : Equipment
{
    public int Resolution { get; set; }
    public string Brand { get; set; }

    public Camera(string name, int resolution, string brand) : base(name)
    {
        Resolution = resolution;
        Brand = brand;
    }

    public override string GetInfo()
    {
        return $"{Name} ({Resolution}x{Brand})";
    }
}