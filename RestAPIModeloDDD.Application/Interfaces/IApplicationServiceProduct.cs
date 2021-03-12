using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceProduct : IApplicationServiceBase<ProductDTO>
    {
        Task AddProduct(Product product);

        Task UpdateProduct(Product product);
    }
}
