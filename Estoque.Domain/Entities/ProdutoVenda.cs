using System;

namespace Estoque.Domain.Entities
{
    public class ProdutoVenda
    {
        public int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public DateTime DhVenda { get; set; }
        public decimal ValorTotalDia { get; set; }
        public int QtdVenda { get; set; }
    }
}
