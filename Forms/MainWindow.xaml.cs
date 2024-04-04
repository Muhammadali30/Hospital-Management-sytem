using Final_Project.Forms;
using Final_Project.Forms.Dashboard;
using Final_Project.Forms.HMS;
using Final_Project.Forms.Laboratory;
using Final_Project.Forms.OPD;
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

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //OPD();
            //LAB();
            PHARMACY();


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

            if (SideFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (SideFrame.NavigationService.CanGoBack)
                {
                    SideFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            SideFrame.Content = new SidebarPage(MainFrame);
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
            MainFrame.Content = new OpdDashboard();

            if (SideFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (SideFrame.NavigationService.CanGoBack)
                {
                    SideFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            SideFrame.Content = new LabSidebarPage(MainFrame);
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
            MainFrame.Content = new OpdDashboard();

            if (SideFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (SideFrame.NavigationService.CanGoBack)
                {
                    SideFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            SideFrame.Content = new PharmacySidebar(MainFrame);
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

    }
    }

