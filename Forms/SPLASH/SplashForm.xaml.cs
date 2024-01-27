using Final_Project.Forms.Dashboard;
using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.SPLASH.InnerPages;
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
using System.Windows.Shapes;

namespace Final_Project.Forms.SPLASH
{
    /// <summary>
    /// Interaction logic for SplashForm.xaml
    /// </summary>
    public partial class SplashForm : Window
    {
        public SplashForm()
        {
            InitializeComponent();
            OnLoaded();
        }
        private async void OnLoaded()
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
            MainFrame.Content = new LoadingPage();
            //MessageBox.Show("We Are Working on it!");
            await Task.Delay(5000);
            closebutton.Visibility= Visibility.Visible;
            if (MainFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            MainFrame.Content = new LoginPage();
        }

        private void CloseApplicationButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
