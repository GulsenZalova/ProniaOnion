using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Persistence;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
     
} public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {

        public readonly AppDbContext _context;
        public readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }



        public IQueryable<T> GetAll(
        Expression<Func<T,bool>>? expression=null,
        Expression<Func<T,object>>? orderExpression=null,
        bool isDescending=false,
        int skip=0,
        int take=0
        )
        {
  

            IQueryable<T> query= _table.AsQueryable();
            // Filter Datas
            if(expression != null)
            {
                 return query.Where(expression);
            }
             
            // Sort Datas

            if(orderExpression != null)
            {
                if (!isDescending)
                {
                    return query.OrderBy(orderExpression);
                }
                else
                {
                    return query.OrderByDescending(orderExpression);
                }
            }
            

            // Pagination

             // Skip
             // Take
            query=query.Skip(skip);

            if (take > 0)
            {
                query=query.Take(take); 
            }
            return query;

        }

        public async Task<T> GetById(int id)
        {
            return await _table.Include("Products").FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);

        }
        public void Update(T entity)
        {
              _table.Update(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _table.AnyAsync(expression);
        }

    
    
}
