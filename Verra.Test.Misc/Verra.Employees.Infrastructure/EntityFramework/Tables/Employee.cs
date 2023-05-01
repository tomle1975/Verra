namespace Verra.Employees.Infrastructure.EntityFramework.Tables;

/// <summary>
/// Represents an Employee record in the database.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the primary key of an employee.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets first name of an employee.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets last name of an employee.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets department an employee currently works in.
    /// </summary>
    public string Department { get; set; }

    /// <summary>
    /// Gets or sets current project ID an employee works on.
    /// </summary>
    public Guid ProjectId { get; set; }

    /// <summary>
    /// Gets or sets street line 1 of employee's address.
    /// </summary>
    public string StreetLine1 { get; set; }

    /// <summary>
    /// Gets or sets street line 2 of employee's address.
    /// </summary>
    public string? StreetLine2 { get; set; }

    /// <summary>
    /// Gets or sets city of employee's address.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets state of employee's address.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Gets or sets zip code of employee's address.
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// Gets or sets country of employee's address.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets date of birth of the employee.
    /// </summary>
    public DateTime Dob { get; set; }

    /// <summary>
    /// Gets or sets the gender of the employee.
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the positions the employee has held.
    /// </summary>
    public ICollection<EmployeePosition> Positions { get; set; } = new List<EmployeePosition>();
}