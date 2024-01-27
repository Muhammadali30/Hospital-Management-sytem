using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.OPD.InnerPages;
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

namespace Final_Project.Forms.OPD
{
    /// <summary>
    /// Interaction logic for SidebarPage.xaml
    /// </summary>
    public partial class SidebarPage : Page
    {
        Frame MainFrame;
        public SidebarPage(Frame MF)
        {
            InitializeComponent();
            MainFrame = MF;
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
    }
}
