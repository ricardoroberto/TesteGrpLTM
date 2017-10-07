using Estoque.Domain.Contracts.AppServices;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Dto.Commands.Produtos;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Estoque.Service
{
    public class AppServiceProduto : IAppServiceProduto
    {
        private readonly IRepositoryProduto _repProduto;

        public AppServiceProduto(IRepositoryProduto repProduto)
        {
            this._repProduto = repProduto;
        }

        public IEnumerable<Produto> Listar(ProdutoListarCommand filtroLista)
        {
            IEnumerable<Produto> list = null;
            if (String.IsNullOrEmpty(filtroLista?.NomeFiltro))
                list = _repProduto.GetAll();
            else
                list = _repProduto.GetIniciadoPorNome(filtroLista.NomeFiltro);

            return list;
        }

        public void Save(ProdutoSaveCommand produto)
        {
            throw new NotImplementedException();
        }
    }
}
