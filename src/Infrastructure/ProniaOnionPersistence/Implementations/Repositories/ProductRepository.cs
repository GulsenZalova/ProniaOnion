using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }

}