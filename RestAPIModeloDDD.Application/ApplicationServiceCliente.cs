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
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapperCliente mapperCliente;

        public ApplicationServiceCliente(IServiceCliente serviceCliente,
                                         IMapperCliente mapperCliente)
        {
            this.serviceCliente = serviceCliente;
            this.mapperCliente = mapperCliente;
        }

        public async Task Add(ClienteDto clienteDto)
        {
            var cliente = mapperCliente.MapperDtoToEntity(clienteDto);

            await serviceCliente.Add(cliente);
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var list = await serviceCliente.GetAll();
            var clientesDto = mapperCliente.MapperListClienteDto(list);

            return clientesDto;
        }

        public async Task<ClienteDto> GetById(int id)
        {
            var entity = await serviceCliente.GetEntity(id);
            return mapperCliente.MapperEntityToDto(entity);
        }

        public async Task Remove(ClienteDto clienteDto)
        {
            await serviceCliente.Remove(mapperCliente.MapperDtoToEntity(clienteDto));
        }

        public async Task Update(ClienteDto clienteDto)
        {
            await serviceCliente.Update(mapperCliente.MapperDtoToEntity(clienteDto));
        }
    }
}
