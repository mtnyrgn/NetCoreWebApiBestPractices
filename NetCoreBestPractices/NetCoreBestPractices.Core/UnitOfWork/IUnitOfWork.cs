using System;
using System.Threading.Tasks;
using NetCoreBestPractices.Core.Repositories;

namespace NetCoreBestPractices.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; } //DI yerine burada oluşturmak best practices olarak daha doğru
        Task CommitAsync();
        void Commit();
    }
}
