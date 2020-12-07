using NetCoreBestPractices.API.DTO.Category;
using System;
namespace NetCoreBestPractices.API.DTO.Product
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
