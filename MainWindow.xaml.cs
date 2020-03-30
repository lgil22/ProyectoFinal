using SistemaVentas.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SistemaVentas.UI;
using SistemaVentas.BLL;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Entidades;
//using SistemaVentas.UI.Inicio;
using System.Data.SqlClient;
using SistemaVentas.UI.Inicio;

namespace SistemaVentas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //RepositorioBase<Usuarios> RepositorioUsuario = new RepositorioBase<Usuarios>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = this.UsuarioTextBox.Text;
            string password = this.PasswordBox.Password;

            if (usuario == "" && password == "")
            { 
                MessageBox.Show(usuario, "Ingrese Datos Correctos", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                MessageBox.Show("Favor Llene los campos");
            }

            if (password == "")
            {
                MessageBox.Show("Debe agregar una Contraseña", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                PasswordBox.Focus();
            }
            else

            if (usuario == "Admin" && password == "1234")
            {
                MenuPrincipal menuP = new MenuPrincipal();
                menuP.Show();
                this.Close();
                return;

            }
        }
        
   
    }
}

