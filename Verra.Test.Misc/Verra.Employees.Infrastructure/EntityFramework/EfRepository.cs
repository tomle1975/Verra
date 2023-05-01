using Verra.Employees.Domain.SeedWork;
using Verra.Employees.Infrastructure.DataMappings;

namespace Verra.Employees.Infrastructure.EntityFramework;

public class EfRepository<TEntity, TEntityId, TDbEntity> : IRepository<EmployeesEfDbContext, TEntity, TEntityId>, IDisposable
    where TEntity : Entity<TEntityId>, IAggregateRoot<TEntityId>
    where TDbEntity : class
{
    protected readonly IRepositoryDataMapper<TEntity, TDbEntity> RepositoryMapper;
    private bool disposed;

    /// <summary>
    /// Creates a new repository of <see cref="TEntity" /> with unit of work.
    /// </summary>
    public EfRepository(IUnitOfWork<EmployeesEfDbContext> unitOfWork, IRepositoryDataMapper<TEntity, TDbEntity> repositoryMapper)
        : this(unitOfWork.Context, repositoryMapper)
    {
    }

    /// <summary>
    /// Creates a new repository with address database context.
    /// </summary>
    public EfRepository(EmployeesEfDbContext context, IRepositoryDataMapper<TEntity, TDbEntity> repositoryMapper)
    {
        disposed = false;
        Context = context;
        RepositoryMapper = repositoryMapper;
    }

    /// <inheritdoc cref="IDisposable.Dispose" />
    public void Dispose()
    {
        Context.Dispose();
        disposed = true;
    }

    /// <summary>
    /// Gets or sets address database context.
    /// </summary>
    public EmployeesEfDbContext Context { get; set; }

    /// <inheritdoc cref="IRepository{TContext, TEntity, TEntityId}.GetAll" />
    public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellation)
    {
        return cancellation.IsCancellationRequested
            ? Task.FromCanceled<IEnumerable<TEntity>>(cancellation)
            : Task.FromResult(Context.Set<TDbEntity>().AsEnumerable().Select(e => RepositoryMapper.ToEntity(e)));
    }

    /// <inheritdoc cref="IRepository{TContext, TEntity, TEntityId}.GetById" />
    public async Task<TEntity?> GetById(TEntityId id, CancellationToken cancellation)
    {
        var dbEntity = await Context.FindAsync<TDbEntity>(id, cancellation).ConfigureAwait(false);
        return dbEntity == null ? null : RepositoryMapper.ToEntity(dbEntity);
    }

    /// <inheritdoc cref="IRepository{TContext, TEntity, TEntityId}.Insert" />
    public async Task Insert(TEntity entity, CancellationToken cancellation)
    {
        if (disposed) Context = new EmployeesEfDbContext();

        var dbEntity = RepositoryMapper.ToDbEntity(entity);
        await Context.AddAsync(dbEntity, cancellation).ConfigureAwait(false);
    }

    /// <inheritdoc cref="IRepository{TContext, TEntity, TEntityId}.Update" />
    public async Task Update(TEntity entity, CancellationToken cancellation)
    {
        if (disposed) Context = new EmployeesEfDbContext();

        var dbEntity = await Context.FindAsync<TDbEntity>(entity.Id, cancellation).ConfigureAwait(false) ?? throw new InvalidOperationException();
        RepositoryMapper.ToDbEntity(entity, dbEntity);
    }

    /// <inheritdoc cref="IRepository{TContext, TEntity, TEntityId}.Delete" />
    public async Task Delete(TEntity entity, CancellationToken cancellation)
    {
        if (disposed) Context = new EmployeesEfDbContext();

        var dbEntity = await Context.FindAsync<TDbEntity>(entity.Id, cancellation).ConfigureAwait(false);
        if (dbEntity == null) return;

        Context.Remove(dbEntity);
    }
}