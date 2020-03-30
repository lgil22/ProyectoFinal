using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class CobrosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int CobroId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }

        public CobrosDetalles()
        {
            Id = 0;
            CobroId = 0;
            VentaId = 0;
            Monto = 0;
        }
    }
}
