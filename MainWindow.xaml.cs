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

namespace SistemaVentas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            RegCategoria c = new RegCategoria();
            c.Show();
        }

        private void NotaCreditoButton_Click(object sender, RoutedEventArgs e)
        {
            RegNotasCreditos n = new RegNotasCreditos();
            n.Show();
        }

        private void ArticuloButton_Click(object sender, RoutedEventArgs e)
        {

           
            RegArticulos a = new RegArticulos();
            a.Show();
           
        }

        
    }
}
