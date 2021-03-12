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
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        public ServiceProduct(IRepositoryBase<Product> repository) 
            : base(repository)
        {
        }

        public async Task AddProduct(Product product)
        {
            var validateName = product.ValidatePropertyString(product.Name, "Nome");
            var validatePrice = product.ValidatePropertyDecimal(product.Price, "Preço");
        
            if (validateName && validatePrice)
            {
                product.Active = true;

                await repository.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validateName = product.ValidatePropertyString(product.Name, "Nome");
            var validatePrice = product.ValidatePropertyDecimal(product.Price, "Preço");

            if (validateName && validatePrice)
            {
                await repository.Update(product);
            }
        }
    }
}
