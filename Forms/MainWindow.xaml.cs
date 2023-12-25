using Final_Project.Forms;
using Final_Project.Forms.Dashboard;
using Final_Project.Forms.HMS;
using Final_Project.Forms.Laboratory;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new LaboratoryPage();
        }

      


        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (accountinfo.Visibility == Visibility.Hidden)
            {
                accountinfo.Visibility = Visibility.Visible;
            }
            else
            {
                accountinfo.Visibility = Visibility.Hidden;

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            loginpage lp = new loginpage();
            lp.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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
            MainFrame.Content = new PharmacyPage();
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
    }
    }

