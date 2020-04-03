using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class ArticulosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Articulos articulo = new Articulos();
            bool paso = ArticulosBLL.Guardar(articulo);

            articulo.ArticulosId = 0;
            articulo.UsuarioId = 1;
            articulo.Descripcion = "jabon de cuaba";
            articulo.CategoriaId = 1;
            articulo.Existencia = 1;
            articulo.Costo = 100;
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Articulos articulo = new Articulos();
            bool paso = ArticulosBLL.Guardar(articulo);
            articulo.ArticulosId = 1;
            articulo.UsuarioId = 0;
            articulo.Descripcion = "Cloro";
            articulo.CategoriaId = 0;
            articulo.Existencia = 1;
            articulo.Costo = 90;
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = ArticulosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Articulos articulos = new Articulos();
            ArticulosBLL.Buscar(1);
            Assert.IsNotNull(articulos != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Articulos> articulo = new List<Articulos>();
            articulo = ArticulosBLL.GetList(p => true);
            Assert.IsNotNull(articulo);
        }
    }
}