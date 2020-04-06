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
            LlenaComBoxCliente();
            LlenaComBoxUsuario();
           // NotaIdTextBox.Text = "0";
        }
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = credito;
        }

        private void Limpiar()
        {
            NotaIdTextBox.Text = "0";
            FechaDatePicker.DisplayDate = DateTime.Now;
            ClienteIdComBox.Text = "0";
            UsuarioIdComboBox.Text = "0";
            conceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = "0";


           //credito = new NotasCreditos();

          // reCargar();

        }

        private void LlenaComBoxCliente()  ///Metodo que nos ayudara a cargar el id Cliente que ya se tiene registrado...
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado4 = new List<Clientes>();
            listado4 = db.GetList(p => true);
            ClienteIdComBox.ItemsSource = listado4;
            ClienteIdComBox.SelectedValue = "ClienteId";
            ClienteIdComBox.DisplayMemberPath = "ClienteId";
        }


        private void LlenaComBoxUsuario()  ///Metodo que nos ayudara a cargar el id Usuario que ya se tiene registrado...
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            var listado5= new List<Usuarios>();
            listado5 = db.GetList(p => true);
            UsuarioIdComboBox.ItemsSource = listado5;
            UsuarioIdComboBox.SelectedValue = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "UsuarioId";
        }

      
        private bool existeEnLaBaseDeDatos()
        {
            NotasCreditos creditoAnterior = NotasCreditosBLL.Buscar((int)NotaIdTextBox.Text.ToInt());

            return creditoAnterior != null;
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
    
        private void NuevobButton_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            NotasCreditos creditos = NotasCreditosBLL.Buscar(credito.NotaId);

            if (creditos != null)
            {
                credito = creditos;
                reCargar();
            }
            else
            {
                MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(NotaIdTextBox.Text, out id);
            Limpiar();

            try
            {
                if (NotasCreditosBLL.Eliminar(credito.NotaId))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(NotaIdTextBox.Text, "No se puede eliminar no existe");
                }
            }
            catch
            {

            }

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            Limpiar();

            //Determinar si es guardar o modificar

            if (credito.NotaId == 0)
            {

                paso = NotasCreditosBLL.Guardar(credito);
            }
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    paso = NotasCreditosBLL.Modificar(credito);
                    MessageBox.Show("modifico ", "Existo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    Limpiar();
                    MessageBox.Show("No Existe en la base de datos", "ERROR");
                    return;
                }
            }

            //Informar el resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
