﻿using SistemaVentas.Entidades;
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
            LlenaComBox();
            LlenaComBoxArticulos();
            FechaNacTimePicker.DisplayDate = DateTime.Now;
            this.DataContext = ventas;
            this.Detalles = new List<VentaDetalles>();
            CargarGrid();

        }
        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = ventas;
        }
        private void Limpiar()
        {
            
          // Articulos vd = new Articulos();
            VentaIdTextBox.Text = "0";
            ClienteIdCombox.Text = null;
            FechaNacTimePicker.DisplayDate = DateTime.Now;
            TipoPagoComBox.Text = null;
            this.ventas = new Ventas();
            DetalleDataGridVentas.ItemsSource = new List<VentaDetalles>();
            this.Detalles = new List<VentaDetalles>();
            ArticuloIdComBox.Text = null;
            CargarGrid();
            Refrescar();
            LlenaComBox();
            LlenaComBoxArticulos();
            
            
        }

      /*  private Ventas LlenaClase()
        {
            Articulos vedt = new Articulos();
            Ventas ventas = new Ventas();
            ventas.VentaId = int.Parse(VentaIdTextBox.Text);
            ventas.ClienteId = Convert.ToInt32(ClienteIdCombox.Text);
            ventas.TipoPago = (string)TipoPagoComBox.Text;
            ventas.Fecha = (DateTime)FechaNacTimePicker.DisplayDate;
            vedt.ArticulosId = Convert.ToInt32(ArticuloIdComBox.SelectedItem);

            ventas.Detalles = this.Detalles;
            return ventas;
        }*/

    /*    private void LlenaCampo(Ventas ventas)
        {
            Articulos vedt = new  Articulos();
            VentaIdTextBox.Text = Convert.ToString(ventas.VentaId);
            ClienteIdCombox.SelectedValue = (ventas.ClienteId);
            TipoPagoComBox.SelectedValue= (ventas.TipoPago);
            FechaNacTimePicker.SelectedDate = (ventas.Fecha);
            ArticuloIdComBox.SelectedValue = (vedt.ArticulosId);

            this.Detalles = ventas.Detalles;
            CargarGrid();

        }*/

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
            ClienteIdCombox.ItemsSource = listado;
            ClienteIdCombox.SelectedValue = "ClienteId";
           ClienteIdCombox.DisplayMemberPath = "Nombres";
        }

    
        private void LlenaComBoxArticulos()  ///Metodo que nos ayudara a cargar el id articulo que ya se tiene registrado...
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            var listado2 = new List<Articulos>();
            listado2 = db.GetList(p => true);
            ArticuloIdComBox.ItemsSource = listado2;
            ArticuloIdComBox.SelectedValue = "ArticulosId";
            ArticuloIdComBox.DisplayMemberPath = "Descripcion";
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas ventas = VentasBLL.Buscar((int)VentaIdTextBox.Text.ToInt());
            return (ventas != null);
        }

        private bool Validar()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

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
            if (this.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar una venta", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                 ArticuloIdComBox.Focus();
                CantidadTextBox.Focus();
                PrecioTextBox.Focus();
                MontoTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            if (DetalleDataGridVentas.ItemsSource != null ) 
            {
                this.Detalles = (List<VentaDetalles>)DetalleDataGridVentas.ItemsSource;
            }

            //Agregar un nuevo detalle con los datos introducidos

            this.Detalles.Add(new VentaDetalles
            {
               
                ArticuloId = (int)ArticuloIdComBox.Text.ToInt(),
                Cantidad = (int)CantidadTextBox.Text.ToInt(),
                Precio = Convert.ToDecimal(PrecioTextBox.Text),
              



                //PrecioTextBox.Text.ToInt(),
                //   Precio = Convert.ToInt32(PrecioTextBox),

            }) ;
         CargarGrid();
           Refrescar();
        //   ArticuloIdComBox.Text = string.Empty;
        //  CantidadTextBox.Text = string.Empty;
            // CantidadTextBox.Clear();
            //  PrecioTextBox.Focus();
           // MontoTextBox.Focus();
          //  PrecioTextBox.Text = string.Empty;
           
          /// MontoTextBox.Text = string.Empty;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas venta = new Ventas();

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
                   Refrescar();
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
            Ventas ventas = new Ventas();
            bool paso = false;

            if (!Validar())
                return;

          //  ventas = LlenaClase();
            Limpiar();

            //Determinar si es guardar o modificar

            if (string.IsNullOrWhiteSpace(VentaIdTextBox.Text) || (VentaIdTextBox.Text == "0"))
                paso = VentasBLL.Guardar(ventas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    paso = VentasBLL.Modificar(ventas);
                    MessageBox.Show(" modifico ", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                else
                {
                    Limpiar();
                    MessageBox.Show("No se puede modificar una venta que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
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
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

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

        private void ArticuloIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Articulos a = ArticuloIdComBox.SelectedItem as Articulos;
            if (a != null)
            {

                PrecioTextBox.Text = Convert.ToString(a.Precio);
                ExistenciaTexBox.Text = Convert.ToString(a.Existencia);

            }
        }
    }
}
