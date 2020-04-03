using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Nombres = "Luis David Gil Baez";
            usuarios.NombreUsuario = "lgil22";
            usuarios.Clave = "luida22";
            usuarios.Email = "lgilbaez@gmail.com";
            usuarios.Tipo = "Administrador";

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Nombres = "Davis Hidalgo Canaan";
            usuarios.NombreUsuario = "canaan02";
            usuarios.Clave = "davis92";
            usuarios.Email = "canaansolutions@hotmai.com";
            usuarios.Tipo = "Operativo";

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 1;
            paso = UsuariosBLL.Eliminar(usuarios.UsuarioId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios usuarios = new Usuarios();
            UsuariosBLL.Buscar(1);
            Assert.IsNotNull(usuarios != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}