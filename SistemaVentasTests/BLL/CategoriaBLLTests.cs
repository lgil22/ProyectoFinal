using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class CategoriaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Categoria categoria = new Categoria();
            bool paso = CategoriaBLL.Guardar(categoria);
            categoria.CategoriaId = 1;
            categoria.NombreCategoria = "Damas";
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Categoria categoria = new Categoria();
            bool paso = CategoriaBLL.Guardar(categoria);
            categoria.CategoriaId = 2;
            categoria.NombreCategoria = "Caballeros";
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CategoriaBLL.Eliminar(1);
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Categoria categorias = new Categoria();
            CategoriaBLL.Buscar(1);
            Assert.IsNotNull(categorias != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Categoria> categ = new List<Categoria>();
            categ = CategoriaBLL.GetList(p => true);
            Assert.IsNotNull(categ);
        }
    }
}