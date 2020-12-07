using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //bool ControlInnerBarcode(Product product)
        Task<Product> GetWithCategoryByIdAsync(long productId);
    }
}
