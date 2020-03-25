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

            public virtual List<VentaDetalles> Detalle { get; set; }

            public Ventas()
            {
                VentaId = 0;
                ClienteId = 0;
                TipoPago = string.Empty;
                Monto = 0;
                Fecha = DateTime.Now;

            Detalle = new List<VentaDetalles>();
            }

         /*   public Ventas(int ventaId, int clienteId, string tipoPago, float monto, DateTime fecha)
            {
                this.VentaId = ventaId;
                this.ClienteId = clienteId;
                this.TipoPago = tipoPago;
                this.Monto = Monto;
                this.Fecha = fecha;
            
            }*/


        }
    }
