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
    /// Interaction logic for RegCobro.xaml
    /// </summary>
    public partial class RegCobro : Window
    {
        Cobros cobro = new Cobros();

        public RegCobro()
        {
            InitializeComponent();
            this.DataContext = cobro;
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = cobro;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Cobros cobroAnterior = CobrosBLL.Buscar((int)CobrosIdTextBox.Text.ToInt());

            return (cobroAnterior != null);
        }
        private void Limpiar()
        {

            this.cobro = new Cobros();
            DetalleDataGridCobro.ItemsSource = new List<CobrosDetalles>();
            reCargar();
        }
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(CobrosIdTextBox.Text))
            {
                MessageBox.Show("EL campo cobroId no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CobrosIdTextBox.Focus();
                paso = false;
            }
            if (this.cobro.Detalle.Count == 0)
            {
                MessageBox.Show("Debe agregar una cobro", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CobrosIdTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

            if (string.IsNullOrWhiteSpace(CobrosIdTextBox.Text) || CobrosIdTextBox.Text == "0")
                paso = CobrosBLL.Guardar(cobro);
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = CobrosBLL.Modificar(cobro);
                else
                {
                    MessageBox.Show("No se puede modificar no existe");
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
            int id;
            int.TryParse(CobrosIdTextBox.Text, out id);

            Limpiar();

            if (id > 0)
            {
                if (existeEnLaBaseDeDatos()){ 
                    CobrosBLL.Eliminar(id); 
                }
                else
                    MessageBox.Show("No se puede hacer cobro si no has falturado");

            }
            else
                MessageBox.Show("No se puede hacer cobro si no has falturado");

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Cobros cobroAnterior = CobrosBLL.Buscar(cobro.CobroId);

            if (cobro != null)
            {
                MessageBox.Show("Cobro encontrado");
                cobro = cobroAnterior;
                reCargar();

            }
            else
            {
                MessageBox.Show("no se pudo hacer el cobro");
            }
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGridCobro.ItemsSource != null)
            {
                this.cobro.Detalle = (List<CobrosDetalles>)DetalleDataGridCobro.ItemsSource;
            }


            this.cobro.Detalle.Add(new CobrosDetalles
            {

                Monto = MontotextBox.Text.ToInt(),


            });
            reCargar();

            MontotextBox.Focus();
            MontotextBox.Clear();
        }


        private void RemoverDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGridCobro.Items.Count > 0 && DetalleDataGridCobro.SelectedItem != null)
            {

                cobro.Detalle.RemoveAt(DetalleDataGridCobro.SelectedIndex);
                reCargar();
            }
        }

    }
}
 



