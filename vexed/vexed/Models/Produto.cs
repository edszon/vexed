using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        [MaxLength(1000)]
        public string DescricaoProduto { get; set; }

        [Required]
        public double PrecoProduto { get; set; }

        [Required]
        [DefaultValue(0)]
        public int ProdutoEstoque { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool ProdutoDisponivel { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [Required]
        public int GeneroProduto { get; set; }

        [Required]
        public int IdFabricante { get; set; }
    }
}