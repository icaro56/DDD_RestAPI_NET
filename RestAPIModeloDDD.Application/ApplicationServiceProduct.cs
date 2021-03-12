using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;
using RestAPIModeloDDD.Domain.Core.Interfaces.Services;
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
        private readonly IMapperProduct mapperProduct;

        public ApplicationServiceProduct(IServiceProduct serviceProduct, IMapperProduct mapperProduct)
        {
            this.serviceProduct = serviceProduct;
            this.mapperProduct = mapperProduct;
        }

        public async Task Add(ProductDto productDto)
        {
            await serviceProduct.Add(mapperProduct.MapperDTOToEntity(productDto));
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var list = await serviceProduct.GetAll();
            return mapperProduct.MapperListProductsDTO(list);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var entity = await serviceProduct.GetEntity(id);
            return mapperProduct.MapperEntityToDTO(entity);
        }

        public async Task Remove(ProductDto productDto)
        {
            await serviceProduct.Remove(mapperProduct.MapperDTOToEntity(productDto));
        }

        public async Task Update(ProductDto productDto)
        {
            await serviceProduct.Update(mapperProduct.MapperDTOToEntity(productDto));
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
