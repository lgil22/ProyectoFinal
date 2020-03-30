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
    /// Interaction logic for rFacturas.xaml
    /// </summary>
    public partial class rFacturas : Window
    {
        Facturas facturas = new Facturas(); /// Instancia para Bindings 
        public rFacturas()
        {
            InitializeComponent();
            this.DataContext = facturas;
        }

        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = facturas;
        }
        private void Limpiar()
        {
            this.facturas = new Facturas();
            DetalleDataGridFacturas.ItemsSource = new List<VentaDetalles>();
            Refrescar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Facturas facturas = FacturasBLL.Buscar((int)FacturaIdTextBox.Text.ToInt());
            return (facturas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MessageBox.Show("EL campo Tipo Pago no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombreTextBox.Focus();
                paso = false;
            }

            if (this.facturas.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar una venta", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ArticuloIdTextBox.Focus();
                DescripcionTextBox.Focus();
                CantidadTextBox.Focus();
                PrecioTextBox.Focus();
                paso = false;
            }
            return paso;
        }



        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Facturas facturaAnterior = FacturasBLL.Buscar(facturas.FacturaId);

            if (facturaAnterior != null)
            {
                MessageBox.Show("Factura Encontrada");
                facturas = facturaAnterior;
                Refrescar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Factura no encontrada");
            }
        }

        private void RemoverDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(DetalleDataGridFacturas.Items.ToString()))
                {
                    MessageBox.Show("Deben de estar llenos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (DetalleDataGridFacturas.Items.Count > 0 && DetalleDataGridFacturas.SelectedItem != null)
                {
                    //remover la fila
                   facturas.Detalles.RemoveAt(DetalleDataGridFacturas.SelectedIndex);
                    Refrescar();
                }

            }
            catch
            {

            }
        }

        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            Limpiar();

            //Determinar si es guardar o modificar

            if (string.IsNullOrWhiteSpace(FacturaIdTextBox.Text) || FacturaIdTextBox.Text == "0")
                paso = FacturasBLL.Guardar(facturas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una factura que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = FacturasBLL.Modificar(facturas);
            }

            //Informar el resultado
            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            { 
            MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
             }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(FacturaIdTextBox.Text, out id);

            try
            {

                if (!string.IsNullOrWhiteSpace(FacturaIdTextBox.Text) && !string.IsNullOrWhiteSpace(FacturaIdTextBox.Text))
                {
                    MessageBox.Show("Deben de estar llenos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Limpiar();

                if (VentasBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(FacturaIdTextBox.Text, "No se puede eliminar una factura que no existe");

            }
            catch
            {

            }
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (DetalleDataGridFacturas.ItemsSource != null)
            {
                this.facturas.Detalles = (List<FacturaDetalles>)DetalleDataGridFacturas.ItemsSource;
            }

            //Agregar un nuevo detalle con los datos introducidos

            this.facturas.Detalles.Add(new FacturaDetalles
            {
                ArticuloId = ArticuloIdTextBox.Text.ToInt(),
                Descripcion = DescripcionTextBox.Text,
                CantidadArticulo = CantidadTextBox.Text.ToInt(),
                Precio = PrecioTextBox.Text.ToInt(),
                Total = TotalTextBox.Text.ToInt(),

                //Precio = Convert.ToDecimal(PrecioTextBox.Text),
                //  Total = Convert.ToDecimal(TotalTextBox.Text),
                //   Precio = Convert.ToInt32(PrecioTextBox),

            });
            Refrescar();
            ArticuloIdTextBox.Focus();
            ArticuloIdTextBox.Clear();
            DescripcionTextBox.Focus();
            DescripcionTextBox.Clear();
            CantidadTextBox.Focus();
            CantidadTextBox.Clear();
            PrecioTextBox.Focus();
            PrecioTextBox.Clear();
            TotalTextBox.Focus();
            TotalTextBox.Clear();
        }

        private void ImprimirButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(PrecioTextBox.Text) && !string.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(PrecioTextBox.Text);
                Num2 = Convert.ToDecimal(CantidadTextBox.Text);

                TotalTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PrecioTextBox.Text) && !string.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(PrecioTextBox.Text);
                Num2 = Convert.ToDecimal(CantidadTextBox.Text);

                TotalTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PrecioTextBox.Text) && !string.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(PrecioTextBox.Text);
                Num2 = Convert.ToDecimal(CantidadTextBox.Text);

                TotalTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }
    }
}
