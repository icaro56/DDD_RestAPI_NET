using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using RestAPIModeloDDD.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task Add(TEntity obj)
        {
            await repository.Add(obj);
        }

        public async Task Update(TEntity obj)
        {
            await repository.Update(obj);
        }

        public async Task Remove(TEntity obj)
        {
            await repository.Remove(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> GetEntity(int id)
        {
            return await repository.GetById(id);
        }
    }
}
