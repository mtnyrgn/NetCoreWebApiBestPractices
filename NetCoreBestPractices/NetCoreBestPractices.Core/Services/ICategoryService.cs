using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        //only about category method,helper,url
        Task<Category> GetWithProductsByIdAsync(long categoryId);
    }
}
