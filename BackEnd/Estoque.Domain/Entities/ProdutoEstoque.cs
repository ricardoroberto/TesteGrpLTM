using System;

namespace Estoque.Domain.Entities
{
    public class ProdutoEstoque : Produto
    {
        public int QtdMinima { get; set; }
        public int QtdInicial { get; set; }
        public int QtdAtual { get; set; }
        public DateTime DhAtualizado { get; set; } 
    }
}
