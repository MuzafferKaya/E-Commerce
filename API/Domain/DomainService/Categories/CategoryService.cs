using DomainModel.Entities.Product;
using DomainModel.Extensions;
using DomainModel.Repository;
using DomainModel.UnitOfWork;
using Dto.Request.Category;
using Dto.Response.Category;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Categories
{
    public class CategoryService(
        IRepositoryBase<Category> repositoryCategory,
        IUnitOfWork unitOfWork) : ICategoryService
    {
        private readonly IRepositoryBase<Category> _repositoryCategory = repositoryCategory;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddCategoryAsync(CategoryAddRequestDto requestDto)
        {
            await _repositoryCategory.AddAsync(requestDto.ToModel());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedList<CategoryGetAllResponseDto>> GetAllCategoryAsync(
            int pageSize,
            int pageNumber)
        {
            var categoriesQuery = _repositoryCategory
                .FindAll()
                .Select(c => new CategoryGetAllResponseDto
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive
                });

            var categories = await PagedList<CategoryGetAllResponseDto>
                .ToPagedListAsync(
                    categoriesQuery,
                    pageNumber,
                    pageSize);

            return categories;
        }

        public async Task<Result<CategoryGetByIdResponseDto>> GetCategoryByIdAsync(long categoryId)
        {
            var category = await _repositoryCategory
                .GetQueryable()
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryGetByIdResponseDto
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive
                })
                .FirstOrDefaultAsync();

            if (category == null)
                return Result.Fail($"ID'si {categoryId} olan kategori bulunamadı.");

            return Result.Ok(category);
        }

        public async Task<Result> UpdateCategoryAsync(
            long categoryId, 
            CategoryUpdateRequestDto requestDto)
        {
            var category = await _repositoryCategory.GetByIdAsync(categoryId);
            if (category == null)
                return Result.Fail($"ID'si {categoryId} olan kategori bulunamadı.");

            category.ParentId = requestDto.ParentId;
            category.Name = requestDto.Name;
            category.Description = requestDto.Description;
            category.IsActive = requestDto.IsActive;

            category.UpdatedAt = DateTime.UtcNow;

            _repositoryCategory.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> DeleteCategoryAsync(long categoryId)
        {
            var category = await _repositoryCategory.GetByIdAsync(categoryId);
            if (category == null)
                return Result.Fail($"ID'si {categoryId} olan kategori bulunamadı.");

            category.IsDeleted = true;
            _repositoryCategory.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
