namespace Verra.Employees.Infrastructure.EntityFramework.Tables;

public class EmployeePosition
{
    /// <summary>
    /// Gets or sets position ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the position's title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the date title is given to for the position.
    /// </summary>
    public DateTime ReceivedDate { get; set; }

    /// <summary>
    /// Gets or sets salary given for the position.
    /// </summary>
    public double Salary { get; set; }

    /// <summary>
    /// Gets or sets the employee who holds this position.
    /// </summary>
    public Employee Employee { get; set; }

    /// <summary>
    /// Gets or sets the employee ID who holds this position.
    /// </summary>
    public Guid EmployeeId { get; set; }
}