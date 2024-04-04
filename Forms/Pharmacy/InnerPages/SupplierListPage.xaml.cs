using Final_Project.Classes;
using Final_Project.Forms.HMS.InnerPages;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SupplierListPage.xaml
    /// </summary>
    public partial class SupplierListPage : Page
    {
        public SupplierListPage()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT * from Suppliers");
            suppliersgrid.ItemsSource = dt.DefaultView;
            suppliersgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }

        private void OpenNewSupplierPage(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new NewSupplierPage());
            AF.ShowDialog();
            //if (NavigationService != null)
            //{
            //    // Remove the current page from the navigation history
            //    if (NavigationService.CanGoBack)
            //    {
            //        NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page within the same frame
            //    NavigationService.Navigate(new NewSupplierPage());
            //}
            //if (frame.NavigationService != null)
            //   {
            //       // Remove the previous page from the navigation history
            //       if (frame.NavigationService.CanGoBack)
            //       {
            //           frame.NavigationService.RemoveBackEntry();
            //       }

            //       // Load the new page

            //   }
            //   frame.Content = new NewSupplierPage();
        }
    }
}
