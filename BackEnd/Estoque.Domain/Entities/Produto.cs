using Commom.Contracts;

namespace Estoque.Domain.Entities
{
    public class Produto : IEntityBase<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
