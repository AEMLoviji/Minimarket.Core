using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Services.Response;

namespace Minimarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryOperationResponse> SaveAsync(Category category);
        Task<CategoryOperationResponse> UpdateAsync(int id, Category category);
        Task<CategoryOperationResponse> DeleteAsync(int id);
    }
}