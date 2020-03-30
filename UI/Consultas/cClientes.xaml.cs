using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;

namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cClientes.xaml
    /// </summary>
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = ClientesBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(o => o.ClienteId == id);
                        break;

                    case 3://Nombres
                        listado = ClientesBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Direccion
                        listado = ClientesBLL.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;

                    case 5://Telefono
                        listado = ClientesBLL.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                        break;


                    case 6://Cedula
                        listado = ClientesBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 7://Email
                        listado = ClientesBLL.GetList(p => p.Email.Contains(CriterioTextBox.Text));
                        break;


                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDatePicker.SelectedDate && c.FechaNacimiento.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = ClientesBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }


    }
}
