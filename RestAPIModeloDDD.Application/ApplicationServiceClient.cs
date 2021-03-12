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
    public class ApplicationServiceClient : IApplicationServiceClient
    {
        private readonly IServiceClient serviceClient;
        private readonly IMapperClient mapperClient;

        public ApplicationServiceClient(IServiceClient serviceClient,
                                         IMapperClient mapperClient)
        {
            this.serviceClient = serviceClient;
            this.mapperClient = mapperClient;
        }

        public async Task Add(ClientDTO clientDto)
        {
            var cliente = mapperClient.MapperDTOToEntity(clientDto);

            await serviceClient.Add(cliente);
        }

        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            var list = await serviceClient.GetAll();
            var clientesDto = mapperClient.MapperListClientDTO(list);

            return clientesDto;
        }

        public async Task<ClientDTO> GetById(int id)
        {
            var entity = await serviceClient.GetEntity(id);
            return mapperClient.MapperEntityToDTO(entity);
        }

        public async Task Remove(ClientDTO clientDto)
        {
            await serviceClient.Remove(mapperClient.MapperDTOToEntity(clientDto));
        }

        public async Task Update(ClientDTO clientDto)
        {
            await serviceClient.Update(mapperClient.MapperDTOToEntity(clientDto));
        }
    }
}
