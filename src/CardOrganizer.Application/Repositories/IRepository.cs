namespace CardOrganizer.Application.Repositories;

public interface IRepository<T>
{
    T GetById(int id);

    IQueryable<T> GetAll();

    Task Add(T entity);
    
    Task Update(T entity);

    Task Delete(int id);
}