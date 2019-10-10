using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Repositories;

namespace Minimarket.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}