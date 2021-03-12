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
    public class MapperClient : IMapperClient
    {
        public Client MapperDTOToEntity(ClientDTO clienteDto)
        {
            Client cliente = new Client
            {
                Id = clienteDto.Id,
                Name = clienteDto.Name,
                LastName = clienteDto.LastName,
                Email = clienteDto.Email,
                Active = clienteDto.Active
            };

            return cliente;
        }

        public ClientDTO MapperEntityToDTO(Client cliente)
        {
            ClientDTO clienteDto = new ClientDTO
            {
                Id = cliente.Id,
                Name = cliente.Name,
                LastName = cliente.LastName,
                Email = cliente.Email,
                Active = cliente.Active
            };

            return clienteDto;
        }

        public IEnumerable<ClientDTO> MapperListClientDTO(IEnumerable<Client> clientes)
        {
            var dto = clientes.Select(c => new ClientDTO 
            { 
                Id = c.Id, 
                Name = c.Name, 
                LastName = c.LastName, 
                Email = c.Email,
                Active = c.Active
            });

            return dto;
        }

        public IEnumerable<Client> MapperListClient(IEnumerable<ClientDTO> clientes)
        {
            var entities = clientes.Select(c => new Client
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Email = c.Email,
                Active = c.Active
            });

            return entities;
        }
    }
}
