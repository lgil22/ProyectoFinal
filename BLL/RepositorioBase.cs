using System;
using System.Collections.Generic;
using System.Text;
using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SistemaVentas.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class

    {
        internal Contexto db;
        public RepositorioBase(Contexto contexto)
        {
            db = contexto;
        }
        public RepositorioBase()
        {
            db = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (db.Set<T>().Add(entity) != null)
                {
                    db.SaveChanges();
                    paso = true;
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

        public virtual bool Modificar(T entity)
        {
        
            bool paso = false;

            try
            {
                db.Entry(entity).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    paso = true;
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

        public virtual bool Eliminar(int id)
        {
           // Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                T entity = db.Set<T>().Find(id);
                db.Set<T>().Remove(entity);

              if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
           
            return paso;
        }

        public virtual T Buscar(int id)
        {
            
            T entity;

            try
            {
                entity = db.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return entity;
        }


        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();

            try
            {
                Lista = db.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
        public virtual void Dispose()
        {
            db.Dispose();
        }


        private static Usuarios usuario = new Usuarios();

        public virtual void NombreLogin(string Nombres, string NombreUsuario, String Tipo)
        {
            usuario.NombreUsuario = string.Concat(Nombres, " ", NombreUsuario);
            usuario.Tipo = Tipo;

        }

        public virtual Usuarios ReturnUsuario()
        {
            return usuario;
        }

       
    }
}
