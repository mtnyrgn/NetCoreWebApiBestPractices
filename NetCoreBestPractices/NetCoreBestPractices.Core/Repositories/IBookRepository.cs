using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(long id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Remove(Book book);
    }
}
