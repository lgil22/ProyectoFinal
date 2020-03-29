using Microsoft.EntityFrameworkCore;
using SistemaVentas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SistemaVentas.BLL
{
    public class Repositorio
    {
        public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
        {
            internal Contexto db;
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
                        paso = db.SaveChanges() > 0;

                }
                catch (Exception)
                {

                    throw;
                }
                return paso;
            }

            public virtual bool Modificar(T entity)
            {
                bool paso = false;

                try
                {
                    db.Entry(entity).State = EntityState.Modified;
                    paso = db.SaveChanges() > 0;
                }
                catch (Exception)
                {

                    throw;
                }
                return paso;
            }

            public virtual bool Eliminar(int ID)
            {
                bool paso = false;
                try
                {
                    T entity = db.Set<T>().Find(ID);
                    db.Set<T>().Remove(entity);

                    paso = db.SaveChanges() > 0;
                }
                catch (Exception)
                {

                    throw;
                }

                return paso;
            }

            public virtual T Buscar(int ID)
            {
                T entity;

                try
                {
                    entity = db.Set<T>().Find(ID);
                }
                catch (Exception)
                {

                    throw;
                }

                return entity;
            }

            public List<T> GetList(Expression<Func<T, bool>> entity)
            {
                List<T> lista = new List<T>();

                try
                {
                    lista = db.Set<T>().Where(entity).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }

            public void Dispose()
            {
                db.Dispose();
            }
        }
    }
}