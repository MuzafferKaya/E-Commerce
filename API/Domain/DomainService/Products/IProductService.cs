using DomainModel.Extensions;
using Dto.Request.Product;
using Dto.Response.Product;
using FluentResults;

namespace DomainService.Products
{
    public interface IProductService
    {
        Task AddProductAsync(ProductAddRequestDto requestDto);
        Task<PagedList<ProductGetAllResponseDto>> GetAllProductAsync(int pageSize, int pageNumber);
        Task<Result<ProductGetByIdResponseDto>> GetProductByIdAsync(long productId);
        Task<Result> UpdateProductAsync(long productId, ProductUpdateRequestDto requestDto);
        Task<Result> DeleteProductAsync(long productId);
    }
}
