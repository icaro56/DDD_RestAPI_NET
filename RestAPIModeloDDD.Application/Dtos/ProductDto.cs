using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }
    }
}
