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

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = categoria;
        } 
        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

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
            if (CategoriaBLL.Eliminar(categoria.CategoriaId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar una persona que no existe");
            }
        }
        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            NombreCategoria.Text = string.Empty;
        }
        private bool existeEnLaBaseDeDatos()
        {
            Categoria categoriaAnterior = CategoriaBLL.Buscar(categoria.CategoriaId);

            return categoriaAnterior != null;
        }

       
    }
}
