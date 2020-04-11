using System.Windows;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using SistemaVentas.UI.Consultas;
using SistemaVentas.UI.Registros;

namespace SistemaVentas.UI.Inicio
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        
        public MenuPrincipal()
        {
            InitializeComponent();

           // UsuarioActivoTextBox.Text = ("Usuario Activo: Admin" .ToString());
        }

        private void MenuEntradaArticulos_Click(object sender, RoutedEventArgs e)
        {
            rEntradaArticulos regEnt = new rEntradaArticulos();
            regEnt.Show();
        }

        private void MenuCategorias_Click(object sender, RoutedEventArgs e)
        {
            RegCategoria regCat = new RegCategoria();
            regCat.Show();
        }
        private void MenuArticulos_Click(object sender, RoutedEventArgs e)
        {
            RegArticulos regArt = new RegArticulos();
            regArt.Show();
        }

        private void MenuCobros_Click(object sender, RoutedEventArgs e)
        {
            RegCobro regCob = new RegCobro();
            regCob.Show();
        }


        private void MenuNotasCreditos_Click(object sender, RoutedEventArgs e)
        {
            RegNotasCreditos regCred = new RegNotasCreditos();
            regCred.Show();
        }

        private void MenuClientes_Click(object sender, RoutedEventArgs e)
        {
            rClientes regC = new rClientes();
            regC.Show();
        }

        private void MenuUsuarios_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios regU = new rUsuarios();
            regU.Show();
        }

        private void MenuVentas_Click(object sender, RoutedEventArgs e)
        {
            rVentas regV = new rVentas();
            regV.Show();
        }

        private void MenuDeudas_Click(object sender, RoutedEventArgs e)
        {
            rDeudaClientes regD = new rDeudaClientes();
            regD.Show();
        }
        private void MenuCVentas_Click(object sender, RoutedEventArgs e)
        {
           cVentas cVent = new cVentas();
           cVent.Show();
        }


        private void MenuDeudasC_Click(object sender, RoutedEventArgs e)
        {
            cDeudasClientes cDeud = new cDeudasClientes();
            cDeud.Show();
        }


        private void MenuCclientes_Click(object sender, RoutedEventArgs e)
        {
            cClientes cC = new cClientes();
            cC.Show();
        }

        private void MenuCusuarios_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cU = new cUsuarios();
            cU.Show();
        }

            private void MenucCobros_Click(object sender, RoutedEventArgs e)
        {
            cCobros cC = new cCobros();
            cC.Show();
        }
        private void MenucArticulos_Click(object sender, RoutedEventArgs e)
        {
            cArticulos Art = new cArticulos();
            Art.Show();
        }
        private void MenucNotaCredito_Click(object sender, RoutedEventArgs e)
        {
            cNotaCredito nt = new cNotaCredito();
            nt.Show();
        }
        private void MenucCategoria_Click(object sender, RoutedEventArgs e)
        {
            cCategoria C = new cCategoria();
            C.Show();
        }

        private void CerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.Show();
        }

    }
}
