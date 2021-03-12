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
    public class MapperCliente : IMapperCliente
    {
        //IEnumerable<ClienteDto> clienteDtos = new List<ClienteDto>();

        public Cliente MapperDtoToEntity(ClienteDto clienteDto)
        {
            Cliente cliente = new Cliente
            {
                Id = clienteDto.Id,
                Name = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                Email = clienteDto.Email,
                Ativo = clienteDto.Ativo
            };

            return cliente;
        }

        public ClienteDto MapperEntityToDto(Cliente cliente)
        {
            ClienteDto clienteDto = new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Name,
                Sobrenome = cliente.Sobrenome,
                Email = cliente.Email,
                Ativo = cliente.Ativo
            };

            return clienteDto;
        }

        public IEnumerable<ClienteDto> MapperListClienteDto(IEnumerable<Cliente> clientes)
        {
            var dto = clientes.Select(c => new ClienteDto 
            { 
                Id = c.Id, 
                Nome = c.Name, 
                Sobrenome = c.Sobrenome, 
                Email = c.Email,
                Ativo = c.Ativo
            });

            return dto;
        }

        public IEnumerable<Cliente> MapperListCliente(IEnumerable<ClienteDto> clientes)
        {
            var entities = clientes.Select(c => new Cliente
            {
                Id = c.Id,
                Name = c.Nome,
                Sobrenome = c.Sobrenome,
                Email = c.Email,
                Ativo = c.Ativo
            });

            return entities;
        }
    }
}
