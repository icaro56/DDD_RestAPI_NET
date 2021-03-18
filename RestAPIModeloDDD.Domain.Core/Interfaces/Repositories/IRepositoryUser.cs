using RestAPIModeloDDD.Domain.Entities;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
