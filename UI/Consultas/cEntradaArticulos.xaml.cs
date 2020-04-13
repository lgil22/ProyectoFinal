using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cEntradaArticulos.xaml
    /// </summary>
    public partial class cEntradaArticulos : Window
    {
        public cEntradaArticulos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {

            var listado = new List<EntradaArticulos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = EntradaArticulosBLL.GetList(o => true);
                        break;

                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = EntradaArticulosBLL.GetList(o => o.EntradaId == id);
                        break;

                    case 2:
                        int articuloId;
                        articuloId = int.Parse(CriterioTextBox.Text);
                        listado = EntradaArticulosBLL.GetList(o => o.ArticuloId == articuloId);
                        break;

                    case 3:// Entrada
                        int entrada;
                        entrada = int.Parse(CriterioTextBox.Text);
                        listado = EntradaArticulosBLL.GetList(o => o.Entrada == entrada);
                        break;

                }

            }
            else if (FiltroComboBox.SelectedIndex == 3)
            {
                listado = EntradaArticulosBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }
            else
            {
                listado = EntradaArticulosBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }

}