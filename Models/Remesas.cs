using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PARCIAL.Models
{
    public class Remesas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string? nombreRemesa { get; set; }

        public string? nombreDestinatario { get; set; }

        public string? paisOrigen { get; set; }

        public string? paisDestino { get; set; }

        public Decimal montoEnvio { get; set; }

        public string? tipCambio { get; set; }

        public Decimal tasaCambio { get; set; }

        public Decimal montoFinal { get; set; }

        public string? Estado { get; set; }
    }
}