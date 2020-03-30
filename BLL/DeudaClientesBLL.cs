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
   public class DeudaClientesBLL
    {
        public static bool Guardar(DeudaClientes deudas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Deudas.Add(deudas) != null)
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

        public static bool Modificar(DeudaClientes deudas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
              
                {
                    db.Entry(deudas).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Deudas.Find(id);
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

        public static DeudaClientes Buscar(int id)
        {
            DeudaClientes deudas = new DeudaClientes();
            Contexto db = new Contexto();

            try
            {
               
                   deudas = db.Deudas.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return deudas;
        }

        public static List<DeudaClientes> GetList(Expression<Func<DeudaClientes, bool>> deudas)
        {
            List<DeudaClientes> lista = new List<DeudaClientes>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Deudas.Where(deudas).ToList();
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

