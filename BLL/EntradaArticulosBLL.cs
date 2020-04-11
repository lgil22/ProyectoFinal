using Microsoft.EntityFrameworkCore;
using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL
{
   public class EntradaArticulosBLL
    {
        public static bool Guardar(EntradaArticulos entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                RepositorioBase<Articulos> art = new RepositorioBase<Articulos>();


                if (db.Entradas.Add(entrada) != null)
                {
                    var articulos = art.Buscar(entrada.ArticuloId);
                    articulos.Existencia = articulos.Existencia + entrada.Entrada;
                    art.Modificar(articulos);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(EntradaArticulos entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Articulos> prod = new RepositorioBase<Articulos>();
            RepositorioBase<EntradaArticulos> entr = new RepositorioBase<EntradaArticulos>();

            try
            {

                var anterior = entr.Buscar(entrada.EntradaId);
                var producto = prod.Buscar(entrada.ArticuloId);

                producto.Existencia = producto.Existencia + (entrada.Entrada - anterior.Entrada);
                prod.Modificar(producto);

                db.Entry(entrada).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Articulos> art = new RepositorioBase<Articulos>();
            RepositorioBase<EntradaArticulos> entr = new RepositorioBase<EntradaArticulos>();

            try
            {

                var entrada = entr.Buscar(id);
                var articulos = art.Buscar(entrada.ArticuloId);

                articulos.Existencia = articulos.Existencia - entrada.Entrada;
                art.Modificar(articulos);

                db.Entry(entrada).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
