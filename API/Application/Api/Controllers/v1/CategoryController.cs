using DomainService.Categories;
using Dto.Request;
using Dto.Request.Category;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.v1
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryAddRequestDto requestDto)
        {
            await _categoryService.AddCategoryAsync(requestDto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery] QueryStringParameters parameters)
        {
            var categories = await _categoryService.GetAllCategoryAsync(
                parameters.PageSize,
                parameters.PageNumber);

            var metadata = new
            {
                categories.TotalCount,
                categories.PageSize,
                categories.CurrentPage,
                categories.TotalPages,
                categories.HasNext,
                categories.HasPrevious
            };

            Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(metadata);
            return Ok(categories);
        }

        [HttpGet("{categoryId:long}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] long categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            return category switch
            {
                { IsSuccess: true } => Ok(category.Value),
                _ => NotFound(category.Errors)
            };
        }

        [HttpPut("{categoryId:long}")]
        public async Task<IActionResult> UpdateCategory(
            [FromRoute] long categoryId,
            [FromBody] CategoryUpdateRequestDto requestDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(categoryId, requestDto);

            return result switch
            {
                { IsSuccess: true } => NoContent(),
                _ => NotFound(result.Errors)
            };
        }

        [HttpDelete("{categoryId:long}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long categoryId)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId);
            return result switch
            {
                { IsSuccess: true } => NoContent(),
                _ => NotFound(result.Errors)
            };
        }
    }
}
