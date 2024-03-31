using Final_Project.Classes;
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
    /// Interaction logic for ApponitmentPage.xaml
    /// </summary>
    public partial class ApponitmentPage : Page
    {
        public ApponitmentPage()
        {
            InitializeComponent();
            loaddoc();
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
            DataRowView selectedRow = selectdoctorcombo.SelectedItem as DataRowView;
            int doc_id = Convert.ToInt32(selectedRow["id"]);
            Database db = new Database();
            db.Add($"INSERT INTO Appointments(patient_name,phone,status,doctor_id,booking_date)VALUES('{name.Text}','{phone.Text}','{status.SelectedValue}','{doc_id}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
        }
    }
}
