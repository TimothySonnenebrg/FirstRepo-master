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
using TJS.VehicleTracker.BL;

namespace TJS.VehicleTracker.UI
{

    public enum ScreenMode
    {
        Color = 1,
        Make = 2,
        Model = 3
    }


    /// <summary>
    /// Interaction logic for MaintainAttributes.xaml
    /// </summary>
    public partial class MaintainAttributes : Window
    {
        
        MakeList  makes;
        ModelList models;


        ScreenMode mode;

        Model model;
        Make make;


        public MaintainAttributes()
        {
            InitializeComponent();
        }

        public MaintainAttributes(ScreenMode _mode)
        {
            InitializeComponent();
            mode = _mode;

            switch (mode)
            {
                 case ScreenMode.Make:
                    makes = new MakeList();
                    makes.Load();

                    cboAttribute.ItemsSource = null;  //bind
                    cboAttribute.ItemsSource = makes;
                    break;

                case ScreenMode.Model:
                    models = new ModelList();
                    models.Load();

                    cboAttribute.ItemsSource = null;  //bind
                    cboAttribute.ItemsSource = models;
                    break;
            }

            cboAttribute.DisplayMemberPath = "Description";
            cboAttribute.SelectedValuePath = "Id";
            lblAttribute.Content = mode.ToString() + "s:";
            this.Title = "Maintain" + mode.ToString() + "s";

        }



        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case ScreenMode.Make:
                    Make make = new Make();
                    make.Description = txtDescription.Text;
                    make.Insert();
                    makes.Add(make);

                    break;
                case ScreenMode.Model:
                    Model model = new Model();
                    model.Description = txtDescription.Text;
                    models.Add(model);
                    model.Insert();
                    break;
            }

            Reload();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case ScreenMode.Make:
                    make.Description = txtDescription.Text;
                    make.Update();
                    makes[cboAttribute.SelectedIndex] = make;
                    break;
                case ScreenMode.Model:
                    model.Description = txtDescription.Text;
                    models[cboAttribute.SelectedIndex] = model;
                    model.Update();
                    break;
            }
            Reload();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case ScreenMode.Make:
                    make.Delete();
                    makes.Remove(make);
                    break;
                case ScreenMode.Model:
                    models.Remove(model);
                    model.Delete();
                    break;
            }
            Reload();
        }
        public void Reload()
        {
            switch (mode)
            {
                case ScreenMode.Make:
                    cboAttribute.ItemsSource = null;
                    cboAttribute.ItemsSource = makes;
                    break;
                case ScreenMode.Model:
                    cboAttribute.ItemsSource = null;
                    cboAttribute.ItemsSource = makes;

                    break;
            }

            cboAttribute.DisplayMemberPath = "Description";
            cboAttribute.SelectedValuePath = "Id";
            lblAttribute.Content = mode.ToString() + "s:";
            this.Title = "Maintain" + mode.ToString() + "s";
        }


        private void cboAttribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboAttribute.SelectedIndex >-1)
            {

                switch (mode)
                {

                    case ScreenMode.Make:

                        make = makes[cboAttribute.SelectedIndex];
                        txtDescription.Text = make.Description;
                        break;
                    case ScreenMode.Model:
                        model = models[cboAttribute.SelectedIndex];
                        txtDescription.Text = model.Description;
                        break;
                
                }
            }
        }

       
    }
}


