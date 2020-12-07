using NetCoreBestPractices.API.DTO.Product;
using System;
using System.Collections.Generic;

namespace NetCoreBestPractices.API.DTO.Category
{
    public class CateegoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
