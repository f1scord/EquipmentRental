namespace EquipmentRental.Models;

public abstract class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int MaxRentals { get; protected set; }
    public int ActiveRentalCount { get; set; }

    protected User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        ActiveRentalCount = 0;
    }
}