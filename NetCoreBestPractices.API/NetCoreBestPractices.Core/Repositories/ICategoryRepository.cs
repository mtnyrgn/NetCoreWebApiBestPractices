using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Models;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //only about category query
        Task<Category> GetWithProductsByIdAsync(long categoryId);
    }
}
