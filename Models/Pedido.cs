using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required]
        [ForeignKey("TipoEntrega")]
        public int IdTipoEntrega { get; set; }
        public TipoEntrega TipoEntrega { get; set; }

        [ForeignKey("CupomDesconto")]
        public int IdCupomDesconto { get; set; }
        public CupomDesconto CupomDesconto { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        
        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public double ValorPedido { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool PedidoPago { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool PedidoEnviado { get; set; }

        public DateTime? DataEnvio { get; set; }

        public string EnvioRastreio { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool PedidoCancelado { get; set; }

        public DateTime? DataCancelamento { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool PedidoEntregue { get; set; }

        public DateTime? DataEntrega { get; set; }

    }
}