using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;

namespace Minimarket.API.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}