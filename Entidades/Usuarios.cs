using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Entidades
{

   public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Email = string.Empty;
            Tipo = string.Empty;

        }

    }
}
