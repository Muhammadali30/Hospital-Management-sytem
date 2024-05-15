using Aspose.Pdf.Annotations;
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

namespace Final_Project.Forms.Admin
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Page
    {
        public AdminDashboard()
        {
            InitializeComponent();
            Database database = new Database();
            active.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Users where status = 'Active'") };
            blocked.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Users where status = 'Blocked'") };
            LoadUsers();
        }

        private void LoadUsers()
        {
            Database database = new Database();
            DataTable dt = database.Read(@"SELECT id,name,age,role,status FROM Users");

            //// Create a new column for the buttons
            //DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
            //buttonColumn.Header = "Action";

            //// Define the cell template for the buttons
            //FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            //buttonFactory.SetValue(Button.ContentProperty, "Action");
            //buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));

            //// Set the visual tree of the cell template
            //DataTemplate cellTemplate = new DataTemplate();
            //cellTemplate.VisualTree = buttonFactory;

            //// Set the cell template to the column
            //buttonColumn.CellTemplate = cellTemplate;

            //// Add the column to the DataGrid
            //usersgrid.Columns.Add(buttonColumn);

            // Bind the DataTable to the DataGrid
            usersgrid.ItemsSource = dt.DefaultView;

            // Set column width for other columns
            usersgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = sender as Button;
        //    if (button != null)
        //    {
        //        // Access the DataContext to get the underlying DataRowView
        //        DataRowView rowView = button.DataContext as DataRowView;
        //        if (rowView != null)
        //        {
        //            // Access row data and perform necessary actions
        //            string status = rowView["status"].ToString(); // Assuming "status" is the column name for user status

        //            // Set the content of the button based on user status
        //            button.Content = (status == "Blocked") ? "Unblock" : "Block";

        //            // Perform actions based on user status
        //            if (status == "Blocked")
        //            {
        //                // Unblock user logic
        //            }
        //            else
        //            {
        //                // Block user logic
        //            }
        //        }
        //    }
        //}

    }
}
