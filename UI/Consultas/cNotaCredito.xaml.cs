using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for cNotaCredito.xaml
    /// </summary>
    public partial class cNotaCredito : Window
    {
        public cNotaCredito()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<NotasCreditos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = NotasCreditosBLL.GetList(o => true);
                        break;

                    case 1: //Nota credito Id
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = NotasCreditosBLL.GetList(o => o.NotaId == id);
                        break;
                    
                    case 2: // Cliente Id
                        int clienteId;
                        clienteId = int.Parse(CriterioTextBox.Text);
                        listado = NotasCreditosBLL.GetList(o => o.ClienteId == clienteId);
                        break;

                    case 3: // Usuario Id
                        int usuario;
                        usuario = int.Parse(CriterioTextBox.Text);
                        listado = NotasCreditosBLL.GetList(o => o.UsuarioId == usuario);
                        break;

                    case 4: // Concepto
                        listado = NotasCreditosBLL.GetList(p => p.Concepto.Contains(CriterioTextBox.Text));
                        break;
                        

                    case 5: // Monto
                        int mon;
                        mon = int.Parse(CriterioTextBox.Text);
                        listado = NotasCreditosBLL.GetList(o => o.Monto == mon);
                        break;


                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = NotasCreditosBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }
}
        
