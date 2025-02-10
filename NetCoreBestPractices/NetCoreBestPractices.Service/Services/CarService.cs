using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;

namespace NetCoreBestPractices.Service.Services
{
    public class CarService : Service<Car>, ICarService
    {
        public CarService(IUnitOfWork unitOfWork, IRepository<Car> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Car> GetByIdAsync(long id)
        {
            return await _unitOfWork.Cars.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _unitOfWork.Cars.GetAllAsync();
        }

        public async Task<Car> AddAsync(Car car)
        {
            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.CommitAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> cars)
        {
            await _unitOfWork.Cars.AddRangeAsync(cars);
            await _unitOfWork.CommitAsync();
            return cars;
        }

        public void Remove(Car car)
        {
            _unitOfWork.Cars.Remove(car);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<Car> cars)
        {
            _unitOfWork.Cars.RemoveRange(cars);
            _unitOfWork.Commit();
        }

        public Car Update(Car car)
        {
            var updatedCar = _unitOfWork.Cars.Update(car);
            _unitOfWork.Commit();
            return updatedCar;
        }
    }
}
