using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minimarket.API.Domain.Db.Contexts;
using Minimarket.API.Domain.Models;

namespace Minimarket.API.Domain.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            // TODO below line will be moved to UOW pattern based class, as it's not repository layer responsibility to apply changes to DB. 
            _context.SaveChanges();
        }
    }
}