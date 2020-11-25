using System;
using System.Collections.Generic;

namespace NetCoreBestPractices.API.DTO
{
    public class CateegoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
