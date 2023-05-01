namespace Verra.Employees.Api.DataMappings;

public interface IApiDataMapper<TEntity, TApiDto>
{
    /// <summary>
    /// Maps the given <see cref="ToApiDto" /> to <see cref="TEntity" />.
    /// </summary>
    TEntity ToEntity(TApiDto dto);

    /// <summary>
    /// Maps from <see cref="TEntity" /> to <see cref="TApiDto" />.
    /// </summary>
    TApiDto ToApiDto(TEntity entity);
}