using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

/// <summary>
/// Represents an employee which is an entity and a root aggregate.
/// </summary>
public class Employee : Entity<Guid>, IAggregateRoot<Guid>
{
    public Employee(Guid id, string firstName, string lastName, string department, Guid projectId, string address, DateTime dob, string gender, string position, DateTime dateOfJoining, double salary)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Department = department;
        ProjectId = projectId;
        Address = address;
        Dob = dob;
        Gender = gender;
        Position = position;
        DateOfJoining = dateOfJoining;
        Salary = salary;
    }

    /// <summary>
    /// Gets or sets first name of the employee.
    /// </summary>
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Department { get; set; } // TODO: Need to have normalized database to store department information separately.

    public Guid ProjectId { get; set; } // TODO: Need to consider this as another entity.

    public string Address { get; set; } // TODO: This is a complex entity and needs to be refactored.

    public DateTime Dob { get; set; }

    public string Gender { get; set; } // TODO: Need to represent gender as an Enumeration.

    public string Position { get; set; } // TODO: consider reusability.

    public DateTime DateOfJoining { get; set; }

    public double Salary { get; set; }
}