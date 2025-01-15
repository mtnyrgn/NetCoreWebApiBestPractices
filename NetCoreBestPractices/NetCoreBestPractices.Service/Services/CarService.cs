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
    public class CarService : Service<Car>, ICarService
    {
        public CarService(IUnitOfWork unitOfWork, IRepository<Car> repository) : base(unitOfWork, repository) { }
    }
}
