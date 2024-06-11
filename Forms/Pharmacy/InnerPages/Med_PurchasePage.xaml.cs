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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for Med_PurchasePage.xaml
    /// </summary>
    public partial class Med_PurchasePage : Page
    {
        public Med_PurchasePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new AddStockPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new PurchasePage());
            AF.ShowDialog();
        }
    }
}
