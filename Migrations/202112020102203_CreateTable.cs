namespace vexed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
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
                "dbo.CupomDescontos",
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
                "dbo.Grupos",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        NomeGrupo = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.IdGrupo);
            
            CreateTable(
                "dbo.ItemPedidos",
                c => new
                    {
                        IdItemPedido = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        QuantidadeProduto = c.Int(nullable: false),
                        PrecoItemPedido = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdItemPedido)
                .ForeignKey("dbo.Pedidos", t => t.IdPedido, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.IdProduto, cascadeDelete: true)
                .Index(t => t.IdPedido)
                .Index(t => t.IdProduto);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        IdTipoEntrega = c.Int(nullable: false),
                        IdCupomDesconto = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        ValorPedido = c.Double(nullable: false),
                        PedidoPago = c.Boolean(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                        PedidoEnviado = c.Boolean(nullable: false),
                        DataEnvio = c.DateTime(nullable: false),
                        EnvioRastreio = c.String(),
                        PedidoCancelado = c.Boolean(nullable: false),
                        DataCancelamento = c.DateTime(nullable: false),
                        PedidoEntregue = c.Boolean(nullable: false),
                        DataEntrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.CupomDescontos", t => t.IdCupomDesconto, cascadeDelete: true)
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
                "dbo.Produtos",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false),
                        DescricaoProduto = c.String(nullable: false, maxLength: 1000),
                        PrecoProduto = c.Double(nullable: false),
                        Produtostoque = c.Int(nullable: false),
                        ProdutoDisponivel = c.Boolean(nullable: false),
                        IdGrupo = c.Int(nullable: false),
                        GeneroProduto = c.Int(nullable: false),
                        IdFabricante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto)
                .ForeignKey("dbo.Fabricantes", t => t.IdFabricante, cascadeDelete: true)
                .ForeignKey("dbo.Grupos", t => t.IdGrupo, cascadeDelete: true)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdFabricante);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedidos", "IdProduto", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "IdGrupo", "dbo.Grupos");
            DropForeignKey("dbo.Produtos", "IdFabricante", "dbo.Fabricantes");
            DropForeignKey("dbo.ItemPedidos", "IdPedido", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "IdTipoEntrega", "dbo.TipoEntregas");
            DropForeignKey("dbo.Pedidos", "IdCupomDesconto", "dbo.CupomDescontos");
            DropForeignKey("dbo.Pedidos", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Produtos", new[] { "IdFabricante" });
            DropIndex("dbo.Produtos", new[] { "IdGrupo" });
            DropIndex("dbo.Pedidos", new[] { "IdCliente" });
            DropIndex("dbo.Pedidos", new[] { "IdCupomDesconto" });
            DropIndex("dbo.Pedidos", new[] { "IdTipoEntrega" });
            DropIndex("dbo.ItemPedidos", new[] { "IdProduto" });
            DropIndex("dbo.ItemPedidos", new[] { "IdPedido" });
            DropTable("dbo.Produtos");
            DropTable("dbo.TipoEntregas");
            DropTable("dbo.Pedidos");
            DropTable("dbo.ItemPedidos");
            DropTable("dbo.Grupos");
            DropTable("dbo.Fabricantes");
            DropTable("dbo.CupomDescontos");
            DropTable("dbo.Clientes");
        }
    }
}
