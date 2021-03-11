
using System.ComponentModel.DataAnnotations;

namespace RestAPIModeloDDD.Domain.Entities
{
    public class Produto : Base
    {
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }
    }
}
