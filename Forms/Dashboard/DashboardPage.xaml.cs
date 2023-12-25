using Final_Project.Forms.Dashboard.InnerPages;
using Final_Project.Forms.Pharmacy;
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

namespace Final_Project.Forms.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private void OpenPharmacyPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
                // Load the new page
            }
            MainFrame.Content = new Pharmacy_Dashboard();
        }
    }
}
