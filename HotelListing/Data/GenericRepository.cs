using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data {
    public class GenericRepository<T> : IRepository<T> where T : class {
        private readonly AppDbContext context;
        private readonly DbSet<T> db;

        public GenericRepository(AppDbContext context) {
            this.context = context;
            db = context.Set<T>();
        }

        public async Task<T> get(Expression<Func<T, bool>> expression, List<string> includes = null) {
            IQueryable<T> query = db;
            if(includes != null)
                foreach (var prop in includes)
                    query = query.Include(prop);
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> getAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null) {
            IQueryable<T> query = db;
            if (expression != null)
                query = query.Where(expression);

            if (includes != null)
                foreach (var prop in includes)
                    query = query.Include(prop);

            if (orderBy != null)
                query = orderBy(query);

            return await query.AsNoTracking().ToListAsync();
        }
        
        public async Task delete(int id) {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public void deleteRange(IEnumerable<T> entities) {
            db.RemoveRange(entities);
        }

        public async Task insert(T entity) {
            await db.AddAsync(entity);
        }

        public async Task insertRange(IEnumerable<T> entities) {
            await db.AddRangeAsync(entities);
        }

        public void update(T entity) {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
