using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vexed.Models
{
    public class TipoEntrega
    {
        [Key]
        public int IdTipoEntrega { get; set; }
        public string TipoDeEntrega { get; set; }

    }
}