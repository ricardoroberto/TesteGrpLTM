using Estoque.Domain.Entities;
using System.Data.Entity;

namespace Estoque.Infra.Data.Sql.Context
{
    public class EstoqueContext: DbContext
    {

        //public EstoqueContext() : base(ConfigurationManager.ConnectionStrings["EstoqueSql"].ConnectionString)
        //{
        //}
        public EstoqueContext() : base("Server=213.136.77.39;Database=Estoque;User Id = Estoque; Password=35t0qu3")
        {
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCompra> Compras { get; set; }
        public DbSet<ProdutoEstoque> Estoques { get; set; }
        public DbSet<ProdutoVenda> Vendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
                        .HasMany<Permissao>(s => s.Permissoes)
                        .WithMany(c => c.Usuarios)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("IdUsuario");
                            cs.MapRightKey("IdPermissao");
                            cs.ToTable("UsuarioPermissao");
                        });

        }
    }
}
