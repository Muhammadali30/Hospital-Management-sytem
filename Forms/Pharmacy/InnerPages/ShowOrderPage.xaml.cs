using Final_Project.Classes;
using MaterialDesignThemes.Wpf;
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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for ShowOrderPage.xaml
    /// </summary>
    public partial class ShowOrderPage : Page
    {
        private int order_id;
        public ShowOrderPage(int id)
        {
            InitializeComponent();
            order_id = id;
            LoadRecord();

        }
        private void LoadRecord()
        {
            Database db = new Database();
            DataTable dt = db.Read($"Select * from [Order] where id = '{order_id}'");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                DateTime da = DateTime.ParseExact(row["date"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                date.Text = da.ToString("dd-MMMM-yyyy hh:mm:tt");
                discount.Text = row["discount"].ToString();
                total.Text = row["total"].ToString();
            }
            DataTable items = db.Read($"SELECT * from Medicine_Orders where order_id = '{order_id}'");
            ordersitemgrid.ItemsSource = items.DefaultView;
        }

        private void showdoctorsbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reasonpanel.Visibility = Visibility.Visible;

                Database db = new Database();
                DataTable items = db.Read($"SELECT * from Medicine_Orders where order_id = '{order_id}'");

                // Add a new column named "Return.Qty" to your DataTable
                DataColumn newColumn = new DataColumn("Return.Qty", typeof(string));
                items.Columns.Add(newColumn);

                // Refresh the DataGrid to reflect changes
                ordersitemgrid.ItemsSource = items.DefaultView;
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        //private void ordersitemgrid_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    // Get the selected row
        //    DataRowView selectedRow = ordersitemgrid.SelectedItem as DataRowView;

        //    if (selectedRow != null)
        //    {
        //        // Access the data in the selected row
        //        // For example, you can access a specific column like this:
        //        string valueInFirstColumn = selectedRow.Row["NewColumn"].ToString();

        //        // Or you can access all columns in the row using a loop:
        //        foreach (DataColumn column in selectedRow.Row.Table.Columns)
        //        {
        //            string columnValue = selectedRow.Row[column.ColumnName].ToString();
        //            MessageBox.Show(columnValue);
        //        }
        //    }
        //}
    }
}
