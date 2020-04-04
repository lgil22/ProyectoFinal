using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.BLL
{
    public class VentasBLL
    {

        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                RepositorioBase<Articulos> art = new RepositorioBase<Articulos>();
                RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();

                if (db.Ventas.Add(venta) != null)
                {

                    foreach (var item in venta.Detalles) ///Ciclo Foreach nos ayudara a correr la lista, es decir los campos que ya tenemos en el Grid y
                    {                                    /// depediendo los articulos que esten en existencia los descuente de la cantidad
                        var articulos = art.Buscar(item.ArticuloId);
                        articulos.Existencia = articulos.Existencia - item.Cantidad;
                        art.Modificar(articulos);

                    }

                    paso = db.SaveChanges() > 0;
                }

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
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Articulos> art = new RepositorioBase<Articulos>();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();

            try
            {
                Ventas venta = db.Ventas.Find(id);
                var cliente = client.Buscar(venta.ClienteId);


                foreach (var item in venta.Detalles)
                {
                    var articulos = art.Buscar(item.ArticuloId);
                    articulos.Existencia = articulos.Existencia + item.Cantidad;
                    art.Modificar(articulos);

                }

                db.Ventas.Remove(venta);
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

        public static void Modificarvent(Ventas ventas, Ventas VentasAnteriores)
        {
            Contexto contexto = new Contexto();

            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();

            var Cliente = client.Buscar(ventas.ClienteId);
            var ClientesAnteriores = client.Buscar(VentasAnteriores.ClienteId);


            client.Modificar(Cliente);
            client.Modificar(ClientesAnteriores);

            var Venta = vent.Buscar(ventas.VentaId);
            var ventaanterior = vent.Buscar(VentasAnteriores.VentaId);

        }

        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Articulos> prod = new RepositorioBase<Articulos>();
            try
            {
                var venta = vent.Buscar(ventas.VentaId);

                if (ventas.ClienteId != venta.ClienteId)
                {
                    Modificarvent(ventas, venta);
                }

                if (ventas != null)
                {
                    db.Database.ExecuteSqlRaw($"Delete FROM VentaDetalles where VentaId = {ventas.VentaId}");
                    foreach (var item in venta.Detalles)
                    {
                        db.Articulos.Find(item.ArticuloId).Existencia += item.Cantidad;

                        if (!ventas.Detalles.ToList().Exists(v => v.Id == item.Id))
                        {

                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in ventas.Detalles)
                    {
                        db.Articulos.Find(item.ArticuloId).Existencia -= item.Cantidad;
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(ventas).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }

               
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Ventas Buscar(int ID)
        {
            Ventas ventas = new Ventas();

            Contexto db = new Contexto();

            try
            {
                ventas = db.Ventas.Find(ID);
                if (ventas != null)
                {
                    ventas.Detalles.Count();
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

            return ventas;
        }

       public static List<Ventas> GetList(Expression<Func<Ventas, bool>> ventas)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Ventas.Where(ventas).ToList();
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
