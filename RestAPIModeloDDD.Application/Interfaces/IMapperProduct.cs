using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestAPIModeloDDD.Application.Interfaces
{
    public interface IMapperProduct
    {
        Product MapperDTOToEntity(ProductDto productDto);

        IEnumerable<ProductDto> MapperListProductsDTO(IEnumerable<Product> products);

        ProductDto MapperEntityToDTO(Product product);

        IEnumerable<Product> MapperListProducts(IEnumerable<ProductDto> productDtos);
    }
}
