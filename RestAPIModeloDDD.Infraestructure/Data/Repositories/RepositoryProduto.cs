using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        /*private readonly SqlContext sqlContext;

        public RepositoryProduto(SqlContext sqlContext)
            : base (sqlContext)
        {
            this.sqlContext = sqlContext;
        }*/
    }
}
