using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Models;

namespace NetCoreBestPractices.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //bool ControlInnerBarcode(Product product)
        Task<Product> GetWithCategoryByIdAsnc(long productId);
    }
}
