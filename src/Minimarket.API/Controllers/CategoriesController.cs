using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minimarket.API.Domain.Models;
using Minimarket.API.ViewModels;
using Minimarket.API.Domain.Services;
using Minimarket.API.Extensions;
using AutoMapper;

namespace Minimarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryViewModel, Category>(request);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryViewModel>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryViewModel resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryViewModel, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryViewModel>(result.Category);
            return Ok(categoryResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}