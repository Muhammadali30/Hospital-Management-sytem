using Final_Project.Forms.Pharmacy.InnerPages;
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

namespace Final_Project.Forms.Pharmacy
{
    /// <summary>
    /// Interaction logic for PharmacySidebar.xaml
    /// </summary>
    public partial class PharmacySidebar : Page
    {
        Frame MainFrame;
        public PharmacySidebar(Frame mainFrame)
        {
            InitializeComponent();
            MainFrame = mainFrame;
        }

        private Button previousButton = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if there's a previously clicked button
            if (previousButton != null)
            {
                // Revert the background color of the previous button
                previousButton.BorderBrush = Brushes.White;
            }

            // Set the background color of the clicked button
            var button = (Button)sender;
            button.BorderBrush = Brushes.Black;

            // Store the current button as the previously clicked button
            previousButton = button;
        }
        private void OpenAddMedForm(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new AddMedicinePage();
        }

        private void OpenMedListPage(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new MedicineListPage();
        }

        private void OpenMedDetailPage(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new MedDetailPage();
        }

        private void OpenMedReturnPage(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new MedReturnPage();
        }

        private void OpenOrderPage(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new NewOrderPage();
        }

        private void OpenSupplierPage(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new SupplierListPage();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new AddMedicinePage();
        }
    }
}
