namespace Verra.Employees.Infrastructure.DataMappings;

public interface IRepositoryDataMapper<TEntity, TDbEntity>
{
    /// <summary>
    /// Maps the given <see cref="TDbEntity" /> to <see cref="TEntity" />.
    /// </summary>
    TEntity ToEntity(TDbEntity entity);

    /// <summary>
    /// Maps from <see cref="TEntity" /> to <see cref="TDbEntity" />.
    /// </summary>
    TDbEntity ToDbEntity(TEntity entity);

    /// <summary>
    /// Maps the given <see cref="TEntity" /> to the referenced <see cref="TDbEntity" />.
    /// </summary>
    void ToDbEntity(TEntity entity, TDbEntity dbEntity);
}