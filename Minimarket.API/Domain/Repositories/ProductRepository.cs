using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Minimarket.API.Domain.Db.Contexts;
using Minimarket.API.Domain.Models;

namespace Minimarket.API.Domain.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> ListAsync() =>
            await _context.Products.Include(p => p.Category)
                                   .ToListAsync();
    }
}