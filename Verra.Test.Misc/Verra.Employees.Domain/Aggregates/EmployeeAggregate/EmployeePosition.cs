namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

/// <summary>
/// Represents a position that an employee holds.
/// </summary>
public record EmployeePosition(Guid Id, Guid EmployeeId, DateTime ReceivedDate, string Title, double Salary);