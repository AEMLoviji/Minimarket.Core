using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Services.Response;

namespace Minimarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);
    }
}