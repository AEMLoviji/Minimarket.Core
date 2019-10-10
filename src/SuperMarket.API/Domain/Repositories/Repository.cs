using SuperMarket.API.Domain.Db.Contexts;

namespace SuperMarket.API.Domain.Repositories
{
    public abstract class Repository
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
    }
}