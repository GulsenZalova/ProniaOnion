using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }

}