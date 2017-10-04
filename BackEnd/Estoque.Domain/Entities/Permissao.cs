using Commom.Contracts;

namespace Estoque.Domain.Entities
{
    public class Permissao : IEntityBase<int>
    {
        public int Id { get; set; }
        public string NomePermissao { get; set; }
    }
}
