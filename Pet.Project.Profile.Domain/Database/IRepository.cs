using System.Linq.Expressions;

namespace Pet.Project.Profile.Domain.Database
{
    public interface IRepository<T>
    {
        Task AddAsync(T obj);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> UpdateAsync(T obj);
    }
}