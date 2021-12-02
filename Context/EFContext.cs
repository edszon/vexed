using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Entity;
using vexed.Models;

namespace vexed.Context
{
    public class Connection
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["VexedContext"].ConnectionString;
    }

    public class EFContext:DbContext
    {
        public EFContext() : base(Connection.connectString) { }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<CupomDesconto> cupom_desconto { get; set; }
        public DbSet<Fabricante> fabricante { get; set; }
        public DbSet<Grupo> grupo { get; set; }
        public DbSet<ItemPedido> item_pedido { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Produto> produto { get; set; }
        public DbSet<TipoEntrega> tipo_entrega { get; set; }

    }
}