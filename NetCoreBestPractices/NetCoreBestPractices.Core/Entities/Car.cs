using System;

namespace NetCoreBestPractices.Core.Entities
{
    public class Car
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
