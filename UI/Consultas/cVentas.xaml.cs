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
    /// Interaction logic for cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = VentasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.VentaId == id);
                        break;

                    case 2:
                        int clienteId;
                        clienteId = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.ClienteId == clienteId);
                        break;

                    case 3://Tipo Pago
                        listado = VentasBLL.GetList(p => p.TipoPago.Contains(CriterioTextBox.Text));
                        break;


                    case 4:
                        float monto;
                        monto = float.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.Monto == monto);
                        break;

                 

                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = VentasBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }
    
}
