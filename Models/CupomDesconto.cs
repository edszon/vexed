using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class CupomDesconto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCupomDesconto { get; set; }

        [Required]
        [MaxLength(128)]
        public string Descricao { get; set; }

        [Required]
        public int PercentualDesconto { get; set; }
        
    }
}