﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SistemaVentas.BLL;
using SistemaVentas.Entidades;
using SistemaVentas.UI.Registros;

namespace SistemaVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        CheckBox chk;
        List<CheckBox> checkBoxList = new List<CheckBox>();

        List<Ventas> ocultardetalle = new List<Ventas>();

        public cVentas()
        {
            InitializeComponent();

             for (int i = 1; i <= 20; i++) // AutoGeneratedColumns controlador de eventos que genera CheckBox (La cual oculta o muestra la columnas del dataGrid)
            {
                Ventas emp = new Ventas
                {
                    
                };
                ocultardetalle.Add(emp);
            }
            DataGridConsulta.AutoGeneratedColumns += new EventHandler(DetalleDataGridVentas_AutoGeneratedColumns);
            DataGridConsulta.ItemsSource = ocultardetalle;
        }


        private void DetalleDataGridVentas_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn item in DataGridConsulta.Columns)
            {
                chk = new CheckBox();
                checkBoxList.Add(chk);
                wrapColumns.Children.Add(chk);
                chk.Width = 100;
                chk.Height = 22;
                chk.Content = item.Header;
                chk.IsChecked = true;
                chk.Checked += new RoutedEventHandler(chk_Checked);
                chk.Unchecked += new RoutedEventHandler(chk_Unchecked);
            }
        }

        void chk_Unchecked(object sender, RoutedEventArgs e) /// metodo para ocultar las columnas
        {
            List<string> chkUnchekList = new List<string>();
            chkUnchekList.Clear();

            foreach (CheckBox item in checkBoxList)
            {
                if (item.IsChecked == false)
                {
                    chkUnchekList.Add(item.Content.ToString());
                }
            }

            foreach (DataGridColumn item in DataGridConsulta.Columns)
            {
                if (chkUnchekList.Contains(item.Header.ToString()))
                {
                    DataGridConsulta.Columns.Remove(item);
                    break;
                }
            }
        }

        void chk_Checked(object sender, RoutedEventArgs e) // metodo para mostrar las columnas
        {
            DataGridConsulta.AutoGeneratedColumns -= new EventHandler(DetalleDataGridVentas_AutoGeneratedColumns);

            List<string> chkCheckList = new List<string>();
            chkCheckList.Clear();

            foreach (CheckBox item in checkBoxList)
            {
                if (item.IsChecked == false)
                {
                    chkCheckList.Add(item.Content.ToString());
                }
            }

            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = ocultardetalle;

            foreach (string item in chkCheckList)
            {
                foreach (DataGridColumn column in DataGridConsulta.Columns)
                {
                    if (column.Header.ToString() == item)
                    {
                        DataGridConsulta.Columns.Remove(column);
                        break;
                    }
                }
            }
        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Todo
                        listado = VentasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.VentaId == id);
                        break;

                    case 2:
                        int clienteId;
                        clienteId = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.ClienteId == clienteId);
                        break;

                    case 3://Tipo Pago
                        listado = VentasBLL.GetList(p => p.TipoPago.Contains(CriterioTextBox.Text));
                        break;


                    case 4:
                        float monto;
                        monto = float.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.Monto == monto);
                        break;
                 

                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = VentasBLL.GetList(p => true);
            }
            DataGridConsulta.ItemsSource = null;
            DataGridConsulta.ItemsSource = listado;
        }
    }
    
}
