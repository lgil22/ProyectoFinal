using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = UsuariosBLL.GetList(o => true);
                        break;

                    case 1: //Usuario Id
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = UsuariosBLL.GetList(o => o.UsuarioId == id);
                        break;

                    case 3://Nombres
                        listado = UsuariosBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Nombre Usuario
                        listado = UsuariosBLL.GetList(p => p.NombreUsuario.Contains(CriterioTextBox.Text));
                        break;

                    case 5://Clave
                        listado = UsuariosBLL.GetList(p => p.Clave.Contains(CriterioTextBox.Text));
                        break;


                    case 6://Email
                        listado = UsuariosBLL.GetList(p => p.Email.Contains(CriterioTextBox.Text));
                        break;

                    case 7://Email
                        listado = UsuariosBLL.GetList(p => p.Tipo.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = UsuariosBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }

    }
}
