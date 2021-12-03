namespace vexed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Login = c.String(nullable: false, maxLength: 32),
                        Senha = c.String(nullable: false, maxLength: 64),
                        Endereco = c.String(nullable: false),
                        CEP = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.CupomDescontoes",
                c => new
                    {
                        IdCupomDesconto = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 128),
                        PercentualDesconto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCupomDesconto);
            
            CreateTable(
                "dbo.Fabricantes",
                c => new
                    {
                        IdFabricante = c.Int(nullable: false, identity: true),
                        NomeFabricante = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.IdFabricante);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        NomeGrupo = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.IdGrupo);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        IdItemPedido = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        QuantidadeProduto = c.Int(nullable: false),
                        PrecoItemPedido = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdItemPedido)
                .ForeignKey("dbo.Pedidoes", t => t.IdPedido, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.IdProduto, cascadeDelete: true)
                .Index(t => t.IdPedido)
                .Index(t => t.IdProduto);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        IdTipoEntrega = c.Int(nullable: false),
                        IdCupomDesconto = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        ValorPedido = c.Double(nullable: false),
                        PedidoPago = c.Boolean(nullable: false),
                        DataPagamento = c.DateTime(),
                        PedidoEnviado = c.Boolean(nullable: false),
                        DataEnvio = c.DateTime(),
                        EnvioRastreio = c.String(),
                        PedidoCancelado = c.Boolean(nullable: false),
                        DataCancelamento = c.DateTime(),
                        PedidoEntregue = c.Boolean(nullable: false),
                        DataEntrega = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.CupomDescontoes", t => t.IdCupomDesconto, cascadeDelete: true)
                .ForeignKey("dbo.TipoEntregas", t => t.IdTipoEntrega, cascadeDelete: true)
                .Index(t => t.IdTipoEntrega)
                .Index(t => t.IdCupomDesconto)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.TipoEntregas",
                c => new
                    {
                        IdTipoEntrega = c.Int(nullable: false, identity: true),
                        TipoDeEntrega = c.String(),
                    })
                .PrimaryKey(t => t.IdTipoEntrega);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false),
                        DescricaoProduto = c.String(nullable: false, maxLength: 1000),
                        PrecoProduto = c.Double(nullable: false),
                        ProdutoEstoque = c.Int(nullable: false),
                        ProdutoDisponivel = c.Boolean(nullable: false),
                        IdGrupo = c.Int(nullable: false),
                        GeneroProduto = c.Int(nullable: false),
                        IdFabricante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto)
                .ForeignKey("dbo.Fabricantes", t => t.IdFabricante, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.IdGrupo, cascadeDelete: true)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdFabricante);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedidoes", "IdProduto", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "IdGrupo", "dbo.Grupoes");
            DropForeignKey("dbo.Produtoes", "IdFabricante", "dbo.Fabricantes");
            DropForeignKey("dbo.ItemPedidoes", "IdPedido", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "IdTipoEntrega", "dbo.TipoEntregas");
            DropForeignKey("dbo.Pedidoes", "IdCupomDesconto", "dbo.CupomDescontoes");
            DropForeignKey("dbo.Pedidoes", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Produtoes", new[] { "IdFabricante" });
            DropIndex("dbo.Produtoes", new[] { "IdGrupo" });
            DropIndex("dbo.Pedidoes", new[] { "IdCliente" });
            DropIndex("dbo.Pedidoes", new[] { "IdCupomDesconto" });
            DropIndex("dbo.Pedidoes", new[] { "IdTipoEntrega" });
            DropIndex("dbo.ItemPedidoes", new[] { "IdProduto" });
            DropIndex("dbo.ItemPedidoes", new[] { "IdPedido" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.TipoEntregas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.Grupoes");
            DropTable("dbo.Fabricantes");
            DropTable("dbo.CupomDescontoes");
            DropTable("dbo.Clientes");
        }
    }
}
