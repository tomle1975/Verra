namespace Verra.Employees.Infrastructure.EntityFramework.Tables
{
    public class EmployeePosition
    {
        public Guid EmpGuid { get; set; }

        public string Position { get; set; }

        public DateTime DateOfJoining { get; set; }

        public double Salary { get; set; }

        public Employee Emp { get; set; }
    }
}