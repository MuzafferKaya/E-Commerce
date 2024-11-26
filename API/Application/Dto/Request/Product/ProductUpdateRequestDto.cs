namespace Dto.Request.Product
{
    public class ProductUpdateRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long CategoryId { get; set; }
        public bool IsPublished { get; set; }
    }
}
