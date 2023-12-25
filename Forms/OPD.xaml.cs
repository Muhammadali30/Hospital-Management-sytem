using Final_Project.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for OPD.xaml
    /// </summary>
    public partial class OPD : Page
    {
        int PageStatus;
        public ObservableCollection<Doctor> Doctors { get; set; }
        public OPD()
        {
            InitializeComponent();
            InitializeData();

        }
        private void InitializeData()
        {
            // Sample data
            Doctors = new ObservableCollection<Doctor>
            {
                new Doctor { ID = 1, Name = "Dr. Smith", Age = 35, Specialty = "Cardiology" },
                new Doctor { ID = 2, Name = "Dr. Johnson", Age = 40, Specialty = "Orthopedics" },
                new Doctor { ID = 3, Name = "Dr. Brown", Age = 32, Specialty = "Pediatrics" },
                // Add more data as needed
            };
            //OpdRecord.ItemsSource = Doctors;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //// Check if a row is selected
            //if (OpdRecord.SelectedItem != null)
            //{
            //    // Remove the selected item from the data source
            //    Doctor.Remove((Doctor)OpdRecord.SelectedItem);
            //}
            //else
            //{
            //    MessageBox.Show("Please select a row to delete.");
            //}
        }

        private void OpdRecord_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = DataGridLength.Auto;
        }

        private void AddPatientOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            patientdoctorform patientdoctorform = new patientdoctorform(1);
            patientdoctorform.Show();
            //PageStatus = 1;
            //if (editframe.NavigationService != null)
            //{
            //    // Remove the previous page from the navigation history
            //    if (editframe.NavigationService.CanGoBack)
            //    {
            //        editframe.NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page

            //}
            //editframe.Content = new addpatients();

            ////addpatient addpatient = new addpatient(); // Create an instance of the new window
            ////addpatient.Show(); // Show the new window
            //var addpatient = Application.Current.Windows.OfType<addpatient>().FirstOrDefault();

            //if (addpatient == null)
            //{
            //    // If not open, create a new instance
            //    addpatient = new addpatient();
            //    addpatient.Show();
            //}
            //else
            //{
            //    // If already open, bring it to the front
            //    addpatient.Focus();
            //}
        }



        private void AddDocOnMouseDown(object sender, MouseButtonEventArgs e)
        {
        patientdoctorform patientdoctorform = new patientdoctorform(2);
            patientdoctorform.Show();
            

            //PageStatus = 0;
            //if (editframe.NavigationService != null)
            //{
            //    // Remove the previous page from the navigation history
            //    if (editframe.NavigationService.CanGoBack)
            //    {
            //        editframe.NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page

            //}
            //editframe.Content = new adddoctor();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PageStatus == 1)
            {
                MessageBox.Show("New Patient Added");
                return;
            }
            MessageBox.Show("New Doctor Added");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if (editframe.NavigationService != null)
            //{
            //    // Remove the previous page from the navigation history
            //    if (editframe.NavigationService.CanGoBack)
            //    {
            //        editframe.NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page

            //}
            //editframe.Content = new appointments();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            //if (editframe.NavigationService != null)
            //{
            //    // Remove the previous page from the navigation history
            //    if (editframe.NavigationService.CanGoBack)
            //    {
            //        editframe.NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page

            //}
            //editframe.Content = new appointments();
        }

      

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           

                doctorframe.Visibility = Visibility.Visible;
                OpdRecord.Visibility = Visibility.Hidden;
                if (doctorframe.NavigationService != null)
                {
                    // Remove the previous page from the navigation history
                    if (doctorframe.NavigationService.CanGoBack)
                    {
                        doctorframe.NavigationService.RemoveBackEntry();
                    }

                    // Load the new page

                }
                doctorframe.Content = new DoctorsPage();
            showdoctorsbutton.Visibility = Visibility.Hidden;
            showpatientbutton.Visibility = Visibility.Visible;


        }

        private void onshowpatientsbutton(object sender, RoutedEventArgs e)
        {
            doctorframe.Visibility = Visibility.Hidden;
            OpdRecord.Visibility = Visibility.Visible;
            showpatientbutton.Visibility = Visibility.Hidden;
            showdoctorsbutton.Visibility = Visibility.Visible;

        }
    }
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialty { get; set; }
    }
}
