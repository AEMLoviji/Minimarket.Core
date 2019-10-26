using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Services.Response;

namespace Minimarket.API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}