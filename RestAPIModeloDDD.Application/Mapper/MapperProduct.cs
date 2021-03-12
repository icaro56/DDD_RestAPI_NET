using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application.Mapper
{
    public class MapperProduct : IMapperProduct
    {
        public Product MapperDTOToEntity(ProductDto produtoDto)
        {
            Product produto = new Product
            {
                Id = produtoDto.Id,
                Name = produtoDto.Name,
                Price = produtoDto.Price,
                Active = produtoDto.Active
            };

            return produto;
        }

        public ProductDto MapperEntityToDTO(Product produto)
        {
            ProductDto produtoDto = new ProductDto
            {
                Id = produto.Id,
                Name = produto.Name,
                Price = produto.Price,
                Active = produto.Active
            };

            return produtoDto;
        }

        public IEnumerable<ProductDto> MapperListProductsDTO(IEnumerable<Product> produtos)
        {
            var dto = produtos.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Active = p.Active
            });

            return dto;
        }

        public IEnumerable<Product> MapperListProducts(IEnumerable<ProductDto> produtos)
        {
            var entities = produtos.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Active = p.Active
            });

            return entities;
        }
    }
}
