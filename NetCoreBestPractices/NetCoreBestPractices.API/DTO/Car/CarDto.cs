using System.ComponentModel.DataAnnotations;

namespace NetCoreBestPractices.API.DTO.Car
{
    public class CarDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Range(1886, 9999)]
        public int Year { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
