namespace EquipmentRental.Models;
public class Rental
{
    public Guid Id { get; private set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentedAt { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public decimal Penalty { get; set; }
    public bool IsActive => ReturnedAt == null;
    public bool IsOverdue => IsActive && DateTime.Now > DueDate;
    public Rental(User user, Equipment equipment, int rentalDays)
    {
        Id = Guid.NewGuid();
        User = user;
        Equipment = equipment;
        RentedAt = DateTime.Now;
        DueDate = DateTime.Now.AddDays(rentalDays);
        Penalty = 0;
    }
}
