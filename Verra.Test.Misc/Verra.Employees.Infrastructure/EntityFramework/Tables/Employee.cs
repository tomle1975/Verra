namespace Verra.Employees.Infrastructure.EntityFramework.Tables;

public class Employee
{
    public Guid EmpId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Department { get; set; }

    public Guid ProjectId { get; set; }

    public string Address { get; set; }

    public DateTime Dob { get; set; }

    public string Gender { get; set; }

    public EmployeePosition Position { get; set; }
}