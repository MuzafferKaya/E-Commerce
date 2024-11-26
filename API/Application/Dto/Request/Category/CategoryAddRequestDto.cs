namespace Dto.Request.Category
{
    public class CategoryAddRequestDto
    {
        public long? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public DomainModel.Entities.Product.Category ToModel()
        {
            return new DomainModel.Entities.Product.Category
            {
                ParentId = ParentId,
                Name = Name,
                Description = Description,
                IsActive = IsActive
            };
        }
    }
}
