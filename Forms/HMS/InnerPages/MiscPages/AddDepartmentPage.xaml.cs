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

namespace Final_Project.Forms.HMS.InnerPages.MiscPages
{
    /// <summary>
    /// Interaction logic for AddDepartmentPage.xaml
    /// </summary>
    public partial class AddDepartmentPage : Page
    {
        public AddDepartmentPage()
        {
            InitializeComponent();
        }

        private void BackToDepartmentListPage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                // Remove the forward navigation entry
                if (NavigationService.CanGoForward)
                {
                    NavigationService.RemoveBackEntry();
                }
                // Go back to the previous page
                NavigationService.GoBack();
            }
        }
    }
}
