using Final_Project.Classes;
using Final_Project.Forms.Laboratory.InnerPages;
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

namespace Final_Project.Forms.HMS.InnerPages
{
    /// <summary>
    /// Interaction logic for DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT * from Doctors");
            doctorsgrid.ItemsSource = dt.DefaultView;
            doctorsgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
            //// Handle double click event
            //doctorsgrid.MouseDoubleClick += Labinvoicegrid_MouseDoubleClick;
        }
        //private void Labinvoicegrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    DataRowView selectedRow = (DataRowView)doctorsgrid.SelectedItem;
        //    if (selectedRow != null)
        //    {
        //        int id = Convert.ToInt32(selectedRow["Invoice_NO"]);
        //        if (NavigationService != null)
        //        {
        //            // Remove the current page from the navigation history
        //            if (NavigationService.CanGoBack)
        //            {
        //                NavigationService.RemoveBackEntry();
        //            }

        //            // Load the new page within the same frame
        //            NavigationService.Navigate(new Lab_invoice_show_page(id));
        //        }
        //        MessageBox.Show($"The ID of the selected row is: {id}");
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (NavigationService != null)
        //    {
        //        // Remove the current page from the navigation history
        //        if (NavigationService.CanGoBack)
        //        {
        //            NavigationService.RemoveBackEntry();
        //        }

        //        // Load the new page within the same frame
        //        NavigationService.Navigate(new LabInvoicePage());
        //    }
        //}
        private void OpenAddDoctorPage(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddDoctorPage());
            AF.ShowDialog();
        }
    }
}
