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
        }

        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            NombreCategoriaCombro.Text = string.Empty;

            reCargar();
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
            if (string.IsNullOrWhiteSpace(NombreCategoriaCombro.Text))
            {
                MessageBox.Show("EL campo NombreCategoria no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombreCategoriaCombro.Focus();
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
                if (existeEnLaBaseDeDatos())
                    paso = CategoriaBLL.Modificar(categoria);
                else
                {
                    MessageBox.Show("No se puede modificar una categoria que no existe");
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoriaAnterior = CategoriaBLL.Buscar(categoria.CategoriaId);

            if (categoriaAnterior != null)
            {
                MessageBox.Show("Categoria Encontrada");
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

            Limpiar();

            try
            {
                if (!string.IsNullOrWhiteSpace(CategoriaIdTextBox.Text))
                {
                    MessageBox.Show("Deben de estar el campo Id campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Limpiar();

                if (CategoriaBLL.Eliminar(id))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    MessageBox.Show(CategoriaIdTextBox.Text, "No se puede eliminar una categoria que no existe");
                }
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



