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
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = ventas;
        }
        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = ventas;
        }
        private void Limpiar()
        {
            this.ventas = new Ventas();
            DetalleDataGridVentas.ItemsSource = new List<VentaDetalles>();
            Refrescar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Clientes clientes = ClientesBLL.Buscar((int)ClienteIdTextBox.Text.ToInt());
            return (clientes != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(TipoPagoTextBox.Text))
            {
                MessageBox.Show("EL campo Tipo Pago no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                TipoPagoTextBox.Focus();
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
                ArticuloIdTextBox.Focus();
                CantidadTextBox.Focus();
                PrecioTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void AgregarDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGridVentas.ItemsSource != null)
            {
                this.ventas.Detalles = (List<VentaDetalles>)DetalleDataGridVentas.ItemsSource;
            }

            //Agregar un nuevo detalle con los datos introducidos

            this.ventas.Detalles.Add(new VentaDetalles
            {
                ArticuloId = ArticuloIdTextBox.Text.ToInt(),
                Cantidad = CantidadTextBox.Text.ToInt(),
                Precio = PrecioTextBox.Text.ToInt(),
                //   Precio = Convert.ToInt32(PrecioTextBox),

            });
            Refrescar();
            ArticuloIdTextBox.Focus();
            ArticuloIdTextBox.Clear();
            CantidadTextBox.Focus();
            CantidadTextBox.Clear();
            PrecioTextBox.Focus();
            PrecioTextBox.Clear();
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
            if (DetalleDataGridVentas.Items.Count > 0 && DetalleDataGridVentas.SelectedItem != null)
            {
                //remover la fila
                ventas.Detalles.RemoveAt(DetalleDataGridVentas.SelectedIndex);
                Refrescar();
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

            if (string.IsNullOrWhiteSpace(VentaIdTextBox.Text) || VentaIdTextBox.Text == "0")
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
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);

            Limpiar();

            if (VentasBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(VentaIdTextBox.Text, "No se puede eliminar una venta que no existe");
        }

     
    }
}