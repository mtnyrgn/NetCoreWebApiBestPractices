using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreBestPractices.API.DTO
{
    public class ProductDto
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        [Required(ErrorMessage ="{0} alanı boş olamaz.")]
        public string Name { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır. ")]
        public double Price { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} alanı 1'den büyük bir değer olmalıdır. ")]
        public long Stock { get; set; }
    }
}
