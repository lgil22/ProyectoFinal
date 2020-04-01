using SistemaVentas.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using SistemaVentas.Entidades;


namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cDeudasClientes.xaml
    /// </summary>
    public partial class cDeudasClientes : Window
    {
        public cDeudasClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<DeudaClientes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = DeudaClientesBLL.GetList(o => true);
                        break;

                    case 1: //Deuda Id
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = DeudaClientesBLL.GetList(o => o.DeudasId == id);
                        break;

                    case 3:// Nombre Cliente

                        listado = DeudaClientesBLL.GetList(p => p.NombreCliente.Contains(CriterioTextBox.Text));
                        break;

                    case 4: //Deudas
                        decimal deudas;
                        deudas = decimal.Parse(CriterioTextBox.Text);
                        listado = DeudaClientesBLL.GetList(o => o.Deuda == deudas);
                        break;


                }


            }
            else
            {
                listado = DeudaClientesBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }
}
    