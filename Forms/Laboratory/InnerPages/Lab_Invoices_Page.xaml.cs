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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for Lab_Invoices_Page.xaml
    /// </summary>
    public partial class Lab_Invoices_Page : Page
    {
        public Lab_Invoices_Page()
        {
            InitializeComponent();
            Database db = new Database();
            LoadInvoices();
        }
        private void LoadInvoices()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT i.id as Invoice_NO , p.name as Patient ,  i.total as Total, i.datetime as Date FROM Lab_Invoice AS i LEFT JOIN Patients AS p ON i.unregistered_patient_id = p .id");
            labinvoicegrid.ItemsSource = dt.DefaultView;
            labinvoicegrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };

            // Handle double click event
            labinvoicegrid.MouseDoubleClick += Labinvoicegrid_MouseDoubleClick;
        }

        private void Labinvoicegrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)labinvoicegrid.SelectedItem;
            if (selectedRow != null)
            {
                int id = Convert.ToInt32(selectedRow["Invoice_NO"]);
                if (NavigationService != null)
                {
                    // Remove the current page from the navigation history
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.RemoveBackEntry();
                    }

                    // Load the new page within the same frame
                    NavigationService.Navigate(new Lab_invoice_show_page(id));
                }
                MessageBox.Show($"The ID of the selected row is: {id}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new LabInvoicePage());
            }
        }
    }
}
