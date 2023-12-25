using Final_Project.Forms.Laboratory.InnerPages.Labreports;
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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabReportPage.xaml
    /// </summary>
    public partial class LabReportPage : Page
    {
        public LabReportPage()
        {
            InitializeComponent();
        }

        private void OpenCollectSamplePage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new CollectSamplePage();
        }

        private void OpenPendingTestPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new PendingTestPage();
        }

        private void OpenTestValidationPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new TestValidationPage();
        }

        private void OpenCompletedTestPage(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = new CompletedTestPage();
        }
    }
}
