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
    /// Interaction logic for RegArticulos.xaml
    /// </summary>
    public partial class RegArticulos : Window
    {
        Articulos articulo = new Articulos();
        public RegArticulos()
        {
            InitializeComponent();
            this.DataContext = articulo;
            ArticuloIdTextBox.Text = "0";

        }
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = articulo;
        }
        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            UsuarioIdComboBox.SelectedItem = "0";
            DescripcionTextBox.Text = string.Empty;
            CategoriaIdComboBox.SelectedItem = "0";
            ExistenciaTextBox.Text = string.Empty;
            CostoIdTextBox.Text = "0";
            PrecioIdTextBox.Text = "0";

        }
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (articulo.ArticulosId == 0)
                paso = ArticulosBLL.Guardar(articulo);
            else
            {
                if(existeEnLaBaseDeDatos())
                    paso = ArticulosBLL.Modificar(articulo);
                else
                {
                    MessageBox.Show("No se puede modificar un Articulo que no existe");
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
            int id = Convert.ToInt32(CategoriaIdComboBox.SelectedItem);

            Limpiar();
             if(id > 0)
            {
                ArticulosBLL.Eliminar(id);
            }
            MessageBox.Show("No se puede eliminar un articulo que no existe");
        }

        private bool existeEnLaBaseDeDatos()
        {
            Articulos articuloAnterio = ArticulosBLL.Buscar(Convert.ToInt32(articulo.ArticulosId));

            return articuloAnterio != null;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articuloAnterior = ArticulosBLL.Buscar(articulo.ArticulosId);

            if (articuloAnterior != null)
            {

                articulo = articuloAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show("Articulo no encontrada");
            }
        }
    }
}
