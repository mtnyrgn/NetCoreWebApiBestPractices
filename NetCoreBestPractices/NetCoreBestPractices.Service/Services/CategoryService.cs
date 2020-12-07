using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;

namespace NetCoreBestPractices.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork,repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(long categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
