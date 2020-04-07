using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class DeudaClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            DeudaClientes deudas = new DeudaClientes();

            deudas.DeudasId = 0;
            deudas.NombreCliente = "Davis Hidalgo";
            deudas.Deuda = 1200;

            paso = DeudaClientesBLL.Guardar(deudas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            DeudaClientes deudas = new DeudaClientes();

            deudas.DeudasId = 0;
            deudas.NombreCliente = "Roberto Canaan";
            deudas.Deuda = 1500;

            paso = DeudaClientesBLL.Guardar(deudas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {

            bool paso = DeudaClientesBLL.Eliminar(1);
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            DeudaClientes deudas = new DeudaClientes();
            DeudaClientesBLL.Buscar(1);
            Assert.IsNotNull(deudas != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}