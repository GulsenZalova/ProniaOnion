using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }

}