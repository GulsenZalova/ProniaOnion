using System.Linq.Expressions;

namespace ProniaOnion.src.Application
{
    public interface IRepository<T> where T : class
    {
             IQueryable<T> GetAll(
        Expression<Func<T,bool>>? expression=null, 
        Expression<Func<T,object>>? orderExpression=null,
         bool isDescending=false,
        int skip=0,
        int take=0
        );
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    }
}