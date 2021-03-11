using System;

namespace RestAPIModeloDDD.Domain.Entities
{
    public class Cliente : Base
    {
        public string  Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
