using FluentValidation;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Verra.Employees.Domain.SeedWork;
using Verra.Employees.Infrastructure.EntityFramework;

namespace Verra.Employees.Infrastructure.Services;

public class EmployeeEfService : IEmployeeService
{
    private readonly IUnitOfWork<EmployeesEfDbContext> unitOfWork;
    private readonly IEmployeeRepository<EmployeesEfDbContext> repository;

    public EmployeeEfService(
        IUnitOfWork<EmployeesEfDbContext> unitOfWork,
        IEmployeeRepository<EmployeesEfDbContext> repository,
        IValidator<Employee> validator)
    {
        this.unitOfWork = unitOfWork;
        this.repository = repository;
    }

    public async Task<Result<IEnumerable<Employee>>> GetEmployeesAsync(CancellationToken cancellation)
    {
        var result = new Result<IEnumerable<Employee>>();

        try
        {
            result.Data = await repository.GetAll(cancellation).ConfigureAwait(false);

            result.IsSuccessful = true;
        }
        catch (Exception ex)
        {
            result.Message = "Failed to retrieve employees from database.";
            result.Description = ex.Message;
            result.Errors.Add(ex);
            return result;
        }

        return result;
    }
}