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
            Database database = new Database();
            patientscount.Text = database.value("SELECT COUNT(*) from Patients").ToString();
            doctorscount.Text = database.value("SELECT COUNT(*) from Doctors").ToString();
            appointmentscount.Text = $"Appointments ({database.value("SELECT COUNT(*) from Appointments")})";
            schedule.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) FROM Appointments WHERE status = 'Schedule'") };
            cancel.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) FROM Appointments WHERE status = 'Canceled'") };
            reschedule.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) FROM Appointments WHERE status = 'Re-Schedule'") };



        }

        private void LoadAppointments()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT a.id as ID, p.name as Patient, d.name as Doctor, a.status as Status, a.date as Date FROM Appointments AS a LEFT JOIN Doctors AS d ON a.doctor_id =  d.id LEFT JOIN Patients AS p ON a.patient_id = p.id");
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

        private void tokenbtn(object sender, RoutedEventArgs e)
        {
            StackPanel parent = CreateTags.create_stackpanel(null, null, 200);
            parent.Children.Add(CreateTags.create_textblock("Token Number", 16));
            parent.Children.Add(CreateTags.create_textblock("01", 50));
            parent.Children.Add(CreateTags.create_textblock("Generated At", 16));
            parent.Children.Add(CreateTags.create_textblock(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 16));

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(parent, "Invoice");
            }
        }
    }
}
