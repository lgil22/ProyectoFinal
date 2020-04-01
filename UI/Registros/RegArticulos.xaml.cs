﻿using SistemaVentas.BLL;
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
            this.DataContext = articulo;
        }
        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            UsuarioIdComboBox.SelectedItem = null;;
            DescripcionTextBox.Text = string.Empty;
            CategoriaIdComboBox.SelectedItem = null;
            ExistenciaTextBox.Text = string.Empty;
            CostoIdTextBox.Text = string.Empty;
            PrecioIdTextBox.Text = string.Empty;

            articulo = new Articulos();

            reCargar();

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

            //Determinar si es guardar o modificar

            // if (string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text) || ArticuloIdTextBox.Text == "0")
            if (articulo.ArticulosId == 0)
            {

                paso = ArticulosBLL.Guardar(articulo);
            }
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    paso = ArticulosBLL.Modificar(articulo);
                    MessageBox.Show("No se puede modificar un Cliente que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                else
                {
                    MessageBox.Show("No Existe en la base de datos", "ERROR");
                    return;
                }

                //Informar el resultado
                if (paso)
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
        //    int id;
         //   int.TryParse(ArticuloIdTextBox.Text, out id);

            //Limpiar();

          //  try
           // {
               // Limpiar();
                if (ArticulosBLL.Eliminar(articulo.ArticulosId))
                {
                    Limpiar();
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(ArticuloIdTextBox.Text, "No se puede eliminar un cliente que no existe");
                }

        }

        private bool existeEnLaBaseDeDatos()
        {
            Articulos articuloAnterio = ArticulosBLL.Buscar((int)ArticuloIdTextBox.Text.ToInt());

            return articuloAnterio != null;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos = ArticulosBLL.Buscar(articulo.ArticulosId);

       
            if (articulo != null)
            {
                articulo = articulos;
               // reCargar();
            }
            else
            {
               
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);

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

        

    }

}
