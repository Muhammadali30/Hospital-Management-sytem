using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.Laboratory;
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

namespace Final_Project.Forms
{
    /// <summary>
    /// Interaction logic for AlertForm.xaml
    /// </summary>
    public partial class AlertForm : Window
    {
        public AlertForm(Page AF)
        {
            InitializeComponent();
           
                Height = AF.Height;
                //Width = AF.Width;
           

            if (AlertFrame.NavigationService != null)
            {
                // Remove the previous page from the navigation history
                if (AlertFrame.NavigationService.CanGoBack)
                {
                    AlertFrame.NavigationService.RemoveBackEntry();
                }

                // Load the new page

            }
            AlertFrame.Content = AF;

        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
