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
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDtoToEntity(ProductDto produtoDto)
        {
            Produto produto = new Produto
            {
                Id = produtoDto.Id,
                Name = produtoDto.Nome,
                Price = produtoDto.Valor
            };

            return produto;
        }

        public ProductDto MapperEntityToDto(Produto produto)
        {
            ProductDto produtoDto = new ProductDto
            {
                Id = produto.Id,
                Nome = produto.Name,
                Valor = produto.Price
            };

            return produtoDto;
        }

        public IEnumerable<ProductDto> MapperListProdutosDto(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(p => new ProductDto
            {
                Id = p.Id,
                Nome = p.Name,
                Valor = p.Price
            });

            return dto;
        }
    }
}
