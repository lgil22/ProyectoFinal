using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class NotasCreditos
    {
        [Key]
        public int NotaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        public NotasCreditos()
        {
            NotaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            UsuarioId = 0;
            Concepto = string.Empty;
            Monto = 0;
        }
    }
}
