using Final_Project.Classes;
using Final_Project.Forms.HMS.InnerPages;
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

namespace Final_Project.Forms.OPD.InnerPages
{
    /// <summary>
    /// Interaction logic for PatientListPage.xaml
    /// </summary>
    public partial class PatientListPage : Page
    {
        public PatientListPage()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT * from Patients");
            patientsgrid.ItemsSource = dt.DefaultView;
            patientsgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
            //// Handle double click event
            //doctorsgrid.MouseDoubleClick += Labinvoicegrid_MouseDoubleClick;
        }
        private void OpenAddPatientPage(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddPatientPage());
            AF.ShowDialog();
        }
    }
}
