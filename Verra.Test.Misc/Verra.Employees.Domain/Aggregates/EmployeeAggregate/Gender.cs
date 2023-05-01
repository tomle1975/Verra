using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

/// <summary>
/// Represents gender of an employee.
/// </summary>
public class Gender : Enumeration
{
    public Gender(int id, string name) : base(id, name)
    {
    }

    public static Gender Male = new(1, nameof(Male));

    public static Gender Female = new(2, nameof(Female));
}