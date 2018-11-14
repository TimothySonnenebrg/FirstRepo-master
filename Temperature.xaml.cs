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
using System.Windows.Shapes;
using TJS.Temperature.BL;

namespace TJS.Temperature.WPFUI
{
    /// <summary>
    /// Interaction logic for Temperature.xaml
    /// </summary>
    public partial class Temperature : Window
    {
        public Temperature()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double dblInTemp;
            double dblOutTemp = 0;
            string suffix = string.Empty ;
            

            if (double.TryParse(txtInTemp.Text, out dblInTemp))
            {
                if ((bool)rbtnToCelsius.IsChecked)
                {
                    dblOutTemp = TempConverter.ConvertToC(dblInTemp);
                    suffix = "°C";
                }
                else
                {
                    dblOutTemp = TempConverter.ConvertToF(dblInTemp);
                    suffix = "°F";  //to get special characters hold alt 248
                 }
            }
            
            lblOutTemp.Content = dblOutTemp.ToString("n1") + suffix;
        }
    }
}
