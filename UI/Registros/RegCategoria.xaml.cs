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
    /// Interaction logic for RegCategoria.xaml
    /// </summary>
    public partial class RegCategoria : Window
    {

        Categoria categoria = new Categoria();
        public RegCategoria()
        {    
            
            InitializeComponent();
            this.DataContext = categoria;
            CategoriaIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            NombreCategoriaTextBox.Text = string.Empty;
            //reCargar();
        }
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = categoria;
        } 
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(CategoriaIdTextBox.Text))
            {
                MessageBox.Show("EL campo categoriaID no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                CategoriaIdTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombreCategoriaTextBox.Text))
            {
                MessageBox.Show("EL campo NombreCategoria no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombreCategoriaTextBox.Focus();
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

    
            if (categoria.CategoriaId == 0)
            {
                paso = CategoriaBLL.Guardar(categoria);
            }
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    paso = CategoriaBLL.Modificar(categoria);
                    MessageBox.Show(" modifico ", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
                  

                }
                else
                {
                    Limpiar();
                    MessageBox.Show("No se puede modificar una categoria que no existe");
                    return;

                }
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoriaAnterior = CategoriaBLL.Buscar(categoria.CategoriaId);

            if (categoriaAnterior != null)
            {
                
                categoria = categoriaAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show("Categoria no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(CategoriaIdTextBox.Text, out id);

            
            try
            {
                if (CategoriaBLL.Eliminar(categoria.CategoriaId))
                {
                    Limpiar();
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show(CategoriaIdTextBox.Text, "No se puede eliminar un cliente que no existe");
            }
            catch
            {

            }


        }


        private bool existeEnLaBaseDeDatos()
        {
            Categoria categoriaAnterior = CategoriaBLL.Buscar((int)CategoriaIdTextBox.Text.ToInt());

            return categoriaAnterior != null;
        }

       
    }
}



