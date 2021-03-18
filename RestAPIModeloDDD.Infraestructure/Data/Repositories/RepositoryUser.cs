using Microsoft.EntityFrameworkCore;
using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.Data.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                return await data.Users.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(username.ToLower()) && a.Password.Equals(password));
            }
        }
    }
}
