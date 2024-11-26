namespace Dto.Response.Category
{
    public class CategoryGetAllResponseDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
