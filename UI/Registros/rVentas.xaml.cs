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
using SistemaVentas.DAL;
using SistemaVentas.UI;

namespace SistemaVentas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        Ventas ventas = new Ventas(); /// Instancia para Bindings 
        public List<VentaDetalles> Detalles { get; set; }
        public rVentas()
        {
            InitializeComponent();
           this.DataContext = ventas;
            this.Detalles = new List<VentaDetalles>();
        }
        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = ventas;
        }
        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            ClienteIdCombox.Text = null;
            FechaNacTimePicker.DisplayDate = DateTime.Now;
            TipoPagoComBox.Text = string.Empty;
            this.ventas = new Ventas();
            DetalleDataGridVentas.ItemsSource = new List<VentaDetalles>();
            this.Detalles = new List<VentaDetalles>();
            CargarGrid();
            Refrescar();
            LlenaComBox();
            LlenaComBoxArticulos();
        }

        private Ventas LlenaClase()
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = int.Parse(VentaIdTextBox.Text);
            ventas.ClienteId = (int)ClienteIdCombox.SelectedValue;
            ventas.TipoPago = (string)TipoPagoComBox.SelectedValue;
            ventas.Fecha = (DateTime)FechaNacTimePicker.SelectedDate;
          

            ventas.Detalles = this.Detalles;
            return ventas;
        }

        private void LlenaCampo(Ventas ventas)
        {
            VentaIdTextBox.Text = Convert.ToString(ventas.VentaId);
            ClienteIdCombox.SelectedValue = (ventas.ClienteId);
            TipoPagoComBox.Text = Convert.ToString(ventas.TipoPago);
            FechaNacTimePicker.DisplayDate = ventas.Fecha;

            this.Detalles = ventas.Detalles;
            CargarGrid();

        }

        private void CargarGrid()
        {
            DetalleDataGridVentas.ItemsSource = null;
            DetalleDataGridVentas.ItemsSource = this.Detalles;
        }

        private void LlenaComBox()  ///Metodo que nos ayudara a cargar el cliente que ya se tiene registrado...
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();
            listado = db.GetList(p => true);
            ClienteIdCombox.DataContext = listado;
            ClienteIdCombox.SelectedValue = "ClienteId";
           ClienteIdCombox.DisplayMemberPath = "Nombres";
        }

        private string GetCliente(int id)
        {
            string nombre;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            clientes = repositorio.Buscar(id);
            if (clientes == null)
                nombre = "";
            else
                nombre = clientes.Nombres;
            return nombre;
        }

        private void LlenaComBoxArticulos()  ///Metodo que nos ayudara a cargar el cliente que ya se tiene registrado...
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            var listado = new List<Articulos>();
            listado = db.GetList(p => true);
            ClienteIdCombox.DataContext = listado;
            ClienteIdCombox.SelectedValue = "ArticulosId";
            ClienteIdCombox.DisplayMemberPath = "Descripcion";
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Clientes clientes = ClientesBLL.Buscar((int)ClienteIdCombox.Text.ToInt());
            return (clientes != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(TipoPagoComBox.Text))
            {
                MessageBox.Show("EL campo Tipo Pago no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                TipoPagoComBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MessageBox.Show("EL campo Monto no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
               MontoTextBox.Focus();
                paso = false;
            }
            if (this.ventas.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar una venta", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ArticuloIdComBox.Focus();
                CantidadTextBox.Focus();
                PrecioTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {
         
            if (DetalleDataGridVentas.ItemsSource != null ) 
            {
                this.ventas.Detalles = (List<VentaDetalles>)DetalleDataGridVentas.ItemsSource;
            }

                //Agregar un nuevo detalle con los datos introducidos

                this.ventas.Detalles.Add(new VentaDetalles
            {
                ArticuloId = Convert.ToInt32(ArticuloIdComBox.SelectedValue),
                Cantidad = CantidadTextBox.Text.ToInt(),
                Precio = PrecioTextBox.Text.ToInt(),
                

                    //PrecioTextBox.Text.ToInt(),
                    //   Precio = Convert.ToInt32(PrecioTextBox),

                });
         CargarGrid();
           /// Refrescar();
             ArticuloIdComBox.Text = string.Empty;
             CantidadTextBox.Text = string.Empty;
            // CantidadTextBox.Clear();
            //  PrecioTextBox.Focus();
            PrecioTextBox.Text = string.Empty;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventaAnterior = VentasBLL.Buscar(ventas.VentaId);

            if (ventaAnterior != null)
            {
                MessageBox.Show("Venta Encontrada");
                ventas = ventaAnterior;
                Refrescar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta no encontrada");
            }

        }

        private void RemoverDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(DetalleDataGridVentas.Items.Count.ToString()))
                {
                    MessageBox.Show("Deben de estar llenos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (DetalleDataGridVentas.Items.Count > 0 && DetalleDataGridVentas.SelectedItem != null)
                {
                    //remover la fila
                    Detalles.RemoveAt(DetalleDataGridVentas.SelectedIndex);
                  // Refrescar();
                  CargarGrid();

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

            if (string.IsNullOrWhiteSpace(VentaIdTextBox.Text) || (VentaIdTextBox.Text == "0"))
                paso = VentasBLL.Guardar(ventas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una venta que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = VentasBLL.Modificar(ventas);
            }

            //Informar el resultado
            if (paso)
            { MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();

            }
            else
            { 
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);

            try
            {

                if (!string.IsNullOrWhiteSpace(VentaIdTextBox.Text) && (!string.IsNullOrWhiteSpace(ClienteIdCombox.Text)))
                {
                    MessageBox.Show("Deben de estar llenos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Limpiar();

                if (VentasBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(VentaIdTextBox.Text, "No se puede eliminar una venta que no existe");

            }
            catch
            {

            }

        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && (!string.IsNullOrWhiteSpace(PrecioTextBox.Text)))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PrecioTextBox.Text);

                MontoTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PrecioTextBox.Text);

                MontoTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void MontoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && (!string.IsNullOrWhiteSpace(PrecioTextBox.Text)))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(CantidadTextBox.Text);
                Num2 = Convert.ToDecimal(PrecioTextBox.Text);

                MontoTextBox.Text = Convert.ToString(Num1 * Num2);
            }
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
    }
}
