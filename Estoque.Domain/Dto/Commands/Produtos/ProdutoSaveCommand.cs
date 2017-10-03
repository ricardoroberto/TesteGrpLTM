using Commom.Domain.App;
using Estoque.Domain.Valids.Produtos;

namespace Estoque.Domain.Dto.Commands.Produtos
{
    public class ProdutoSaveCommand : ACommandValidate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public override void AddValidattions()
        {
            this.AddValidation(NomePreenchidoValid.Get(Nome));
        }
    }
}
