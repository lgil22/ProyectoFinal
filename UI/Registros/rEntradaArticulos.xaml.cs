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
using SistemaVentas.DAL;

namespace SistemaVentas.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEntradaArticulos.xaml
    /// </summary>
    public partial class rEntradaArticulos : Window
    {
       EntradaArticulos entrada = new EntradaArticulos();
        public rEntradaArticulos()
        {
            InitializeComponent();
           this.DataContext = entrada;
            EntradaIdTextBox.Text = "0";
           LlenaComBoxArticulo();
        }

        private void Limpiar()
        {
            EntradaIdTextBox.Text = "0";
            ArticuloIdComBox.Text = null;
            EntradaTextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
          //  LlenaComBoxArticulo();
            //Refrescar();
        }

    
       private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = entrada;
        }


        private void LlenaComBoxArticulo()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            var listado = new List<Articulos>();
            listado = db.GetList(p => true);
            ArticuloIdComBox.ItemsSource = listado;
            ArticuloIdComBox.SelectedValue = "ArticulosId";
            ArticuloIdComBox.DisplayMemberPath = "Descripcion";

        }


        private bool Validar()
        {

            bool paso = true;
       

            if (ArticuloIdComBox.Text == "")
            {
                MessageBox.Show(ArticuloIdComBox.Text, "Elija el producto");
                ArticuloIdComBox.Focus();
                paso = false;
            }

            if  ((int)(EntradaTextBox.Text.ToInt()) < 1)
            {
                MessageBox.Show(EntradaTextBox.Text, "La entrada debe ser mayor a 1");
                EntradaTextBox.Focus();
                paso = false;

            }

            return paso;
        }


        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<EntradaArticulos> db = new RepositorioBase<EntradaArticulos>();
            EntradaArticulos entrada = db.Buscar((int)EntradaIdTextBox.Text.ToInt());
            return (entrada != null);

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            EntradaArticulos entrada = new EntradaArticulos();
            bool paso = false;

            if (!Validar())
                return;


            if (EntradaIdTextBox.Text == "0")
            {
                paso = EntradaArticulosBLL.Guardar(entrada);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Entrada que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = EntradaArticulosBLL.Modificar(entrada);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EntradaIdTextBox.Text, out id);

            RepositorioBase<EntradaArticulos> db = new RepositorioBase<EntradaArticulos>();
            try
            {
                if ((int)(EntradaTextBox.Text.ToInt()) > 0)
                {
                    if (EntradaArticulosBLL.Eliminar(entrada.EntradaId))
                    {
                        MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar", "Atencion!!", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar", "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            RepositorioBase<EntradaArticulos> entArt = new RepositorioBase<EntradaArticulos>();
            EntradaArticulos entrada = new EntradaArticulos();

            int.TryParse(EntradaIdTextBox.Text, out id);

            Limpiar();

            entrada = entArt.Buscar(id);


             if (entrada != null)
             {

                MessageBox.Show("Entrada Encontrada");
                Refrescar();
             }
                else
                {
                    MessageBox.Show("Entrada no encontrada");
                }

            }
      }  
}
