using Final_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for OrderInvoicePage.xaml
    /// </summary>
    public partial class OrderInvoicePage : Page
    {
        private BigInteger order_id;
        public OrderInvoicePage(BigInteger id)
        {
            InitializeComponent();
            order_id = id;
            printpage();
        }

        private void printpage()
        {
            Database db = new Database();
            DataTable dt = db.Read($"select * from [Order] where id = {order_id}");
            if ( dt.Rows.Count > 0 ) 
            {
                DataRow order_row = dt.Rows[0];
                DateTime da = DateTime.ParseExact(order_row["date"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                invoiceno.Text = "Invoice No:  " + order_row["id"].ToString();
                date.Text = "Date:  " + da.ToString("dd-MMMM-yyyy hh:mm:tt");
                subtotal.Text = "SubToTal:  " + order_row["total"].ToString();
                discount.Text = "Discount:  " + order_row["discount"].ToString();
                total.Text = "Total:  "+ (float.Parse(order_row["total"].ToString()) - float.Parse(order_row["discount"].ToString())).ToString();
            }
            DataTable items = db.Read($@"SELECT m.name, ROUND((mp.sale_price / mp.units_in_box), 2) as itemPrice, (mo.item_qty - mo.return_qty) as itemQty,(ROUND((mp.sale_price / mp.units_in_box), 2) * (mo.item_qty - mo.return_qty)) as itemtotal
                                        FROM Medicine_Orders mo
                                        JOIN Med_Purchase mp ON mo.med_id = mp.id
                                        JOIN Medicines m ON mp.med_id = m.id
                                        WHERE order_id = '{order_id}'
                                        ");
            invoiceitems.ItemsSource = items.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(LabInvoicePdf, "Invoice");
            }
        }
    }
}
