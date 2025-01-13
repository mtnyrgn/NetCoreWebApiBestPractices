using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;

namespace NetCoreBestPractices.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;

        public BookService(IUnitOfWork unitOfWork, IBookRepository bookRepository)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
            await _unitOfWork.CommitAsync();
            return book;
        }

        public Book Update(Book book)
        {
            _bookRepository.Update(book);
            _unitOfWork.Commit();
            return book;
        }

        public void Remove(Book book)
        {
            _bookRepository.Remove(book);
            _unitOfWork.Commit();
        }
    }
}
