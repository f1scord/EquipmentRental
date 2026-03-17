namespace EquipmentRental.Models;

public abstract class Equipment
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public bool IsAvailable  { get; set; }

    protected Equipment(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsAvailable = true;
    }
    
    public abstract string GetInfo();
}