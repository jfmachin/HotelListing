using System.Linq.Expressions;

namespace HotelListing.Data {
    public interface IRepository<T> where T: class {
        Task<IList<T>> getAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        Task<T> get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task insert(T entity);
        Task insertRange(IEnumerable<T> entities);
        Task delete(int id);
        void deleteRange(IEnumerable<T> entities);
        void update(T entity);
    }
}
