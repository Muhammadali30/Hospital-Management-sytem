using Final_Project.Forms;
using Final_Project.Forms.Admin;
using Final_Project.Forms.Dashboard;
using Final_Project.Forms.HMS;
using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.Laboratory;
using Final_Project.Forms.Laboratory.InnerPages;
using Final_Project.Forms.OPD;
using Final_Project.Forms.OPD.InnerPages;
using Final_Project.Forms.Pharmacy;
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

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //string role,string n, string mail
            InitializeComponent();
            //laboratorybuttons.Visibility = Visibility.Visible;
            //LAB();
            pharmacybuttons.Visibility = Visibility.Visible;
            PHARMACY();
            //name.Text = username.Text = n;
            //email.Text = mail;
            //if (role == "Pharmacy")
            //{
            //    pharmacybuttons.Visibility = Visibility.Visible;
            //    PHARMACY();
            //}
            //else if (role == "Receptionist")
            //{
            //    opdbuttons.Visibility = Visibility.Visible;
            //    OPD();
            //}
            //else if (role == "Labortory")
            //{
            //    laboratorybuttons.Visibility = Visibility.Visible;
            //    LAB();
            //}
            //else if (role == "Admin")
            //{
            //    adminbuttons.Visibility = Visibility.Visible;
            //    sidebar.Children.Remove(pharmacybuttons);
            //    sidebar.Children.Remove(laboratorybuttons);
            //    sidebar.Children.Remove(opdbuttons);

            //    laboratorybuttons.Visibility = Visibility.Visible;
            //    opdbuttons.Visibility = Visibility.Visible;
            //    pharmacybuttons.Visibility = Visibility.Visible;

            //    pharmacyexpander.Content = pharmacybuttons;
            //    labexpander.Content = laboratorybuttons;
            //    opdexpander.Content = opdbuttons;
            //}
        }
        private void OPD()
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
            MainFrame.Content = new OpdDashboard();
        }

        private void LAB()
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
            MainFrame.Content = new LabDashboard();
        }

        private void PHARMACY()
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
            MainFrame.Content = new PharmacyDashboard();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            loginpage lp = new loginpage();
            lp.Show();
            this.Close();
        }


        private void OpenHMSPage(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new HMSPage();
        }

        private void OpenDashBoardPage(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new DashboardPage();
            //MessageBox.Show("We Are Working on it!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (MainFrame.NavigationService != null)
            //{
            //    // Remove the previous page from the navigation history
            //    if (MainFrame.NavigationService.CanGoBack)
            //    {
            //        MainFrame.NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page

            //}
            //MainFrame.Content = new DashboardPage();
            ////MessageBox.Show("We Are Working on it!");
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            if (sidebarcolumn.Width.Value==220)
            {
                sidebarcolumn.Width =new GridLength(0);
                Sidebar.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowRight;
            }
            else
            {
                sidebarcolumn.Width = new GridLength(220);
                Sidebar.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowLeft;
            }
        }

        private void ToggleAccountCart(object sender, MouseButtonEventArgs e)
        {
            accountinfo.Visibility = (accountinfo.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void OpenLabDashBoard(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new OpdDashboard();
        }

        private void OpenLabInvoice(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new Lab_Invoices_Page();
        }
        private void OpenLabReportPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new LabReportPage();
        }

        private void OpenLabTemplatesPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new LabTemplatesPage();
        }
        private void OpenLabDepartmentPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new LabDepartmentPage();
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
            MainFrame.Content = new MedicineOrdersPage();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new UsersListPage();
        }

        private void PatientListButton(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new PatientListPage();
        }

        private void DashBoardPageButton(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new OpdDashboard();
        }

        private void DoctorListButton(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new DoctorPage();
        }

        private void OpenPharmacyDashboardbtn(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new PharmacyDashboard();
        }
    }
    }

