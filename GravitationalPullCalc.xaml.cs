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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TJS.GravCalculator.BL;

namespace TJS.GravCalculator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double mass1, mass2, distance;


            //mass1 = (double)(object)txtMass1.Text;


            try
            {
                 if (double.TryParse(txtMass1.Text, out mass1))
                 {
                      if (double.TryParse(txtMass2.Text, out mass2))
                      {
                        if (double.TryParse(txtDistance.Text, out distance))
                        {                        
                         double forceDueToGravity = BL.ForceHelpers.GetForceDueToGravity(mass1, mass2, distance);
                         lblGravPullResult.Content = forceDueToGravity;

                            txtMass1.Focus();
                        }
                      }
                 }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }
    }
}
