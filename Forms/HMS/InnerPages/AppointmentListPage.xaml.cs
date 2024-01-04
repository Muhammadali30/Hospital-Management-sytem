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

namespace Final_Project.Forms.HMS.InnerPages
{
    /// <summary>
    /// Interaction logic for AppointmentListPage.xaml
    /// </summary>
    public partial class AppointmentListPage : Page
    {
        public AppointmentListPage()
        {
            InitializeComponent();
            datechange.Text = DateTime.Now.ToString("ddd, dd MMM yyyy");

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = ((DatePicker)sender).SelectedDate ?? DateTime.MinValue;
            datechange.Text = selectedDate.ToString("ddd, dd MMM yyyy");
        }
    }
}
