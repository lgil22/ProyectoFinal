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
    public class NotasCreditosBLL
    {
        public static bool Guardar(NotasCreditos credito)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.NotasCreditos.Add(credito) != null)
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

        public static bool Modificar(NotasCreditos credito)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(credito).State = EntityState.Modified;
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
                var eliminar = db.NotasCreditos.Find(id);
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

        public static NotasCreditos Buscar(int id)
        {
            NotasCreditos credito = new NotasCreditos();
            Contexto db = new Contexto();

            try
            {
                credito = db.NotasCreditos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return credito;
        }

        public static List<NotasCreditos> GetList(Expression<Func<NotasCreditos, bool>> credito)
        {
            List<NotasCreditos> lista = new List<NotasCreditos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.NotasCreditos.Where(credito).ToList();
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
