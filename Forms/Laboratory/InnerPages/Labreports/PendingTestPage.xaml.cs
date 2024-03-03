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

namespace Final_Project.Forms.Laboratory.InnerPages.Labreports
{
    /// <summary>
    /// Interaction logic for PendingTestPage.xaml
    /// </summary>
    public partial class PendingTestPage : Page
    {
        public PendingTestPage()
        {
            InitializeComponent();
            LoadPendingTestReports();
        }
        private void LoadPendingTestReports()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT i.id as Invoice_NO , p.name as Patient, i.datetime as Date, i.priority as Priority FROM Lab_Invoice AS i LEFT JOIN Unregister_Patients AS p ON i.unregistered_patient_id = p .id where i.status='Pending Test'");
            pendingtestgrid.ItemsSource = dt.DefaultView;
            pendingtestgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };

            pendingtestgrid.MouseDoubleClick += Pendingtestgrid_MouseDoubleClick;


        }
        private void Pendingtestgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)pendingtestgrid.SelectedItem;
            if (selectedRow != null)
            {
                int id = Convert.ToInt32(selectedRow["Invoice_NO"]);
                MessageBoxResult mbr = MessageBox.Show($"The ID of the selected row is: {id}", "Confirmation!", MessageBoxButton.YesNo);
                Database db = new Database();
                if (mbr == MessageBoxResult.Yes)
                    //db.Update($"UPDATE Lab_Invoice SET status = 'Test Validation' WHERE id = {id}");
                    //LoadPendingTestReports();
                if (selectedRow != null)
                {
                    if (NavigationService != null)
                    {
                        // Remove the current page from the navigation history
                        if (NavigationService.CanGoBack)
                        {
                            NavigationService.RemoveBackEntry();
                        }

                        // Load the new page within the same frame
                        NavigationService.Navigate(new LabReportResultPage(id, selectedRow["Patient"].ToString()));
                    }
                }
                //MessageBox.Show(mbr == MessageBoxResult.Yes ? "Sample is go for testing" : "");
            }

        }
    }
}
