using Final_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabDepartmentPage.xaml
    /// </summary>
    public partial class LabDepartmentPage : Page
    {
        public LabDepartmentPage()
        {
            InitializeComponent();
        }

        private void CancelDepartmentFormButton(object sender, RoutedEventArgs e)
        {
            adddepartmentform.Visibility = Visibility.Hidden;
            addbtn.Visibility = Visibility.Visible;
        }

        private void ShowDepartmentFormButton(object sender, RoutedEventArgs e)
        {
            addbtn.Visibility = Visibility.Hidden;
            adddepartmentform.Visibility = Visibility.Visible;
        }

        private void AddDepartment(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Database class
            Database database = new Database();

            //// Get the department name from the departname TextBox
            //string departmentName = departname.Text;

            //// Use a parameterized query to insert the department name
            //string query = "INSERT INTO Lab_Departments (department_name) VALUES (@DepartmentName)";

            //// Call the AddData method with the query and parameter
           DataTable dt= database.READ("select * from Lab_Departments", null);
            DepartmentGridview.ItemsSource = dt.DefaultView;
            DepartmentGridview.Columns[0].Header = "Department ID";
            DepartmentGridview.Columns[1].Header = "Department Name";
        }
    }
}
