using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Ventas
    {
            [Key]
            public int VentaId { get; set; }
            public int ClienteId { get; set; }
            public string TipoPago { get; set; }
            public float Monto { get; set; }
            public DateTime Fecha { get; set; }
 
            [ForeignKey("VentaId")]

            public virtual List<VentaDetalles> Detalles { get; set; }

            public Ventas()
            {
                VentaId = 0;
                ClienteId = 0;
                TipoPago = string.Empty;
                Monto = 0;
                Fecha = DateTime.Now;

            Detalles = new List<VentaDetalles>();
            }

        }

   }
