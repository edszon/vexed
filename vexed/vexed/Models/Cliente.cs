using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [MaxLength(32)]
        public string Login { get; set; }

        [Required]
        [MaxLength(64)]
        public string Senha { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }
    }
}