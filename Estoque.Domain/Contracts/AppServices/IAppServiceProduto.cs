using Estoque.Domain.Dto.Commands.Produtos;
using Estoque.Domain.Entities;
using System.Collections.Generic;

namespace Estoque.Domain.Contracts.AppServices
{
    public interface IAppServiceProduto
    {
        void Save(ProdutoSaveCommand produto);
        IEnumerable<Produto> Listar(ProdutoListarCommand filtroLista);
    }
}
