using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class VentaDetalles
    {
        [Key]
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public VentaDetalles()
        {
            VentaId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
        }

    }
}