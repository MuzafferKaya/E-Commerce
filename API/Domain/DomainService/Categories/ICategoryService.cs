using DomainModel.Extensions;
using Dto.Request.Category;
using Dto.Response.Category;
using FluentResults;

namespace DomainService.Categories
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryAddRequestDto requestDto);
        Task<PagedList<CategoryGetAllResponseDto>> GetAllCategoryAsync(int pageSize, int pageNumber);
        Task<Result<CategoryGetByIdResponseDto>> GetCategoryByIdAsync(long categoryId);
        Task<Result> UpdateCategoryAsync(long categoryId, CategoryUpdateRequestDto requestDto);
        Task<Result> DeleteCategoryAsync(long categoryId);
    }
}
