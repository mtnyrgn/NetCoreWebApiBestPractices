using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetByIdAsync(long id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car car);
        Task AddRangeAsync(IEnumerable<Car> cars);
        void Remove(Car car);
        void RemoveRange(IEnumerable<Car> cars);
        Car Update(Car car);
    }
}
