using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application.Interfaces
{
    public interface IMapperClient
    {
        Client MapperDTOToEntity(ClientDTO clientDto);

        IEnumerable<ClientDTO> MapperListClientDTO(IEnumerable<Client> clients);

        ClientDTO MapperEntityToDTO(Client client);

        IEnumerable<Client> MapperListClient(IEnumerable<ClientDTO> clients);
    }
}
