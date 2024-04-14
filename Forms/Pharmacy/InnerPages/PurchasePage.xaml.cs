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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        private string med_dosage_form = "Tablet";
        bool flag = false;
        public PurchasePage()
        {
            InitializeComponent();
            Loadmedicine();
            Loadsupplier();
        }

        private void Loadsupplier()
        {
            DataTable template_name = null;
            if (template_name == null)
            {
                Database db = new Database();
                template_name = db.Read($"SELECT * from Suppliers");
                DataRow newRow = template_name.NewRow();
                newRow["name"] = "Select Supplier";
                newRow["id"] = -1; // Set an arbitrary value for the ID
                template_name.Rows.InsertAt(newRow, 0);

                suppliercombo.ItemsSource = template_name.DefaultView;
                suppliercombo.DisplayMemberPath = "name";
                suppliercombo.SelectedIndex = 0;

            }
        }

        private void Loadmedicine()
        {
            DataTable template_name = null;
            if (template_name == null)
            {
                Database db = new Database();
                template_name = db.Read($"SELECT * from Medicines where dosageForm='{med_dosage_form}'");
                DataRow newRow = template_name.NewRow();
                newRow["name"] = "Select Medicine";
                newRow["id"] = -1; // Set an arbitrary value for the ID
                template_name.Rows.InsertAt(newRow, 0);

                medcombo.ItemsSource = template_name.DefaultView;
                medcombo.DisplayMemberPath = "name";
                medcombo.SelectedIndex = 0;

            }
        }


        private void meddosageform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem dosage = (ComboBoxItem)meddosageform.SelectedItem;
            if (dosage != null)
            {
                med_dosage_form = dosage.Content.ToString();
                if (flag==true)
                {
                    Loadmedicine();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            DateTime selectedDate = date.SelectedDate ?? DateTime.Now;
            DateTime seleexpiryctedDate = expiry.SelectedDate ?? DateTime.Now;
            DataRowView selectedRow = suppliercombo.SelectedItem as DataRowView;
            DataRowView medselectedRow = medcombo.SelectedItem as DataRowView;

            if (Convert.ToInt32(selectedRow["id"])==-1)
            {
                MessageBox.Show("Please Select Supplier");
                return;
            }
            if (Convert.ToInt32(medselectedRow["id"]) == -1)
            {
                MessageBox.Show("Please Select Medicine");
                return;
            }

            db.Add($@"
INSERT INTO Med_Purchase 
(batch_no, voucher_no, supplier_id, med_id, no_of_boxes, units_in_box, expiry, date, unit_price, purchase_price) 
VALUES 
('{medselectedRow["name"]}' + CAST((SELECT MAX(id) + 1 FROM Med_Purchase) AS NVARCHAR(10)), 
 '{voucher_no.Text}', 
 {Convert.ToInt64(selectedRow["id"])}, 
 {Convert.ToInt64(medselectedRow["id"])}, 
 {Convert.ToInt32(noofboxes.Text)}, 
 {Convert.ToInt32(unitsinbox.Text)}, 
 '{seleexpiryctedDate:yyyy-MM-dd}', 
 '{selectedDate:yyyy-MM-dd}', 
 {Convert.ToInt32(unitprice.Text)}, 
 {Convert.ToInt32(purchaseprice.Text)})");

        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            flag = true;
        }
    }
}
