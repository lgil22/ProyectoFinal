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

namespace SistemaVentas.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegNotasClientes.xaml
    /// </summary>
    public partial class RegNotasClientes : Window
    {
        Cobros cobro = new Cobros();
        public RegNotasClientes()
        {
            InitializeComponent();
            this.DataContext = cobro;

           
        }
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = cobro;
        }

      
          
      
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {

            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            cobro.CobroId = cobro.CobroId;
            cobro.ArticuloId = Convert.ToInt32(ArticuloIdComboBox.SelectedItem);
            cobro.ClienteId = Convert.ToInt32(ClienteIdComboBox.SelectedItem);


            if (cobro.CobroId == 0)
                paso = CobrosBLL.Guardar(cobro);
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = CobrosBLL.Modificar(cobro);
                else
                {
                    MessageBox.Show("No se puede modificar una Orden que no existe");
                    return;
                }
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }


        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(CobrosIdTextBox.Text);

            Limpiar();

            if (id > 0)
            {
                CobrosBLL.Eliminar(id);
            }
            else
                MessageBox.Show("No se puede hacer cobro si no has falturado");
        }

        private void obtenerCobro()
        {
            List<Articulos> productos = ArticulosBLL.GetList(p => true);

            foreach (var item in productos)
            {
                ArticuloIdComboBox.Items.Add(item.ArticulosId);
            }
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Cobros cobroAnterior = CobrosBLL.Buscar(cobro.CobroId);

            if (cobro != null)
            {
               cobro = cobroAnterior;
                reCargar();
    
            }
            else
            {
                MessageBox.Show("no se pudo hacer el cobro");
            }
        }

        private bool existeEnLaBaseDeDatos()
        {
            Cobros cobroAnterior = CobrosBLL.Buscar(cobro.CobroId);

            return cobroAnterior != null;
        }
        private void Limpiar()
        {

            CobrosIdTextBox.Text = "0";
            ArticuloIdComboBox.SelectedItem = "0";
            ClienteIdComboBox.SelectedItem = "0";
            FechaDatePicke.SelectedDate = DateTime.Now;
            CantidadTextBox.Text = "0";
            MontoTextBox.Text = "0";
            reCargar();
        }
    }
}
