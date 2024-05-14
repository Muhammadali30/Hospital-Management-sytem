using Final_Project.Classes;
using Final_Project.Forms.HMS.InnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for ApponitmentPage.xaml
    /// </summary>
    public partial class ApponitmentPage : Page
    {
        public BigInteger patient_id;
        public ApponitmentPage()
        {
            InitializeComponent();
            loaddoc();
            Database db = new Database();
            DataTable patient_name = db.Read("SELECT id, CONCAT(name,' - ',phone) as name from Patients");
            DataRow newRow = patient_name.NewRow();
            newRow["name"] = "Select Patient";
            newRow["id"] = -1;
            patient_name.Rows.InsertAt(newRow, 0);
            patientscombo.SelectionChanged += patientscombo_SelectionChanged;
            patientscombo.ItemsSource = patient_name.DefaultView;
            patientscombo.DisplayMemberPath = "name";
            patientscombo.SelectedIndex = 0;
        }

        private void patientscombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = patientscombo.SelectedItem as DataRowView;
            patient_id = selectedRow != null ? Convert.ToInt32(selectedRow["id"]) : 0;
            if (patient_id != -1)
            {
                newpatientbtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                newpatientbtn.Visibility = Visibility.Visible;
            }
            MessageBox.Show(patient_id.ToString());
        }

        private void loaddoc()
        {
                DataTable doc_name;
                Database db = new Database();
                doc_name = db.Read("SELECT id,name from Doctors");
                DataRow newRow = doc_name.NewRow();
                newRow["name"] = "Select DocTor";
                newRow["id"] = -1; // Set an arbitrary value for the ID
                doc_name.Rows.InsertAt(newRow, 0);

                selectdoctorcombo.ItemsSource = doc_name.DefaultView;
                selectdoctorcombo.DisplayMemberPath = "name";
                selectdoctorcombo.SelectedValue = "id";

                selectdoctorcombo.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DateTime? selectedDateTime = TimePickerControl.Value;
            DataRowView selectedRow = selectdoctorcombo.SelectedItem as DataRowView;
            ComboBoxItem statusselectedRow = status.SelectedItem as ComboBoxItem;
            int doc_id = Convert.ToInt32(selectedRow["id"]);
            Database db = new Database();
            db.Add($"INSERT INTO Appointments(patient_id,status,doctor_id,date,booking_date)VALUES('{patient_id}','{statusselectedRow.Content}','{doc_id}','{selectedDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
        }

        private void AddnewpatientBtn(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddPatientPage(null,this));
            AF.ShowDialog();
            if (patient_id != -1)
            {
                MessageBox.Show("New Patient is created now you don't need to select "+patient_id,"Alert!");
            }
        }
    }
}
