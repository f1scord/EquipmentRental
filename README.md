# EquipmentRental

A console application in C# simulating a university equipment rental service. Users (students, employees) can rent equipment (laptops, projectors, cameras), return it, and get penalized for late returns.

## How to run
```bash
cd EquipmentRental
dotnet run
```

## Design decisions

- **Models / Services / Config** - domain classes only hold data, all logic lives in `Services/`. Clear separation of responsibilities.
- **Abstract classes** - `Equipment` and `User` share common properties and force subclasses to implement specific methods. Inheritance follows from the domain, not artificially.
- **RentalConfig** - all business rules (penalty, limits) in one place. Easy to change without touching multiple classes.
- **RentalService vs ReportService** - split because managing rentals and generating reports are two different jobs.

