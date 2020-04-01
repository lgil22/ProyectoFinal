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
            MontoTextBox.Text = "0";

           // reCargar();

        }


        private bool existeEnLaBaseDeDatos()
        {
            NotasCreditos creditoAnterior = NotasCreditosBLL.Buscar((int)NotaIdTextBox.Text.ToInt());

            return creditoAnterior != null;
        }



        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            NotasCreditos creditos = NotasCreditosBLL.Buscar((NotaIdTextBox.Text.ToInt()));

            //  Limpiar();

            if (credito != null)
            {
                credito = creditos;
                reCargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void GuardarButton_Click_1(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (!Validar())
                return;

            Limpiar();

            //Determinar si es guardar o modificar

            if (string.IsNullOrWhiteSpace(NotaIdTextBox.Text) || NotaIdTextBox.Text == "0")
                paso = NotasCreditosBLL.Guardar(credito);
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Cliente que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = NotasCreditosBLL.Modificar(credito);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NotaIdTextBox.Text))
            {
                MessageBox.Show("EL campoNotaId no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                NotaIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(conceptoTextBox.Text))
            {
                MessageBox.Show("EL campo concepto  no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                conceptoTextBox.Focus();
                paso = false;
            }

            return paso;
        }
        private void EliminarButton_Click_1(object sender, RoutedEventArgs e)
        {

            int id;
            int.TryParse(NotaIdTextBox.Text, out id);

            Limpiar();

            try
            {
                Limpiar();


                if (ClientesBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(NotaIdTextBox.Text, "No se puede eliminar un cliente que no existe");
                }

            }
            catch
            {

            }
        }
    
        private void NuevobButton_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
       
    }
}
