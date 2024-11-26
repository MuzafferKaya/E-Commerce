namespace Dto.Response.Product
{
    public class ProductGetAllResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Thumbnail { get; set; } = string.Empty;
    }
}
