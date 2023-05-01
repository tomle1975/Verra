using Verra.Employees.Domain.SeedWork;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate;

public interface IEmployeeRepository<TContext> : IRepository<TContext, Employee, Guid> where TContext : new()
{
}