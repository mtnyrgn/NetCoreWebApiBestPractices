using System;

namespace NetCoreBestPractices.Core.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
