using Estoque.Domain.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Estoque.Infra.Data.Sql.Context
{
    public class EstoqueContext: DbContext
    {
        public EstoqueContext() : base(ConfigurationManager.AppSettings["CONEXAO_DB"])
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCompra> Compras { get; set; }
        public DbSet<ProdutoEstoque> Estoques { get; set; }
        public DbSet<ProdutoVenda> Vendas { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
    }
}
