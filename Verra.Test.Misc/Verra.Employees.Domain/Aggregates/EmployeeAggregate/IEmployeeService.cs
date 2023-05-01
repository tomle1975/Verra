using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<Employee>>> GetEmployeesAsync(CancellationToken cancellation);
    }
}