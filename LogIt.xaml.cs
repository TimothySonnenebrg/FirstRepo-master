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
using log4net;

namespace TJS.VehicleTracker.UI
{
    /// <summary>
    /// Interaction logic for LogIt.xaml
    /// </summary>
    public partial class LogIt : Window
    {
        log4net.ILog log = log4net.LogManager.GetLogger("Utility.Logger");

        public LogIt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(txtInfo.Text);
            }
        }
    }
}
