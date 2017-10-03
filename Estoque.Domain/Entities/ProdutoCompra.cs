using Commom.Contracts;
using System;

namespace Estoque.Domain.Entities
{
    public class ProdutoCompra : IEntityBase<int>
    {
        public int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public DateTime DhCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public int QtdCompra { get; set; }
    }
}
