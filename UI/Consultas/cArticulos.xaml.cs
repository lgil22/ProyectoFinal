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
    /// Interaction logic for cArticulos.xaml
    /// </summary>
    public partial class cArticulos : Window
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            
                var listado = new List<Articulos>();
                if (CriterioTextBox.Text.Trim().Length > 0)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0: //Todo
                            listado = ArticulosBLL.GetList(o => true);
                            break;

                        case 1: //Articulo Id
                            int id;
                            id = int.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.ArticulosId == id);
                            break;

                        case 2: // usuario Id
                            int usuario;
                            usuario = int.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.UsuarioId == usuario);
                            break;

                        case 3:// Nombre Descripcion
                            listado = ArticulosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                            break;

                        case 4: //Categoria ID
                            int catid;
                            catid = int.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.CategoriaId == catid);
                            break;


                        case 5: //Existencia
                            int Ext;
                            Ext = int.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.Existencia == Ext);
                            break;


                        case 6: //costo
                            decimal cost;
                            cost = decimal.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.Existencia == cost);
                            break;

                        case 7: //Precio
                            decimal pre;
                            pre = decimal.Parse(CriterioTextBox.Text);
                            listado = ArticulosBLL.GetList(o => o.Existencia == pre);
                            break;


                    }

                     }
                else
                {
                    listado = ArticulosBLL.GetList(p => true);
                }
                DataGridConsulta.ItemsSource = null;
                DataGridConsulta.ItemsSource = listado;
            }
        }
    }

