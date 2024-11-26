using DomainService.Products;
using Dto.Request;
using Dto.Request.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.v1
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddRequestDto requestDto)
        {
            await _productService.AddProductAsync(requestDto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] QueryStringParameters parameters)
        {
            var products = await _productService.GetAllProductAsync(
                parameters.PageSize,
                parameters.PageNumber);

            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };

            Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(metadata);
            return Ok(products);
        }

        [HttpGet("{productId:long}")]
        public async Task<IActionResult> GetProductById([FromRoute] long productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            return product switch
            {
                { IsSuccess: true } => Ok(product.Value),
                _ => NotFound(product.Errors)
            };
        }

        [HttpPut("{productId:long}")]
        public async Task<IActionResult> UpdateProduct(
            [FromRoute] long productId,
            [FromBody] ProductUpdateRequestDto requestDto)
        {
            var result = await _productService.UpdateProductAsync(productId, requestDto);

            return result switch
            {
                { IsSuccess: true } => NoContent(),
                _ => NotFound(result.Errors)
            };
        }

        [HttpDelete("{productId:long}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long productId)
        {
            var result = await _productService.DeleteProductAsync(productId);
            return result switch
            {
                { IsSuccess: true } => NoContent(),
                _ => NotFound(result.Errors)
            };
        }
    }
}
