using System.Windows;
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

    }
}
