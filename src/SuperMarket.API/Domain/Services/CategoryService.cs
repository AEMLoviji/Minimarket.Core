using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}