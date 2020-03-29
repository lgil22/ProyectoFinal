using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("CobrosId")]
       
        public virtual List<CobrosDetalles> Detalle { get; set; }

        public Cobros()
        {
            CobroId = 0;
            ClienteId = 0;
            ArticuloId = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
            Monto = 0;
            Detalle = new List<CobrosDetalles>();
        }
    }
}
