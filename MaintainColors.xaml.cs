using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using TJS.VehicleTracker.BL;

namespace TJS.VehicleTracker.UI
{
    /// <summary>
    /// Interaction logic for MaintainColors.xaml
    /// </summary>
    public partial class MaintainColors : Window
    {
        BL.ColorList colors;
        BL.Color color;


        public MaintainColors()
        {
            InitializeComponent();
        }

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-ApiKey", "12345");
            Uri BaseAddress = new Uri(Properties.Settings.Default.ServiceURL);

            client.BaseAddress = BaseAddress;
            return client;
        }

        private void Reload()
        {
            //make the client 
            HttpClient client = InitializeClient();
            HttpResponseMessage response;
            string result;
            dynamic items;

            //Call api
            response = client.GetAsync("Color").Result;

            result = response.Content.ReadAsStringAsync().Result;

            items = (JArray)JsonConvert.DeserializeObject(result);

            colors = new ColorList();

            //cool line 
            colors = items.ToObject<ColorList>();

            cboColor.ItemsSource = colors;
            cboColor.DisplayMemberPath = "Description";
            cboColor.SelectedValuePath = "Id";
        }

        private void cpCode_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            var colorProperty = typeof(Colors).GetProperties().FirstOrDefault(p => (System.Windows.Media.Color)(p.GetValue(p, null)) == e.NewValue);   // Line to notice

            txtColor.Text = (colorProperty != null) ? colorProperty.Name : color.Description;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void cboColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboColor.SelectedIndex > - 1)
            {
                color = colors[cboColor.SelectedIndex];
                txtColor.Text = color.Description;
                //select the color in the color picker
                byte[] colorCode = BitConverter.GetBytes(color.ColorCode);
                cpCode.SelectedColor = System.Windows.Media.Color.FromRgb(colorCode[2], 
                                                                          colorCode[1], 
                                                                          colorCode[0]);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Make the color object
                color = new BL.Color();
                color.Description = txtColor.Text;
                int colorCode = BitConverter.ToInt32(new byte[] {  cpCode.SelectedColor.Value.B,
                                                                   cpCode.SelectedColor.Value.G,
                                                                   cpCode.SelectedColor.Value.R,
                                                                   0x00}, 0);

                color.ColorCode = colorCode;

                // Interact wit api to insert
                HttpClient client = InitializeClient();
                string serializedColor = JsonConvert.SerializeObject(color);
                var content = new StringContent(serializedColor);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("Color", content).Result;

                Reload();
            }
            catch (Exception ex)
            {

               
            }
        }

        private static string ProcessParameters(Guid id)
        {
            Dictionary<string, string> urlParams = new Dictionary<string, string>();
            urlParams.Add("Id", id.ToString());

            string paramlist = string.Empty;
            int count = 1;
            int totalParams = urlParams.Count; 
 
            foreach (var urlParam in urlParams)
            {
                if (count == 1)                
                    paramlist += "?";

                paramlist += urlParam.Key + "=" + urlParam.Value;

                if (count < totalParams)
                    paramlist += "&";
                count++;
            }
            return paramlist;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboColor.SelectedIndex > -1)
                {
                    color = colors[cboColor.SelectedIndex];
                    HttpClient client = InitializeClient();
                    string parmlist = ProcessParameters(color.Id);

                    color.Description = txtColor.Text;
                    int colorCode = BitConverter.ToInt32(new byte[] {  cpCode.SelectedColor.Value.B,
                                                                   cpCode.SelectedColor.Value.G,
                                                                   cpCode.SelectedColor.Value.R,
                                                                   0x00}, 0);

                    color.ColorCode = colorCode;


                    string serializedColor = JsonConvert.SerializeObject(color);
                    var content = new StringContent(serializedColor);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = client.PostAsync("Color", content).Result;

                    Reload();
                }

            }
            catch (Exception ex)
            {

               
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboColor.SelectedIndex > -1)
                {
                    color = colors[cboColor.SelectedIndex];
                    HttpClient client = InitializeClient();
                    string parmlist = ProcessParameters(color.Id);
                                        
                    HttpResponseMessage response = client.DeleteAsync("Color" + parmlist).Result;

                    Reload();
                }
            }
            catch (Exception ex)
            {

                
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            colors.Export();
        }
    }
}
