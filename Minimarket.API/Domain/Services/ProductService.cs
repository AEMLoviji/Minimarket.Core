using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Repositories;
using Minimarket.API.Domain.Services.Response;

namespace Minimarket.API.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}