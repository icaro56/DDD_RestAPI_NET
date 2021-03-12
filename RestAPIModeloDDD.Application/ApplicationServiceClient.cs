using AutoMapper;
using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;
using RestAPIModeloDDD.Domain.Core.Interfaces.Services;
using RestAPIModeloDDD.Domain.Entities;
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
        private readonly IMapper mapper;

        public ApplicationServiceClient(IServiceClient serviceClient,
                                         IMapper mapper)
        {
            this.serviceClient = serviceClient;
            this.mapper = mapper;
        }

        public async Task Add(ClientDTO clientDto)
        {
            var cliente = mapper.Map<Client>(clientDto);

            await serviceClient.Add(cliente);
        }

        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            var list = await serviceClient.GetAll();
            var clientesDto = mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(list);

            return clientesDto;
        }

        public async Task<ClientDTO> GetById(int id)
        {
            var entity = await serviceClient.GetEntity(id);
            return mapper.Map<ClientDTO>(entity);
        }

        public async Task Remove(ClientDTO clientDto)
        {
            await serviceClient.Remove(mapper.Map<Client>(clientDto));
        }

        public async Task Update(ClientDTO clientDto)
        {
            await serviceClient.Update(mapper.Map<Client>(clientDto));
        }
    }
}
