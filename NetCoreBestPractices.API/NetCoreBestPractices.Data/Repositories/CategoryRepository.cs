using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBestPractices.Core.Models;
using NetCoreBestPractices.Core.Repositories;

namespace NetCoreBestPractices.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        //Repositorydeki işlerin yetmediği durumlarda entitye özel repositoryler oluşturuyoruz.
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(long categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(s => s.Id == categoryId);
        }
    }
}
