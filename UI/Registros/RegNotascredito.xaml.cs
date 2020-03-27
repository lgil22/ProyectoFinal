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
    /// Interaction logic for RegNotasCreditos.xaml
    /// </summary>
    public partial class RegNotasCreditos : Window
    {
        NotasCreditos credito = new NotasCreditos();

        public RegNotasCreditos()
        {

            InitializeComponent();
            this.DataContext = credito;
            NotaIdTextBox.Text = "0";
        }
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = credito;
        }
      
        private void Limpiar()
        {
            NotaIdTextBox.Text = "0";
            FechaDatePicke.DisplayDate = DateTime.Now;
            ClienteIdComboBox.SelectedItem = "0";
            UsuarioIdComboBox.SelectedItem = "0";
            conceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = "1";


        }
        

        private bool existeEnLaBaseDeDatos()
        {
            NotasCreditos creditoAnterior = NotasCreditosBLL.Buscar(credito.NotaId);

            return creditoAnterior != null;
        }
        

       
        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            NotasCreditos creditoAnterior = NotasCreditosBLL.Buscar(credito.NotaId);

            if (creditoAnterior != null)
            {
                credito = creditoAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show(" no encontrada");
            }
        }

        private void GuardarButton_Click_1(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (credito.NotaId == 0)
                paso = NotasCreditosBLL.Guardar(credito);
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = NotasCreditosBLL.Modificar(credito);
                else
                {
                    MessageBox.Show("No se puede modificar una notaId que no existe");
                    return;
                }
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar");
                }
            }
        }

        private void EliminarButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (NotasCreditosBLL.Eliminar(credito.NotaId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar  no existe");
            }
        }

        private void NuevobButton_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
