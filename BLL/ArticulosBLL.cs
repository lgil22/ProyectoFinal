using Microsoft.EntityFrameworkCore;
using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SistemaVentas.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Articulos.Add(articulo) != null)
                {

                    paso = db.SaveChanges() > 0;
                }
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

        public static bool Modificar(Articulos articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulo).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
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

        public static Articulos Buscar(int id)
        {
            Articulos articulo = new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulo = db.Articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return articulo;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulo)
        {
            Contexto db = new Contexto();
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = db.Articulos.Where(articulo).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

       

    }
}
