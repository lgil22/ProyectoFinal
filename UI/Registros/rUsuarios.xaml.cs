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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
       Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }

        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }
        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            TipoTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;

            Refrescar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios clientes = UsuariosBLL.Buscar((int)UsuarioIdTextBox.Text.ToInt());
            return (clientes != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MessageBox.Show("EL campo Nombres no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("EL campo Nombre Usuario no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NombreUsuarioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
            {
                MessageBox.Show("EL campo Clave no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ClaveTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TipoTextBox.Text))
            {
                MessageBox.Show("EL campo Tipo no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                TipoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("EL campo Email no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                EmailTextBox.Focus();
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

            if (string.IsNullOrWhiteSpace(UsuarioIdTextBox.Text) || UsuarioIdTextBox.Text == "0")
                paso = UsuariosBLL.Guardar(usuarios);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Usuario que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = UsuariosBLL.Modificar(usuarios);
            }

            //Informar el resultado
            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(UsuarioIdTextBox.Text, out id);

            Limpiar();

            try
            {
                Limpiar();
                Refrescar();


                if (UsuariosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                    Refrescar();
                }
                else
                {
                    MessageBox.Show(UsuarioIdTextBox.Text, "No se puede eliminar un cliente que no existe");
                }

            }
            catch
            {

            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarioAnterior = UsuariosBLL.Buscar(usuarios.UsuarioId);

            if (usuarioAnterior != null)
            {
                MessageBox.Show("Usuario Encontrado");
                usuarios = usuarioAnterior;
                Refrescar();
            }
            else
            {
                Limpiar();
                MessageBox.Show(" Usuario No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
