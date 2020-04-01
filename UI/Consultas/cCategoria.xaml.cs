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

namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCategoria.xaml
    /// </summary>
    public partial class cCategoria : Window
    {
        public cCategoria()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Categoria>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = CategoriaBLL.GetList(o => true);
                        break;

                    case 1: //Categoria Id
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = CategoriaBLL.GetList(o => o.CategoriaId == id);
                        break;

                    case 3:// Nombre Categoria

                        listado = CategoriaBLL.GetList(p => p.NombreCategoria.Contains(CriterioTextBox.Text));
                        break;


                }


            }
            else
            {
                listado = CategoriaBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }
    
}
