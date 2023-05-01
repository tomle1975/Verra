namespace Verra.Employees.Api.Models;

public record EmployeeDto(
    Guid Id, 
    string FirstName, 
    string LastName, 
    string Department, 
    Guid ProjectId, 
    string StreetLine1, 
    string? StreetLine2,
    string City,
    string State,
    string ZipCode,
    string Country,
    DateTime Dob,
    string Gender,
    List<EmployeePositionDto> Positions);