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
            if (string.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                MessageBox.Show("EL campo cobroId no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CantidadTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                MessageBox.Show("Debe realizar un cobro", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                PreciotextBox.Focus();
                paso = false;
            }
            if (this.cobro.Detalle.Count == 0)
            {
                MessageBox.Show("Debe agregar un CobroId", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                IdTextBox.Focus();
                CobroidTextBox.Focus();
                ventaIdtextBox.Focus();
                MontooTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;


            if (cobro.CobroId == 0)
                paso = CobrosBLL.Guardar(cobro);
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un cobro que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = CobrosBLL.Modificar(cobro);
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

            try
            {
                if (!string.IsNullOrWhiteSpace(CobrosIdTextBox.Text))
                {
                    MessageBox.Show("Debe el campo cobroId", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Limpiar();

                if (CobrosBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(CobrosIdTextBox.Text, "No se puede eliminar una Cobro que no existe");

            }
            catch
            {

            }

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


        private void PreciotextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PreciotextBox.Text);

                MontooTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void MontooTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PreciotextBox.Text);

                MontooTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void MontotextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PreciotextBox.Text);

                MontooTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }
    
    

        private void ClienteIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DetalleDataGridCobro != null)
            {
                if (ClienteIdComboBox.SelectedIndex == 0)
                {
                    cobro = new Cobros();
                    reCargar();
                }
                else
                {
                    cobro = CobrosBLL.Buscar(Convert.ToInt32(ClienteIdComboBox.SelectedItem));
                    reCargar();
                }
            }
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && (!string.IsNullOrWhiteSpace(PreciotextBox.Text)))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PreciotextBox.Text);

                MontooTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void RemoverDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGridCobro.Items.Count > 0 && DetalleDataGridCobro.SelectedItem != null)
            {

                cobro.Detalle.RemoveAt(DetalleDataGridCobro.SelectedIndex);
                reCargar();
            }
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {

            if (DetalleDataGridCobro.ItemsSource != null)
            {
                this.cobro.Detalle = (List<CobrosDetalles>)DetalleDataGridCobro.ItemsSource;
            }


            //Agregar un nuevo detalle con los datos introducidos

            this.cobro.Detalle.Add(new CobrosDetalles
            {
                Id = IdTextBox.Text.ToInt(),
                CobroId = CobroidTextBox.Text.ToInt(),
                VentaId = ventaIdtextBox.Text.ToInt(),
                Monto = MontooTextBox.Text.ToInt(),

            });
            reCargar();
            IdTextBox.Focus();
            IdTextBox.Clear();
            CobroidTextBox.Focus();
            CobroidTextBox.Clear();
            ventaIdtextBox.Focus();
            ventaIdtextBox.Clear();
            MontooTextBox.Focus();
            MontooTextBox.Clear();

        }

    }
}

