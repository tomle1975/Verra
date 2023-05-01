namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

/// <summary>
/// Represents an address for an employee.
/// </summary>
public record Address(string StreetLine1, string? StreetLine2, string City, string State, string ZipCode, string Country);