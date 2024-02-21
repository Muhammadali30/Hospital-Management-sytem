using Final_Project.Classes;
using Final_Project.Forms.Pharmacy.InnerPages;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabTemplatesPage.xaml
    /// </summary>
    public partial class LabTemplatesPage : Page
    {
        public LabTemplatesPage()
        {
            InitializeComponent();
            LoadTemplates();
        }
        private void LoadTemplates()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT t.name as Name, t.price as Price, t.sample_quantity as Sample_Qty, t.code as Code, d.department_name as Department FROM Lab_Templates AS t LEFT JOIN Lab_Departments AS d ON t.department_id = d.id");
            templategrid.ItemsSource = dt.DefaultView;
            templategrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };


        }
        private void AddNewTemplatePage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new NewLabTestTemplatePage());
            }
        }

        private void EditTemplatesPrice(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new EditPricePage());
            }
        }
    }
}
