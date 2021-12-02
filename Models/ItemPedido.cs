using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItemPedido { get; set; }

        [Required]
        [ForeignKey ("Pedido")]
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        [Required]
        public double PrecoItemPedido { get; set; }


    }
}