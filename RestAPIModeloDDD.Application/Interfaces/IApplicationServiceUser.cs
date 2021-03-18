using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceUser : IApplicationServiceBase<UserDTO>
    {
        Task<UserDTO> GetByUsernameAndPassword(string username, string password);
    }
}
