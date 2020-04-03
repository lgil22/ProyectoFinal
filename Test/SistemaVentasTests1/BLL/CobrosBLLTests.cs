using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class CobrosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = CobrosBLL.Guardar(cobro);
            cobro.CobroId = 0;
            cobro.ClienteId = 1;
            cobro.ArticuloId = 1;
            cobro.Fecha = DateTime.Now;
            cobro.Cantidad = 1;
            cobro.Precio = 100;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = CobrosBLL.Guardar(cobro);
            cobro.CobroId = 1;
            cobro.ClienteId = 2;
            cobro.ArticuloId = 2;
            cobro.Fecha = DateTime.Now;
            cobro.Cantidad = 2;
            cobro.Precio = 900;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CobrosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Cobros c = new Cobros();
            CobrosBLL.Buscar(1);
            Assert.IsNotNull(c != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Cobros> c = new List<Cobros>();
            c = CobrosBLL.GetList(p => true);
            Assert.IsNotNull(c);
        }
    }
}