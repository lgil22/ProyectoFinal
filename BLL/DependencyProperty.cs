using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SistemaVentas.BLL
{
    public class IntegerContainer : FrameworkElement
    {
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
         "Value",
         typeof(int),
         typeof(IntegerContainer),
         new UIPropertyMetadata(0));
    }

}