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
    /// Interaction logic for CollectSamplePage.xaml
    /// </summary>
    public partial class CollectSamplePage : Page
    {
        public CollectSamplePage()
        {
            InitializeComponent();
            LoadPendingReports();
        }

        private void LoadPendingReports()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT i.id as Invoice_NO , p.name as Patient, i.datetime as Date, i.priority as Priority FROM Lab_Invoice AS i LEFT JOIN Unregister_Patients AS p ON i.unregistered_patient_id = p .id where i.status='pending'");
            collectsamplegrid.ItemsSource = dt.DefaultView;
            collectsamplegrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };

            collectsamplegrid.MouseDoubleClick += Collectsamplegrid_MouseDoubleClick;


        }
        private void Collectsamplegrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)collectsamplegrid.SelectedItem;
            if (selectedRow != null)
            {
                int id = Convert.ToInt32(selectedRow["Invoice_NO"]);
               MessageBoxResult mbr = MessageBox.Show($"The ID of the selected row is: {id}","Confirmation!",MessageBoxButton.YesNo);
                Database db = new Database();
                if (mbr == MessageBoxResult.Yes)
                    db.Update($"UPDATE Lab_Invoice SET status = 'Pending Test' WHERE id = {id}");
                    LoadPendingReports();
                //MessageBox.Show(mbr == MessageBoxResult.Yes ? "Sample is go for testing" : "");
            }

        }
    }
}
