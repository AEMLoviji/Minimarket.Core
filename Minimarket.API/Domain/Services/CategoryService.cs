using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Minimarket.API.Domain.Models;
using Minimarket.API.Domain.Repositories;
using Minimarket.API.Domain.Services.Response;

namespace Minimarket.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryOperationResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryOperationResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryOperationResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryOperationResponse> UpdateAsync(int id, Category category)
        {
            var actualCategory = await _categoryRepository.FindByIdAsync(id);
            if (actualCategory == null)
                return new CategoryOperationResponse("Category not found.");

            actualCategory.Name = category.Name;
            try
            {
                _categoryRepository.Update(actualCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryOperationResponse(actualCategory);
            }
            catch (Exception ex)
            {
                return new CategoryOperationResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<CategoryOperationResponse> DeleteAsync(int id)
        {
            var actualCategory = await _categoryRepository.FindByIdAsync(id);
            if (actualCategory == null)
                return new CategoryOperationResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(actualCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryOperationResponse(actualCategory);
            }
            catch (Exception ex)
            {
                return new CategoryOperationResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}