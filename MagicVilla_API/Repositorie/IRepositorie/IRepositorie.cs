using System.Linq.Expressions;

namespace MagicVilla_API.Repositorie.IRepositorie
{
    public interface IRepositorie<T> where T : class
    {
        Task Create(T entity);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);

        Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true);

        Task Remove(T entity);

        Task Save();
    }
}
