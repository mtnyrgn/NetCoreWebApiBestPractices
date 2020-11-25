using System;
namespace NetCoreBestPractices.API.DTO
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
