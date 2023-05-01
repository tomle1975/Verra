using Verra.Employees.Api.Models;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;

namespace Verra.Employees.Api.DataMappings;

public class PositionApiDataMapper : IApiDataMapper<EmployeePosition, EmployeePositionDto>
{
    public EmployeePosition ToEntity(EmployeePositionDto dto)
    {
        throw new NotImplementedException();
    }

    public EmployeePositionDto ToApiDto(EmployeePosition entity)
    {
        return new EmployeePositionDto(entity.ReceivedDate, entity.Title, entity.Salary);
    }
}