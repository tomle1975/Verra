using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Db = Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.DataMappings;

public class EmployeesRepositoryDataMapper : IRepositoryDataMapper<Employee, Db.Employee>
{
    public Employee ToEntity(Db.Employee entity)
    {
        return new Employee(
            entity.EmpId,
            entity.FirstName,
            entity.LastName,
            entity.Department,
            entity.ProjectId,
            entity.Address,
            entity.Dob,
            entity.Gender,
            entity.Position.Position,
            entity.Position.DateOfJoining,
            entity.Position.Salary);
    }

    public Db.Employee ToDbEntity(Employee entity)
    {
        return new Db.Employee
        {
            EmpId = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Department = entity.Department,
            ProjectId = entity.ProjectId,
            Address = entity.Address,
            Dob = entity.Dob,
            Gender = entity.Gender
        };
    }

    public void ToDbEntity(Employee entity, Db.Employee dbEntity)
    {
        throw new NotImplementedException();
    }
}