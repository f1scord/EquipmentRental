using EquipmentRental.Config;
using EquipmentRental.Models;
namespace EquipmentRental.Services;
public class RentalService
{
    private readonly List<User> _users = new();
    private readonly List<Equipment> _equipment = new();
    private readonly List<Rental> _rentals = new();
    public void AddUser(User user) => _users.Add(user);
    public List<User> GetUsers() => _users;
    public void AddEquipment(Equipment equipment) => _equipment.Add(equipment);
    public List<Equipment> GetAllEquipment() => _equipment;
    public List<Equipment> GetAvailableEquipment() =>
        _equipment.Where(e => e.IsAvailable).ToList();
    public void MarkUnavailable(Guid equipmentId)
    {
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment != null)
            equipment.IsAvailable = false;
    }
    public string RentEquipment(Guid userId, Guid equipmentId, int days = RentalConfig.DefaultRentalDays)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (user == null) return "User not found.";
        if (equipment == null) return "Equipment not found.";
        if (!equipment.IsAvailable) return "Equipment is not available.";
        if (user.ActiveRentalCount >= user.MaxRentals)
            return $"Rental limit reached ({user.MaxRentals}).";
        var rental = new Rental(user, equipment, days);
        _rentals.Add(rental);
        equipment.IsAvailable = false;
        user.ActiveRentalCount++;
        return $"Rental created. Due date: {rental.DueDate:dd.MM.yyyy}";
    }
    public string ReturnEquipment(Guid rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId && r.IsActive);
        if (rental == null) return "Rental not found.";
        rental.ReturnedAt = DateTime.Now;
        rental.Equipment.IsAvailable = true;
        rental.User.ActiveRentalCount--;
        if (DateTime.Now > rental.DueDate)
        {
            var daysLate = (int)(DateTime.Now - rental.DueDate).TotalDays + 1;
            rental.Penalty = daysLate * RentalConfig.PenaltyPerDay;
            return $"Returned late by {daysLate} day(s). Penalty: {rental.Penalty} PLN";
        }
        return "Returned on time. No penalty.";
    }
    public List<Rental> GetActiveRentals(Guid userId) =>
        _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();
    public List<Rental> GetOverdueRentals() =>
        _rentals.Where(r => r.IsOverdue).ToList();
    public List<Rental> GetAllRentals() => _rentals;
}
