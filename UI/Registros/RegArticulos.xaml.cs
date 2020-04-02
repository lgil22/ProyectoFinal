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
        Articulos articulos= new Articulos();
        public RegArticulos()
        {
            InitializeComponent();
            this.DataContext = articulos;

        }
       /* public void LlenaComboBoxCategorias() // Funcion encargada de llenar el ComboBox de las categorias
       {
            CategoriaBLL categoria = new CategoriaBLL();
            var categorias = new List<Categoria>();
            categorias = categoria.GetList(p => true);
            CategoriaIdComboBox.SelectedItem = categorias;
            CategoriaIdComboBox.ItemsSource = "CategoriaId";
            CategoriaIdComboBox.Tag = "Nombre";
        }*/
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = articulos;
        }
        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            UsuarioIdComboBox.SelectedItem = "";
            DescripcionTextBox.Text = string.Empty;
            CategoriaIdComboBox.SelectedItem = "";
            ExistenciaTextBox.Text = "0";
            CostoIdTextBox.Text = "0";
            PrecioIdTextBox.Text = "0";


           // reCargar();

        }
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text))
            {
                MessageBox.Show("ArticuloId estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ArticuloIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("EL campo Existencia no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ExistenciaTextBox.Focus();
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


            if (articulos.ArticulosId == 0)
            {
                paso = ArticulosBLL.Guardar(articulos);
            }
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = ArticulosBLL.Modificar(articulos);
                else
                {
                    MessageBox.Show("No se puede modificar una categoria que no existe");

                }


                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            
        }



        private bool existeEnLaBaseDeDatos()
        {
            Articulos articuloAnterio = ArticulosBLL.Buscar((int)ArticuloIdTextBox.Text.ToInt());

            return articuloAnterio != null;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articuloAnterior = ArticulosBLL.Buscar(articulos.ArticulosId);

            if (string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text))
            {
                MessageBox.Show(ArticuloIdTextBox.Text, "Coloque id de, Articulo");
            }

            if (articuloAnterior != null)
            {
                articulos = articuloAnterior;
                reCargar();
            }

            else
            {
                MessageBox.Show("No existe ninguna Articulo con ese Id.");

            }



        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoIdTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoIdTextBox.Text);

                PrecioIdTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void CostoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoIdTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoIdTextBox.Text);

                PrecioIdTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void PrecioIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoIdTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoIdTextBox.Text);

                PrecioIdTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticulosBLL.Eliminar(articulos.ArticulosId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito");
            }
            else
            {
                MessageBox.Show("No se puede eliminar un articulo que no existe");

            }
        }
    }

}
