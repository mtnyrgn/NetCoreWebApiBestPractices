using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Core.Services
{
    public interface ICarService : IService<Car>
    {
        Task<Car> GetByIdAsync(long id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> AddAsync(Car car);
        Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> cars);
        void Remove(Car car);
        void RemoveRange(IEnumerable<Car> cars);
        Car Update(Car car);
    }
}
