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
        public PurchasePage()
        {
            InitializeComponent();
            
        }

        private void Loadmedicine()
        {
            DataTable template_name = null;
            if (template_name == null)
            {
                Database db = new Database();
                template_name = db.Read("SELECT * from Medicines");
                //DataRow newRow = template_name.NewRow();
                //newRow["name"] = "Select Template";
                //newRow["id"] = -1; // Set an arbitrary value for the ID
                //template_name.Rows.InsertAt(newRow, 0);
                //purchasemedicinecombobox.SelectionChanged += comboBoxtemplate_SelectionChanged;

                medicinecovmbobox.ItemsSource = template_name.DefaultView;
                //asd.DisplayMemberPath = "name";
                //asd.SelectedValue = "price";

                //asd.SelectedIndex = 0;
            }
        }


        private void meddosageform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem dosage = (ComboBoxItem)meddosageform.SelectedItem;
            if (dosage != null)
            {
                med_dosage_form = dosage.Content.ToString();
                Loadmedicine();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            DateTime selectedDate = date.SelectedDate ?? DateTime.Now;
            DateTime seleexpiryctedDate = expiry.SelectedDate ?? DateTime.Now;

            db.Add($@"
  INSERT INTO Med_Purchase 
  (batch_no, voucher_no, supplier_id, med_id, no_of_boxes, units_in_box, expiry, date, unit_price, purchase_price) 
  VALUES 
  (ISNULL('Hello' + CAST((SELECT MAX(id) + 1 FROM Med_Purchase) AS NVARCHAR(10)), 'Hello1'), 
   {Convert.ToInt32(voucher_no.Text)}, 
   NULL, 
   NULL, 
   {Convert.ToInt32(noofboxes.Text)}, 
   {Convert.ToInt32(unitsinbox.Text)}, 
   '{seleexpiryctedDate:yyyy-MM-dd}', 
   '{selectedDate:yyyy-MM-dd}', 
   {Convert.ToInt32(unitprice.Text)}, 
   {Convert.ToInt32(purchaseprice.Text)})");

        }
    }
}
