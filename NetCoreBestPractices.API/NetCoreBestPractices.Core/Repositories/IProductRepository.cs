using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        //only about product query
        Task<Product> GetWithCategoryByIdAsnc(long productId);
    }
}
