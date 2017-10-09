using Commom.Contracts;
using System.Collections.Generic;

namespace Estoque.Domain.Entities
{
    public class Permissao : IEntityBase<int>
    {
        public int Id { get; set; }
        public string NomePermissao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
