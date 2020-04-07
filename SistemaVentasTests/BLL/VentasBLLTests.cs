using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 0;
            ventas.ClienteId = 0;
            ventas.TipoPago = "Credito";
            ventas.Monto = 200;
            ventas.Fecha = DateTime.Now;

            paso = VentasBLL.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 1;
            paso = VentasBLL.Eliminar(ventas.VentaId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarventTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 0;
            ventas.ClienteId = 0;
            ventas.TipoPago = "Contado";
            ventas.Monto = 500;
            ventas.Fecha = DateTime.Now;

            paso = VentasBLL.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ventas ventas = new Ventas();
            ArticulosBLL.Buscar(1);
            Assert.IsNotNull(ventas != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var lista = new List<Clientes>();
            lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}