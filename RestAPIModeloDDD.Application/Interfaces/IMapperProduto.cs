using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestAPIModeloDDD.Application.Interfaces
{
    public interface IMapperProduto
    {
        Produto MapperDtoToEntity(ProductDto clienteDto);

        IEnumerable<ProductDto> MapperListProdutosDto(IEnumerable<Produto> clientes);

        ProductDto MapperEntityToDto(Produto cliente);
    }
}
