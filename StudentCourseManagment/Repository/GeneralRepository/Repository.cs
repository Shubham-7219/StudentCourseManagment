using Microsoft.EntityFrameworkCore;
using StudentCourseManagment.DataContext;
using System.Linq.Expressions;

namespace StudentCourseManagment.Repository.GeneralRepository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
       
            IQueryable<T> query = dbSet;
            return query.FirstOrDefault(filter);
            
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
           dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           dbSet.RemoveRange(entity);
        }
    }
}
