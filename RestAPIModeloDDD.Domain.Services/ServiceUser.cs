using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using RestAPIModeloDDD.Domain.Core.Interfaces.Services;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser repositoryUser;

        public ServiceUser(IRepositoryUser repository) 
            : base(repository)
        {
            this.repositoryUser = repository;
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await repositoryUser.GetByUsernameAndPassword(username, password);
        }
    }
}
