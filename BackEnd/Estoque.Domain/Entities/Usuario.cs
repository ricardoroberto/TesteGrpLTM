using Commom.Contracts;
using System.Collections.Generic;

namespace Estoque.Domain.Entities
{
    public class Usuario : IEntityBase<string>
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        //Ideal criptografar. Mas não neste momento
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
