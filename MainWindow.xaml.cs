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

namespace SistemaVentas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int iD)
        {
            InitializeComponent();
        }

        public MainWindow()
        {
        }

        private void MenuArticulos_Click(object sender, RoutedEventArgs e)
        {
            RegArticulos regArt = new RegArticulos();
            regArt.Show();
        }

        private void MenuCategorias_Click(object sender, RoutedEventArgs e)
        {
            RegCategoria regCat = new RegCategoria();
            regCat.Show();
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
