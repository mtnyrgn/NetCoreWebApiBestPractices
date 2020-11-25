using System;
namespace NetCoreBestPractices.API.DTO
{
    public class ProductDto
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long Stock { get; set; }
    }
}
