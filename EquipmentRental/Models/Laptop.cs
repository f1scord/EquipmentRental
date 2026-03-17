namespace EquipmentRental.Models;

public class Laptop : Equipment
{
    public int SizeInches {get; set;}
    public int RamGb {get; set;}

    public Laptop(string name, int sizeInches, int ramGg) : base(name)
    {
        SizeInches = sizeInches;
        RamGb = ramGg;
    }

    public override string GetInfo()
    {
        return $"Laptop Size: {SizeInches}, RAM: {RamGb}GB";
    }
}