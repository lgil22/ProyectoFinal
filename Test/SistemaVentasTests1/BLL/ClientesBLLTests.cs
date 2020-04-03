using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.DAL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
           Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Nombres = "Luis David Gil";
            clientes.Direccion = "Villa Tapia #71";
            clientes.Telefono = "829-509-2787";
            clientes.Celular = "829-313-1755";
            clientes.Cedula = "402-0000000-0";
            clientes.Email = "lgilbaez@gmail.com";
            clientes.FechaNacimiento = DateTime.Now;

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Nombres = "Davis Hidalgo";
            clientes.Direccion = "Villa Tapia #73";
            clientes.Telefono = "829-313-1755";
            clientes.Celular = "829-509-2787";
            clientes.Cedula = "051-0000000-0";
            clientes.Email = "luisdavid9-12@hotmail.com";
            clientes.FechaNacimiento = DateTime.Now;

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 1;
            paso = ClientesBLL.Eliminar(clientes.ClienteId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Clientes clientes = new Clientes();
            ClientesBLL.Buscar(1);
            Assert.IsNotNull(clientes != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Clientes> clientes = new List<Clientes>();
            clientes = ClientesBLL.GetList(p => true);
            Assert.IsNotNull(clientes);
        }
    }
}