using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public string TipoVenta { get; set; }
        public int CantidadArticulo { get; set; }
        
        public virtual List<FacturaDetalles> Detalles { get; set; }


        public Facturas()
        {
            FacturaId = 0;
            NombreCliente = string.Empty;
            FechaVenta = DateTime.Now;
            TipoVenta = string.Empty;
            CantidadArticulo = 0;
            Detalles = new List<FacturaDetalles>();

        }

    }
}