using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.HMS.InnerPages.MiscPages;
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

namespace Final_Project.Forms.HMS
{
    /// <summary>
    /// Interaction logic for HMSPage.xaml
    /// </summary>
    public partial class HMSPage : Page
    {
        public HMSPage()
        {
            InitializeComponent();
        }

        //PageFunction to open new Page
        private void OpenNewPage(Page newpage)
        {
            if (MainFrame.NavigationService != null)
            {
                if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.RemoveBackEntry();
                }
            }
            MainFrame.Content = newpage;
        }
        private void OpenAppointmentListPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new AppointmentListPage());
        }
        private void OpenPatientListPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new PatientListPage());
        }
        private void OpenDoctorPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new DoctorPage());
        }
        private void OpenBedListPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new BedListPage());
        }
        private void OpenBedAllotmentListPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new BedAllotmentPage());
        }
        private void OpenDepartmentListPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new DepartmentsListPage());
        }
        private void OpenDeathReportsPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new DeathListPage());
        }
        private void OpenBirthReportPage(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new BirthReportsPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OpenNewPage(new AppointmentListPage());
        }
    }
}
