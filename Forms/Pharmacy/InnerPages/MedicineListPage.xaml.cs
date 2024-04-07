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
    /// Interaction logic for MedicineListPage.xaml
    /// </summary>
    public partial class MedicineListPage : Page
    {
        public MedicineListPage()
        {
            InitializeComponent();
            LoadMedicines();
        }
        private void LoadMedicines()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT * from Medicines");
            medicinegrid.ItemsSource = dt.DefaultView;
            medicinegrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };


        }
        private void OpenNewMedPage(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddMedicinePage());
            AF.ShowDialog();
        }

        private void OpenMulItemsPage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new RequestMultipleItemsPage());
            }
        }

        private void OpenAddStockPage(object sender, RoutedEventArgs e)
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
    }
}
