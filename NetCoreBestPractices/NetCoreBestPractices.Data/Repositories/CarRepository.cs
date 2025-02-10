using System.Collections.Generic;
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

        public async Task<Car> GetByIdAsync(long id)
        {
            return await _appDbContext.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _appDbContext.Cars.ToListAsync();
        }

        public async Task AddAsync(Car car)
        {
            await _appDbContext.Cars.AddAsync(car);
        }

        public async Task AddRangeAsync(IEnumerable<Car> cars)
        {
            await _appDbContext.Cars.AddRangeAsync(cars);
        }

        public void Remove(Car car)
        {
            _appDbContext.Cars.Remove(car);
        }

        public void RemoveRange(IEnumerable<Car> cars)
        {
            _appDbContext.Cars.RemoveRange(cars);
        }

        public Car Update(Car car)
        {
            _appDbContext.Cars.Update(car);
            return car;
        }
    }
}
