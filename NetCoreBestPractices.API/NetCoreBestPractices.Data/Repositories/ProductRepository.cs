using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBestPractices.Core.Models;
using NetCoreBestPractices.Core.Repositories;

namespace NetCoreBestPractices.Data.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        //Repositorydeki işlerin yetmediği durumlarda entitye özel repositoryler oluşturuyoruz.
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsnc(long productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
