using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVentas.DAL;

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

            deudas.DeudasId = 1;
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
           DeudaClientes deudas = DeudaClientes.Eliminar(1);
            Assert.IsTrue(deudas != null);
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