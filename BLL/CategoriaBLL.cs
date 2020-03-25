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
    public class CategoriaBLL
    {
        public static bool Guardar(Categoria categoria)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Categoria.Add(categoria) != null)
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

        public static bool Modificar(Categoria categoria)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(categoria).State = EntityState.Modified;
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
                var eliminar = db.Categoria.Find(id);
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

        public static Categoria Buscar(int id)
        {
            Categoria categoria = new Categoria();
            Contexto db = new Contexto();

            try
            {
                categoria = db.Categoria.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return categoria;
        }

        public static List<Categoria> GetList(Expression<Func<Categoria, bool>> categoria)
        {
            List<Categoria> lista = new List<Categoria>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Categoria.Where(categoria).ToList();
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
