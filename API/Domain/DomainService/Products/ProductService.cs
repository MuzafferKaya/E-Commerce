using DomainModel.Entities.Product;
using DomainModel.Extensions;
using DomainModel.Repository;
using DomainModel.UnitOfWork;
using Dto.Request.Product;
using Dto.Response.Product;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Products
{
    public class ProductService(
        IRepositoryBase<Product> repositoryProduct,
        IUnitOfWork unitOfWork) : IProductService
    {
        private readonly IRepositoryBase<Product> _repositoryProduct = repositoryProduct;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddProductAsync(ProductAddRequestDto requestDto)
        {
            await _repositoryProduct.AddAsync(requestDto.ToModel());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedList<ProductGetAllResponseDto>> GetAllProductAsync(
            int pageSize,
            int pageNumber)
        {
            var productsQuery = _repositoryProduct
                .FindAll()
                .Include(p => p.Galleries)
                .AsSplitQuery()
                .Select(p => new ProductGetAllResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Thumbnail = p.Galleries
                        .Where(g => g.IsThumbnail)
                        .Select(g => g.ImagePath)
                        .FirstOrDefault()!
                });

            var products = await PagedList<ProductGetAllResponseDto>
                .ToPagedListAsync(
                    productsQuery,
                    pageNumber,
                    pageSize);

            return products;
        }

        public async Task<Result<ProductGetByIdResponseDto>> GetProductByIdAsync(long productId)
        {
            var product = await _repositoryProduct
                .GetQueryable()
                .Where(p => p.Id == productId)
                .Include(p => p.Galleries)
                .AsSplitQuery()
                .Select(p => new ProductGetByIdResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Galleries = p.Galleries
                        .OrderBy(g => g.DisplayOrder)
                        .Select(g => g.ImagePath)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (product == null)
                return Result.Fail($"ID'si {productId} olan ürün bulunamadı.");

            return Result.Ok(product);
        }

        public async Task<Result> UpdateProductAsync(
            long productId,
            ProductUpdateRequestDto requestDto)
        {
            var product = await _repositoryProduct.GetByIdAsync(productId);
            if (product == null)
                return Result.Fail($"ID'si {productId} olan ürün bulunamadı.");

            product.Name = requestDto.Name;
            product.SKU = requestDto.SKU;
            product.Description = requestDto.Description;
            product.Price = requestDto.Price;
            product.Quantity = requestDto.Quantity;
            product.CategoryId = requestDto.CategoryId;
            product.IsPublished = requestDto.IsPublished;

            product.UpdatedAt = DateTime.UtcNow;

            _repositoryProduct.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> DeleteProductAsync(long productId)
        {
            var product = await _repositoryProduct.GetByIdAsync(productId);
            if (product == null)
                return Result.Fail($"ID'si {productId} olan ürün bulunamadı.");

            product.IsDeleted = true;
            _repositoryProduct.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
