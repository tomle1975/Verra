using Verra.Employees.Api.Models;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;

namespace Verra.Employees.Api.DataMappings;

public class EmployeeApiDataMapper : IApiDataMapper<Employee, EmployeeDto>
{
    private readonly IApiDataMapper<EmployeePosition, EmployeePositionDto> positionDataMapper;

    public EmployeeApiDataMapper(IApiDataMapper<EmployeePosition, EmployeePositionDto> positionDataMapper)
    {
        this.positionDataMapper = positionDataMapper;
    }

    public Employee ToEntity(EmployeeDto dto)
    {
        throw new NotImplementedException();
    }

    public EmployeeDto ToApiDto(Employee entity)
    {
        var dto = new EmployeeDto(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Department,
            entity.ProjectId,
            entity.Address.StreetLine1,
            entity.Address.StreetLine2,
            entity.Address.City,
            entity.Address.State,
            entity.Address.ZipCode,
            entity.Address.Country,
            entity.Dob,
            entity.Gender.Name,
            new List<EmployeePositionDto>());

        if (!entity.Positions.Any()) return dto;

        dto.Positions.AddRange(entity.Positions.Select(p => positionDataMapper.ToApiDto(p)));
        return dto;
    }
}