using Final_Project.Classes;
using System;
using System.Collections.Generic;
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
            orders.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Medicine_Orders") };
            returns.Values = new LiveCharts.ChartValues<Double> { database.value("SELECT COUNT(*) from Medicine_Orders where return_qty > 0") };


        }
    }
}
