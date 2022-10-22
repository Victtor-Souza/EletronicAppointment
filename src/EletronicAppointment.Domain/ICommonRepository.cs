namespace EletronicAppointment.Domain;

public interface ICommonRepository<T>
{
    Task<T> GetAsync(Guid id);

    Task AddAsync(T entity);

    Task Update(T entity);

    Task Delete(T entity);
}
