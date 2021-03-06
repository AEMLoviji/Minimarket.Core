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

        public async Task<IEnumerable<Category>> ListAsync() => await _context.Categories.ToListAsync();

        public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);

        public async Task<Category> FindByIdAsync(int id) => await _context.Categories.FindAsync(id);

        public void Update(Category category) => _context.Categories.Update(category);

        public void Remove(Category category) => _context.Categories.Remove(category);
    }
}