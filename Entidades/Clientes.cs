using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Clientes
    {

        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaNacimiento = DateTime.Now;
        }

     /*ublic Clientes(int clienteId, string nombres, string direccion, string telefono, string celular, string cedula, string email, DateTime fechaNacimiento)
        {
            this.ClienteId = clienteId;
            this.Nombres = nombres;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Celular = celular;
            this.Cedula = cedula;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
        }*/

    }
}
