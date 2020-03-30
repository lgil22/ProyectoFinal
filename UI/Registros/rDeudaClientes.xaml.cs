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
using SistemaVentas.Entidades;

namespace SistemaVentas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rDeudaClientes.xaml
    /// </summary>
    public partial class rDeudaClientes : Window
    {
        DeudaClientes deudas = new DeudaClientes();
        public rDeudaClientes()
        {
            InitializeComponent();
            this.DataContext = deudas;
        }

        private static rDeudaClientes unico = null;

        public static rDeudaClientes Funcion()
        {
            if (unico == null)
            {
                unico = new rDeudaClientes();
            }
            return unico;

        }

        private void Limpiar()
        {
            DeudasIdTextBox.Clear();
            NombreClienteTextBox.Clear();
            DeudasIdTextBox.Clear();

            Efectivo.Clear();
            Devuelta.Clear();

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            DeudaClientes deudaAnterior = DeudaClientesBLL.Buscar(deudas.DeudasId);

            if (deudaAnterior != null)
            {
                MessageBox.Show("La deuda ha sido saldada.");
                Limpiar();
                deudas = deudaAnterior;
                // reCargar();
            }
            else
            {
                MessageBox.Show("No se pudo Saldar la deuda.");
            }


        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            DeudaClientes deudaAnterior = DeudaClientesBLL.Buscar(deudas.DeudasId);

            if (string.IsNullOrWhiteSpace(DeudasIdTextBox.Text))
            {
                MessageBox.Show(DeudasIdTextBox.Text, "Coloque id de, deuda");
                Limpiar();
            }

            if (deudaAnterior != null)
            {
                MessageBox.Show("Categoria Encontrada");
                deudas = deudaAnterior;
                //reCargar();
            }


            else
            {
                MessageBox.Show("No existe ninguna Deuda con ese Id.");
                Limpiar();
            }


        }


        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreClienteTextBox.Text))
            {
                MessageBox.Show("EL campo Nombre Cliente no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombreClienteTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(Deuda.Text))
            {
                MessageBox.Show("EL campo NombreCategoria no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                Deuda.Focus();
                paso = false;
            }


            return paso;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Categoria categoriaAnterior = CategoriaBLL.Buscar(Convert.ToInt32(deudas.DeudasId));

            return categoriaAnterior != null;
        }



        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (!Validar())
                return;
            Limpiar();


            if (deudas.DeudasId == 0)
            {
                paso = DeudaClientesBLL.Guardar(deudas);
            }
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = DeudaClientesBLL.Modificar(deudas);
                else
                {
                    MessageBox.Show("No se puede modificar una categoria que no existe");
                    return;
                }
            }
        }


        private void CalcularDevuelta()
        {
            if (string.IsNullOrWhiteSpace(Deuda.Text))
            {
                MessageBox.Show("  Opciones \n -Realice busqueda \n -Registre una deuda");
            }
            else
            {
                decimal efevtivo = Convert.ToDecimal(Efectivo.Text);
                decimal deuda = Convert.ToDecimal(Deuda.Text);
                decimal tota = efevtivo - deuda;
                Devuelta.Text = tota.ToString();
            }

        }

     
    }

}

         