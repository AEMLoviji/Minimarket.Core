using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;

namespace Minimarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
    }
}