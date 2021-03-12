using AutoMapper;
using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;
using RestAPIModeloDDD.Domain.Core.Interfaces.Services;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IServiceProduct serviceProduct;
        private readonly IMapper mapper;

        public ApplicationServiceProduct(IServiceProduct serviceProduct, IMapper mapper)
        {
            this.serviceProduct = serviceProduct;
            this.mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            await serviceProduct.Add(mapper.Map<Product>(productDto));
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var list = await serviceProduct.GetAll();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(list);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var entity = await serviceProduct.GetEntity(id);
            return mapper.Map<ProductDTO>(entity);
        }

        public async Task Remove(ProductDTO productDto)
        {
            await serviceProduct.Remove(mapper.Map<Product>(productDto));
        }

        public async Task Update(ProductDTO productDto)
        {
            await serviceProduct.Update(mapper.Map<Product>(productDto));
        }

        public async Task AddProduct(Domain.Entities.Product product)
        {
            await serviceProduct.AddProduct(product);
        }

        public async Task UpdateProduct(Domain.Entities.Product product)
        {
            await serviceProduct.UpdateProduct(product);
        }
    }
}
