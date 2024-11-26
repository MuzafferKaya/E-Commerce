namespace Dto.Response.Product
{
    public class ProductGetByIdResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Galleries { get; set; } = [];
    }
}
