namespace Dto.Request.Product
{
    public class ProductAddRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long CategoryId { get; set; }
        public bool IsPublished { get; set; }

        public DomainModel.Entities.Product.Product ToModel()
        {
            return new DomainModel.Entities.Product.Product
            {
                Name = Name,
                SKU = SKU,
                Description = Description,
                Price = Price,
                Quantity = Quantity,
                CategoryId = CategoryId,
                IsPublished = IsPublished,
            };
        }
    }
}
