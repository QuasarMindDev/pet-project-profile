using Pet.Project.Profile.Domain.Extensions;
using System.Linq.Expressions;

namespace Pet.Project.Profile.Domain.Database
{
    public interface IRepository<T>
    {
        Task AddAsync(T obj);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll(PagingExtension pagingExtensions);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> UpdateAsync(T obj);
    }
}