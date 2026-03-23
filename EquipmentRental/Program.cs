using EquipmentRental.Models;
using EquipmentRental.Services;
var rentalService = new RentalService();
var reportService = new ReportService(rentalService);
var laptop = new Laptop("Dell XPS", 15, 16);
var projector = new Projector("Epson EB", 3500, true);
var camera = new Camera("Canon EOS", 24, "Canon");
rentalService.AddEquipment(laptop);
rentalService.AddEquipment(projector);
rentalService.AddEquipment(camera);
var student = new Student("Anton", "Ovcharenko");
var employee = new Employee("Vadim", "Ovcharenko");
rentalService.AddUser(student);
rentalService.AddUser(employee);
Console.WriteLine(rentalService.RentEquipment(student.Id, laptop.Id));
Console.WriteLine(rentalService.RentEquipment(employee.Id, laptop.Id));
Console.WriteLine(rentalService.RentEquipment(student.Id, projector.Id));
Console.WriteLine(rentalService.RentEquipment(student.Id, camera.Id));
var activeRentals = rentalService.GetActiveRentals(student.Id);
Console.WriteLine(rentalService.ReturnEquipment(activeRentals[0].Id));

// Demo: overdue return with penalty
rentalService.AddEquipment(new Camera("Sony A7", 48, "Sony"));
var sonyCamera = rentalService.GetAllEquipment().Last();
rentalService.RentEquipment(employee.Id, sonyCamera.Id);
var employeeRentals = rentalService.GetActiveRentals(employee.Id);
// Simulate overdue by manually setting DueDate to the past
employeeRentals[0].DueDate = DateTime.Now.AddDays(-3);
Console.WriteLine(rentalService.ReturnEquipment(employeeRentals[0].Id));

reportService.PrintReport();
