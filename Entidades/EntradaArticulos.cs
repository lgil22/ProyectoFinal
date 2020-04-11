using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class EntradaArticulos
    {
        [Key]
        public int EntradaId { get; set; }
        public int ArticuloId { get; set; }
        public int Entrada { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        public EntradaArticulos()
        {
            EntradaId = 0;
            ArticuloId = 0;
            Entrada = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
        }
    }
}
