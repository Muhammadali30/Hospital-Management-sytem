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
    /// Interaction logic for patientdoctorform.xaml
    /// </summary>
    public partial class patientdoctorform : Window
    {
        int status;
        public patientdoctorform(int form)
        {
            InitializeComponent();
            status = form;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (status==1)
            {
                this.Title = "Add Patient";
                if (MainFrame.NavigationService != null)
                {
                    // Remove the previous page from the navigation history
                    if (MainFrame.NavigationService.CanGoBack)
                    {
                        MainFrame.NavigationService.RemoveBackEntry();
                    }
                    // Load the new page
                }
                MainFrame.Content = new addpatients();
            }
            else
            {
                this.Title = "Add Doctor";
                if (MainFrame.NavigationService != null)
                {
                    // Remove the previous page from the navigation history
                    if (MainFrame.NavigationService.CanGoBack)
                    {
                        MainFrame.NavigationService.RemoveBackEntry();
                    }
                    // Load the new page
                }
                MainFrame.Content = new adddoctor();
            }
        }
    }
}
