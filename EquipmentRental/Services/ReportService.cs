using EquipmentRental.Models;
namespace EquipmentRental.Services;
public class ReportService
{
    private readonly RentalService _rentalService;
    public ReportService(RentalService rentalService)
    {
        _rentalService = rentalService;
    }
    public void PrintReport()
    {
        Console.WriteLine("===== SYSTEM REPORT =====");
        var allEquipment = _rentalService.GetAllEquipment();
        var available = _rentalService.GetAvailableEquipment();
        var overdue = _rentalService.GetOverdueRentals();
        var allRentals = _rentalService.GetAllRentals();
        Console.WriteLine($"Total equipment: {allEquipment.Count}");
        Console.WriteLine($"Available: {available.Count}");
        Console.WriteLine($"Active rentals: {allRentals.Count(r => r.IsActive)}");
        Console.WriteLine($"Overdue rentals: {overdue.Count}");
        Console.WriteLine("=========================");
    }
}
