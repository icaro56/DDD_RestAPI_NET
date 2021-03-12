using RestAPIModeloDDD.Domain.Entities;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceProduct : IServiceBase<Product>
    {
        Task AddProduct(Product product);

        Task UpdateProduct(Product product);
    }
}
