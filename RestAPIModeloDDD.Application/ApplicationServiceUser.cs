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
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser serviceUser;
        private readonly IMapper mapper;

        public ApplicationServiceUser(IServiceUser serviceUser,
                                         IMapper mapper)
        {
            this.serviceUser = serviceUser;
            this.mapper = mapper;
        }

        public async Task Add(UserDTO clientDto)
        {
            var cliente = mapper.Map<User>(clientDto);

            await serviceUser.Add(cliente);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var list = await serviceUser.GetAll();
            var clientesDto = mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(list);

            return clientesDto;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var entity = await serviceUser.GetEntity(id);
            return mapper.Map<UserDTO>(entity);
        }

        public async Task Remove(UserDTO clientDto)
        {
            await serviceUser.Remove(mapper.Map<User>(clientDto));
        }

        public async Task Update(UserDTO clientDto)
        {
            await serviceUser.Update(mapper.Map<User>(clientDto));
        }

        public async Task<UserDTO> GetByUsernameAndPassword(string username, string password)
        {
            var entity = await serviceUser.GetByUsernameAndPassword(username, password);
            return mapper.Map<UserDTO>(entity);
        }
    }
}
