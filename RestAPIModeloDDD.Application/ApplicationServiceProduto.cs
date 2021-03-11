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
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto serviceProduto;
        private readonly IMapperProduto mapperProduto;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
        {
            this.serviceProduto = serviceProduto;
            this.mapperProduto = mapperProduto;
        }

        public async Task Add(ProductDto productDto)
        {
            await serviceProduto.Add(mapperProduto.MapperDtoToEntity(productDto));
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var list = await serviceProduto.GetAll();
            return mapperProduto.MapperListProdutosDto(list);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var entity = await serviceProduto.GetEntity(id);
            return mapperProduto.MapperEntityToDto(entity);
        }

        public async Task Remove(ProductDto productDto)
        {
            await serviceProduto.Remove(mapperProduto.MapperDtoToEntity(productDto));
        }

        public async Task Update(ProductDto productDto)
        {
            await serviceProduto.Update(mapperProduto.MapperDtoToEntity(productDto));
        }
    }
}
