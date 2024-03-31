using Final_Project.Classes;
using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.OPD.InnerPages;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for OpdDashboard.xaml
    /// </summary>
    public partial class OpdDashboard : Page
    {
        public OpdDashboard()
        {
            InitializeComponent();
            LoadAppointments();

        }

        private void LoadAppointments()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT a.*, d.name FROM Appointments AS a LEFT JOIN Doctors AS d ON a.doctor_id =  d.id");
            appointmentsgrid.ItemsSource = dt.DefaultView;
            appointmentsgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new ApponitmentPage());
            AF.ShowDialog();
        }
    }
}
