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
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Cobros.Add(cobro) != null)
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

        public static bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM CobrosDetalles Where CobroId={cobro.CobroId}");
                foreach (var item in cobro.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(cobro).State = EntityState.Modified;
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
                var eliminar = CobrosBLL.Buscar(id);
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

        public static Cobros Buscar(int id)
        {
            Contexto db = new Contexto();
            Cobros cobro = new Cobros();

            try
            {
                cobro = db.Cobros.Include(x => x.Detalle)
                    .Where(x => x.CobroId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return cobro;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> cobro)
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Cobros.Where(cobro).ToList();
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
