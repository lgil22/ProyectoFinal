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
           LlenaComBoxUsuario();
           LlenaComBoxCategoria();
            //ArticuloIdTextBox.Text = "0";

        }
      
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = articulo;
        }
        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            UsuarioIdComboBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            CategoriaIdComboBox.Text = "0";
            ExistenciaTextBox.Text = "0";
            CostoIdTextBox.Text = "0";
            PrecioIdTextBox.Text = "0";

            //  articulo = new Articulos();

            // reCargar();

        }
       

        private void LlenaComBoxUsuario()  ///Metodo que nos ayudara a cargar el id Usuario que ya se tiene registrado...
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            var listado3 = new List<Usuarios>();
            listado3 = db.GetList(p => true);
            UsuarioIdComboBox.ItemsSource = listado3;
            UsuarioIdComboBox.SelectedValue = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "Nombres";
        }

        private void LlenaComBoxCategoria()  ///Metodo que nos ayudara a cargar el id Categoria que ya se tiene registrado...
        {
            RepositorioBase<Categoria> db = new RepositorioBase<Categoria>();
            var listado4 = new List<Categoria>();
            listado4 = db.GetList(p => true);
            CategoriaIdComboBox.ItemsSource = listado4;
            CategoriaIdComboBox.SelectedValue = "CategoriaId";
            CategoriaIdComboBox.DisplayMemberPath = "NombreCategoria";
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
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MessageBox.Show("EL campo Descripcion no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ExistenciaTextBox.Focus();
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

         
           
            if (articulo.ArticulosId == 0)
            {

                paso = ArticulosBLL.Guardar(articulo);
            }
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    paso = ArticulosBLL.Modificar(articulo);
                    MessageBox.Show(" modifico ", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);

                }
 
            }
                //Informar el resultado
                if (paso)
            {

            }
                    
                else
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
  
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            int id;
            int.TryParse(ArticuloIdTextBox.Text, out id);

            Limpiar();
            try
            {
                if (ArticulosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                   MessageBox.Show(ArticuloIdTextBox.Text, "No se puede eliminar un cliente que no existe");
            }
            catch
            {

            }


        }

        private bool existeEnLaBaseDeDatos()
        {
            Articulos articuloAnterio = ArticulosBLL.Buscar((int)ArticuloIdTextBox.Text.ToInt());

            return (articuloAnterio != null);
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
          
            Articulos articuloAnterio = ArticulosBLL.Buscar(ArticuloIdTextBox.Text.ToInt());
     
           
            if (articuloAnterio != null)
            {
                
                articulo = articuloAnterio;
                reCargar();
            }
            else
            {
                MessageBox.Show("Articulo no Encontrado");
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
