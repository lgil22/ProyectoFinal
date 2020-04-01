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
using SistemaVentas.BLL;
using System.Linq;

namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCobro.xaml
    /// </summary>
    public partial class cCobro : Window
    {
        public cCobro()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
             var listado = new List<Cobros>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = CobrosBLL.GetList(o => true);
                        break;

                    case 1: //Cobro Id
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.CobroId == id);
                        break;

                    case 2: // Cliente Id
                        int clienteId;
                        clienteId = int.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.ClienteId == clienteId);
                        break;

                    case 3: // Articulo Id
                        int articuloId;
                        articuloId = int.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.ArticuloId == articuloId);
                        break;

                    case 4: //Cantidad
                        int cant;
                        cant = int.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.Cantidad== cant);
                        break;

                    case 5: //Precio
                        int Prec;
                        Prec = int.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.Precio == Prec);
                        break;

                    case 6: //monto
                        float monto;
                        monto = float.Parse(CriterioTextBox.Text);
                        listado = CobrosBLL.GetList(o => o.Monto == monto);
                        break;


                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = CobrosBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
        }
    }

