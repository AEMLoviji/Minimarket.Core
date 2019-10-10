using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}