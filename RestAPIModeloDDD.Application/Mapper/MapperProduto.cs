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
                Price = produtoDto.Valor,
                Active = produtoDto.Ativo
            };

            return produto;
        }

        public ProductDto MapperEntityToDto(Produto produto)
        {
            ProductDto produtoDto = new ProductDto
            {
                Id = produto.Id,
                Nome = produto.Name,
                Valor = produto.Price,
                Ativo = produto.Active
            };

            return produtoDto;
        }

        public IEnumerable<ProductDto> MapperListProdutosDto(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(p => new ProductDto
            {
                Id = p.Id,
                Nome = p.Name,
                Valor = p.Price,
                Ativo = p.Active
            });

            return dto;
        }

        public IEnumerable<Produto> MapperListProdutos(IEnumerable<ProductDto> produtos)
        {
            var entities = produtos.Select(p => new Produto
            {
                Id = p.Id,
                Name = p.Nome,
                Price = p.Valor,
                Active = p.Ativo
            });

            return entities;
        }
    }
}
