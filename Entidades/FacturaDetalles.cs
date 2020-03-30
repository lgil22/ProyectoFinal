using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SistemaVentas.Entidades;
using SistemaVentas.DAL;
using SistemaVentas.BLL;

namespace SistemaVentas.Entidades
{
    public class FacturaDetalles
    {
        [Key]
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Precio { get; set; }
        public int CantidadArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
     //   public Entidades.Articulos Articulo { get; set; }

        public FacturaDetalles()
        {
            FacturaId = 0;
            ArticuloId = 0;
            Precio = 0;
            CantidadArticulo = 0;
            Descripcion = string.Empty;
            Total = 0;
        }


    }
}
