using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Runtime.Serialization;

namespace SistemaVentas.Entidades
{
    [DataContract]
   public class Usuarios
    {
        [Key]
        [DataMember]
        public int UsuarioId { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
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
