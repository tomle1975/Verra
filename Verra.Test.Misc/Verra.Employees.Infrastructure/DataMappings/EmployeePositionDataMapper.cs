using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Db = Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.DataMappings;

public class EmployeePositionDataMapper : IRepositoryDataMapper<EmployeePosition, Db.EmployeePosition>
{
    private readonly IRepositoryDataMapper<Employee, Db.Employee> employeeDataMapper;

    public EmployeePositionDataMapper(IRepositoryDataMapper<Employee, Db.Employee> employeeDataMapper)
    {
        this.employeeDataMapper = employeeDataMapper;
    }

    public EmployeePosition ToEntity(Db.EmployeePosition entity)
    {
        return new EmployeePosition(entity.Id, entity.EmployeeId, entity.ReceivedDate, entity.Title, entity.Salary);
    }

    public Db.EmployeePosition ToDbEntity(EmployeePosition entity)
    {
        return new Db.EmployeePosition
        {
            Id = entity.Id,
            EmployeeId = entity.EmployeeId,
            ReceivedDate = entity.ReceivedDate,
            Title = entity.Title,
            Salary = entity.Salary
        };
    }

    public void ToDbEntity(EmployeePosition entity, Db.EmployeePosition dbEntity)
    {
        dbEntity.Id = entity.Id;
        dbEntity.EmployeeId = entity.EmployeeId;
        dbEntity.ReceivedDate = entity.ReceivedDate;
        dbEntity.Title = entity.Title;
        dbEntity.Salary = entity.Salary;
    }
}