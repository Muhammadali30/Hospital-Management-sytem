using Aspose.Pdf.Operators;
using Final_Project.Classes;
using Final_Project.Forms.Laboratory.InnerPages;
using System;
using System.Collections.Generic;
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

namespace Final_Project.Forms.HMS.InnerPages
{
    /// <summary>
    /// Interaction logic for AddPatientPage.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {
        LabInvoicePage newpage;
        public AddPatientPage(LabInvoicePage? invoicepage = null)
        {
            InitializeComponent();
            if (invoicepage != null)
            {
                newpage = invoicepage;
            }
        }

        private void BackToPatientListPage(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            //DateTime dobDate, joiningDate;
            //if (!DateTime.TryParse(dob.Text, out dobDate) || !DateTime.TryParse(joining.Text, out joiningDate))
            //{
            //    MessageBox.Show("Invalid date format");
            //    return;
            //}

            // Format the DateTime objects to the desired string format ('YYYY-MM-DD')
            //string dobFormatted = dobDate.ToString("yyyy-MM-dd");
            //string joiningFormatted = joiningDate.ToString("yyyy-MM-dd");

            // Construct the SQL query with the formatted date strings
            newpage.patient_id = db.GetInsertedId($"INSERT INTO Patients (name,status, phone, address) OUTPUT INSERTED.id  VALUES ('{name.Text}', '{status.SelectedValue.ToString()}', '{phone.Text}', '{address.Text}')");
        }
    }
}
