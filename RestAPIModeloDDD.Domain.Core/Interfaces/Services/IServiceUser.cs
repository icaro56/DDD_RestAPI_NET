using RestAPIModeloDDD.Domain.Entities;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceUser : IServiceBase<User>
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
        
    }
}
