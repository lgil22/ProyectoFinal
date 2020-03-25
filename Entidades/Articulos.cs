using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public string Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }

        public Articulos()
        {
            ArticulosId = 0;
            Descripcion = string.Empty;
            CategoriaId = 0;
            Existencia = string.Empty;
            Costo = 0;
            Precio = 0;
        }
    }
}
