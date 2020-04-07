using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaVentas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    
    void Application_DispatcherUnhandledEception(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show("Error", $"😒Error en la aplicacio😭:\n {e.Exception.Message}");
        e.Handled = true;
    }

  } 

}
