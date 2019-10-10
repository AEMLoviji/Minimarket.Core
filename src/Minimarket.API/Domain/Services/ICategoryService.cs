using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;

namespace Minimarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}