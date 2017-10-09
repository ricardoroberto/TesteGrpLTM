namespace Estoque.Infra.Data.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DhCompra = c.DateTime(nullable: false),
                        ValorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdCompra = c.Int(nullable: false),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdMinima = c.Int(),
                        QtdInicial = c.Int(),
                        QtdAtual = c.Int(),
                        DhAtualizado = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePermissao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Senha = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DhVenda = c.DateTime(nullable: false),
                        ValorTotalDia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdVenda = c.Int(nullable: false),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.UsuarioPermissao",
                c => new
                    {
                        IdUsuario = c.String(nullable: false, maxLength: 128),
                        IdPermissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdUsuario, t.IdPermissao })
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Permissaos", t => t.IdPermissao, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdPermissao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoVendas", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.UsuarioPermissao", "IdPermissao", "dbo.Permissaos");
            DropForeignKey("dbo.UsuarioPermissao", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.ProdutoCompras", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.UsuarioPermissao", new[] { "IdPermissao" });
            DropIndex("dbo.UsuarioPermissao", new[] { "IdUsuario" });
            DropIndex("dbo.ProdutoVendas", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoCompras", new[] { "Produto_Id" });
            DropTable("dbo.UsuarioPermissao");
            DropTable("dbo.ProdutoVendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Permissaos");
            DropTable("dbo.Produtoes");
            DropTable("dbo.ProdutoCompras");
        }
    }
}
