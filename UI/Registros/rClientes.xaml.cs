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
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
       
    {
        Clientes clientes = new Clientes();

        public rClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
        }

        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        private void Limpiar()
        {
            this.clientes = new Clientes();
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

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MessageBox.Show("EL campo *Nombres* no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularTextBox.Text))
            {
                MessageBox.Show("EL campo *Celular* no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CelularTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                MessageBox.Show("EL campo *Cedula* no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CedulaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(FechaNacTimePicker.Text))
            {
                MessageBox.Show("EL campo *Fecha Nacimiento* no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                FechaNacTimePicker.Focus();
                paso = false;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            Limpiar();

            //Determinar si es guardar o modificar

            if (string.IsNullOrWhiteSpace(ClienteIdTextBox.Text) || ClienteIdTextBox.Text == "0")
                paso = ClientesBLL.Guardar(clientes);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Cliente que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ClientesBLL.Modificar(clientes);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ClienteIdTextBox.Text, out id);

            Limpiar();

            try
            {
                if (!string.IsNullOrWhiteSpace(ClienteIdTextBox.Text))
                {
                    MessageBox.Show("Deben de estar llenos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                Limpiar();

                if (Validar())
                {
                    MessageBox.Show("Vacio");
                }

                if (ClientesBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(ClienteIdTextBox.Text, "No se puede eliminar un cliente que no existe");
            }
            catch
            {

            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes clienteAnterior = ClientesBLL.Buscar(clientes.ClienteId);

            if (clienteAnterior != null)
            {
                MessageBox.Show("Cliente Encontrado");
                clientes = clienteAnterior;
                Refrescar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Cliente no encontrado");
            }

        }
    }
}
