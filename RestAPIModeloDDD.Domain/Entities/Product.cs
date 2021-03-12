
using System.ComponentModel.DataAnnotations;

namespace RestAPIModeloDDD.Domain.Entities
{
    public class Product : Base
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
    }
}
