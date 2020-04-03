using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.BLL.Tests
{
    [TestClass()]
    public class NotasCreditosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            NotasCreditos credito = new NotasCreditos();
            bool paso = NotasCreditosBLL.Guardar(credito);
            credito.NotaId = 0;
            credito.Fecha = DateTime.Now;
            credito.ClienteId = 1;
            credito.UsuarioId = 1;
            credito.Concepto = "jabon";
            credito.Monto = 20;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            NotasCreditos credito = new NotasCreditos();
            bool paso = NotasCreditosBLL.Guardar(credito);
            credito.NotaId = 0;
            credito.Fecha = DateTime.Now;
            credito.ClienteId = 1;
            credito.UsuarioId = 1;
            credito.Concepto = "shampoo";
            credito.Monto = 20;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = NotasCreditosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            NotasCreditos notas = new NotasCreditos();
            NotasCreditosBLL.Buscar(1);
            Assert.IsNotNull(notas != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<NotasCreditos> creditos = new List<NotasCreditos>();
            creditos = NotasCreditosBLL.GetList(p => true);
            Assert.IsNotNull(creditos);
        }
    }
}