using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
   public class DeudaClientes
    {
        [Key]
        public int DeudasId { get; set; }
        public string NombreCliente { get; set; }
        public decimal Deuda { get; set; }

      //  public Entidades.Clientes Cliente { get; set; }

        public DeudaClientes()
        {
            DeudasId = 0;
            NombreCliente = string.Empty;
            Deuda = 0;

        }
   
    }
}
