using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Verra.Employees.Domain.SeedWork;
using Db = Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.DataMappings;

public class EmployeesRepositoryDataMapper : IRepositoryDataMapper<Employee, Db.Employee>
{
    public Employee ToEntity(Db.Employee entity)
    {
        return new Employee(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Department,
            entity.ProjectId,
            new Address(entity.StreetLine1, entity.StreetLine2, entity.City, entity.State, entity.ZipCode, entity.Country),
            entity.Dob,
            Enumeration.FromDisplayName<Gender>(entity.Gender),
            new List<EmployeePosition>());
    }

    public Db.Employee ToDbEntity(Employee entity)
    {
        return new Db.Employee
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Department = entity.Department,
            ProjectId = entity.ProjectId,
            StreetLine1 = entity.Address.StreetLine1,
            StreetLine2 = entity.Address.StreetLine2,
            City = entity.Address.City,
            State = entity.Address.State,
            ZipCode = entity.Address.ZipCode,
            Country = entity.Address.Country,
            Dob = entity.Dob,
            Gender = entity.Gender.Name
        };
    }

    public void ToDbEntity(Employee entity, Db.Employee dbEntity)
    {
        dbEntity.Id = entity.Id;
        dbEntity.FirstName = entity.FirstName;
        dbEntity.LastName = entity.LastName;
        dbEntity.Department = entity.Department;
        dbEntity.ProjectId = entity.ProjectId;
        dbEntity.StreetLine1 = entity.Address.StreetLine1;
        dbEntity.StreetLine2 = entity.Address.StreetLine2;
        dbEntity.City = entity.Address.City;
        dbEntity.State = entity.Address.State;
        dbEntity.ZipCode = entity.Address.ZipCode;
        dbEntity.Country = entity.Address.Country;
        dbEntity.Dob = entity.Dob;
        dbEntity.Gender = entity.Gender.Name;
    }
}