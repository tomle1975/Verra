using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

/// <summary>
/// Represents an employee which is an entity and a root aggregate.
/// </summary>
public class Employee : Entity<Guid>, IAggregateRoot<Guid>
{
    public Employee(
        Guid id,
        string firstName,
        string lastName,
        string department,
        Guid projectId,
        Address address,
        DateTime dob,
        Gender gender,
        List<EmployeePosition> positions)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Department = department;
        ProjectId = projectId;
        Address = address;
        Dob = dob;
        Gender = gender;
        Positions = positions;
    }

    /// <summary>
    /// Gets or sets first name of the employee.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets last name of the employee.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets department the employee works for.
    /// </summary>
    public string Department { get; set; } // TODO: Need to have normalized database to store department information separately.

    /// <summary>
    /// Gets or sets project ID the employee currently works on.
    /// </summary>
    public Guid ProjectId { get; set; } // TODO: This design flaw as over the years an employee can work on more than one project.

    /// <summary>
    /// Gets or sets address of the employee.
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets date of birth of the employee.
    /// </summary>
    public DateTime Dob { get; set; }

    /// <summary>
    /// Gets or sets gender of the employee.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Gets all positions the employee has held.
    /// </summary>
    public List<EmployeePosition> Positions { get; set; }
}