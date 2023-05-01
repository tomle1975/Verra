using Microsoft.AspNetCore.Mvc;
using Verra.Employees.Api.DataMappings;
using Verra.Employees.Api.Models;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;

namespace Verra.Employees.Api.Controllers;

[Route("api")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService service;
    private readonly IApiDataMapper<Employee, EmployeeDto> employeeMapper;

    public EmployeesController(
        IEmployeeService service,
        IApiDataMapper<Employee, EmployeeDto> employeeMapper)
    {
        this.service = service;
        this.employeeMapper = employeeMapper;
    }

    [Route("employees")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status510NotExtended)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            var serviceResult = await service.GetEmployeesAsync(cancellationToken);
            if (!serviceResult.IsSuccessful || serviceResult.Data == null || serviceResult.Data?.Any() == false) return StatusCode(StatusCodes.Status404NotFound);

            return serviceResult.Data?.Select(a => employeeMapper.ToApiDto(a)).ToList() ?? new List<EmployeeDto>();
        }
        catch (TaskCanceledException tcx)
        {
            return StatusCode(StatusCodes.Status510NotExtended);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}