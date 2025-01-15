using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Repositories;

namespace NetCoreBestPractices.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CarRepository(AppDbContext context) : base(context)
        {
        }
    }
}
