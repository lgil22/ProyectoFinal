using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

 /*  public Usuarios(int usuarioId, string nombres, string nombreUsuario, string clave, string email, string tipo)
        {
            this.UsuarioId = usuarioId;
            this.Nombres = nombres;
            this.NombreUsuario = nombreUsuario;
            this.Clave = clave;
            this.Email = email;
            this.Tipo = tipo;

        } */

    }
}
