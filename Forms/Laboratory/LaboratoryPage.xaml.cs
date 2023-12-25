using Final_Project.Forms.Laboratory.InnerPages;
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

namespace Final_Project.Forms.Laboratory
{
    /// <summary>
    /// Interaction logic for LaboratoryPage.xaml
    /// </summary>
    public partial class LaboratoryPage : Page
    {
        public LaboratoryPage()
        {
            InitializeComponent();
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

        private void OpenLabInvoicePage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new LabInvoicePage();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new LabInvoicePage();
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
    }
}
