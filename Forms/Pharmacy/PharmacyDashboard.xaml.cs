using Final_Project.Classes;
using Humanizer;
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

namespace Final_Project.Forms.Pharmacy
{
    /// <summary>
    /// Interaction logic for PharmacyDashboard.xaml
    /// </summary>
    public partial class PharmacyDashboard : Page
    {
        public PharmacyDashboard()
        {
            InitializeComponent();
            Database database = new Database();
            medicinecount.Text = database.value("SELECT COUNT(*) from Medicines").ToString();
            stockempty.Text = database.value($"SELECT COUNT(*) FROM(SELECT m.id, COALESCE(SUM(mp.stock_qty), 0) AS TotalQuantity FROM Medicines m LEFT JOIN Med_Purchase mp ON m.id = mp.med_id GROUP BY m.id HAVING COALESCE(SUM(mp.stock_qty), 0) < 0) AS subquery; ").ToString();
            expiredcount.Text = database.value($"SELECT COUNT(*) from Med_Purchase where expiry < '{DateTime.Today.ToString("yyyy-MM-dd")}'").ToString();
            orders.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Medicine_Orders") };
            returns.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Medicine_Orders where return_qty > 0") };
            LoadMedicines(DateTime.Now);
        }

        private void LoadMedicines(DateTime Date)
        {
            string from_date = Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            string to_date = Date.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
            Database database = new Database();
            DataTable dt = database.Read($@"
    SELECT M.name Name, MO.item_qty SaleQty, O.date DateTime
    FROM Medicine_Orders AS MO
    LEFT JOIN [Order] AS O ON MO.order_id = O.id
    LEFT JOIN Med_Purchase AS MP ON MO.med_id = MP.id
    LEFT JOIN Medicines AS M ON MP.med_id = M.id
    WHERE O.date BETWEEN '{to_date}' AND '{from_date}'");

            medicinegrid.ItemsSource = dt.DefaultView;

            // Set column width for other columns
            medicinegrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }

        private void salesdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (salesdate.SelectedDate.HasValue)
            {
                DateTime selectedDate = salesdate.SelectedDate.Value;
                LoadMedicines(selectedDate);
            }

        }
    }
}
