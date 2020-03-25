using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVentas.Entidades
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

        public Categoria()
        {
            CategoriaId = 0;
            NombreCategoria = string.Empty;
        }
    }
}
