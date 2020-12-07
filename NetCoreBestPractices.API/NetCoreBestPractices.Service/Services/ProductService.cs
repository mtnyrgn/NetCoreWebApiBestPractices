using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;

namespace NetCoreBestPractices.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork,IRepository<Product> repository) : base(unitOfWork, repository) { }

        public async Task<Product> GetWithCategoryByIdAsync(long productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsnc(productId);
        }
    }
}
