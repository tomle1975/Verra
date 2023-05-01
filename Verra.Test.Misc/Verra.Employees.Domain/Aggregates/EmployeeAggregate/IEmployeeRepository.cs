using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

public interface IEmployeeRepository<TContext> : IRepository<TContext, Employee, Guid> where TContext : new()
{
    /// <summary>
    /// Gets all employees along with their positions.
    /// </summary>
    Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellation);
}