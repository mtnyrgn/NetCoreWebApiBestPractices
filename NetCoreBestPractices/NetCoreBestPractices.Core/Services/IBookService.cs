using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(long id);
        Task<Book> AddAsync(Book book);
        Book Update(Book book);
        void Remove(Book book);
    }
}
