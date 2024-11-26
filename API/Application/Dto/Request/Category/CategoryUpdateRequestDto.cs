﻿namespace Dto.Request.Category
{
    public class CategoryUpdateRequestDto
    {
        public long? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
