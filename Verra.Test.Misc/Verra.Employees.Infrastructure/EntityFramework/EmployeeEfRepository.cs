using Microsoft.EntityFrameworkCore;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Verra.Employees.Domain.SeedWork;
using Verra.Employees.Infrastructure.DataMappings;
using Db = Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.EntityFramework;

public class EmployeeEfRepository : EfRepository<Employee, Guid, Db.Employee>, IEmployeeRepository<EmployeesEfDbContext>
{
    private readonly IRepositoryDataMapper<EmployeePosition, Db.EmployeePosition> positionDataMapper;

    /// <inheritdoc cref="EfRepository{TEntity, TEntityId, TDbEntity}(IUnitOfWork{EmployeesEfDbContext}, IRepositoryDataMapper{TEntity,TDbEntity})" />
    public EmployeeEfRepository(
        IUnitOfWork<EmployeesEfDbContext> unitOfWork,
        IRepositoryDataMapper<Employee, Db.Employee> repositoryMapper,
        IRepositoryDataMapper<EmployeePosition, Db.EmployeePosition> positionDataMapper)
        : base(unitOfWork, repositoryMapper)
    {
        this.positionDataMapper = positionDataMapper;
    }

    /// <inheritdoc cref="EfRepository{TEntity, TEntityId,TDbEntity}(EmployeesEfDbContext, IRepositoryDataMapper{TEntity,TDbEntity})" />
    public EmployeeEfRepository(
        EmployeesEfDbContext context,
        IRepositoryDataMapper<Employee, Db.Employee> repositoryMapper,
        IRepositoryDataMapper<EmployeePosition, Db.EmployeePosition> positionDataMapper)
        : base(context, repositoryMapper)
    {
        this.positionDataMapper = positionDataMapper;
    }

    public Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellation)
    {
        var dbEmployees = Context.Employees?.Include(e => e.Positions).AsEnumerable().ToList();
        if (dbEmployees == null || dbEmployees.Any() == false) return Task.FromResult<IEnumerable<Employee>>(new List<Employee>());

        var employees = new List<Employee>();
        foreach (var dbEmp in dbEmployees)
        {
            var emp = RepositoryMapper.ToEntity(dbEmp);
            employees.Add(emp);
            if (dbEmp.Positions.Any() == false) continue;

            emp.Positions = emp.Positions.ToList();
        }


        return Task.FromResult<IEnumerable<Employee>>(employees);
    }
}