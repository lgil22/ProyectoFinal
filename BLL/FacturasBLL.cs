using System;
using System.Collections.Generic;
using System.Text;
using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;


namespace SistemaVentas.BLL
{
    public class FacturasBLL
    {
        public static bool Guardar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Facturas.Add(facturas) != null)
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

        public static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM FacturaDetalles where FacturaId = {facturas.FacturaId}");
                foreach (var item in facturas.Detalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(facturas).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Facturas.Find(id);
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

        public static Facturas Buscar(int id)
        {
           Facturas ventas = new Facturas();
            Contexto db = new Contexto();

            try
            {
                ventas = db.Facturas.Where(x => x.FacturaId == id).
                     Include(y => y.Detalles).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ventas;
        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> facturas)
        {
            List<Facturas> lista = new List<Facturas>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Facturas.Where(facturas).ToList();
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