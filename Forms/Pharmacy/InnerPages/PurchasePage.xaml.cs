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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        private string med_dosage_form;
        public PurchasePage()
        {
            InitializeComponent();
        }

        private void meddosageform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem dosage = (ComboBoxItem)meddosageform.SelectedItem;
            if (dosage != null) { med_dosage_form = dosage.Content.ToString(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Add($"INSERT INTO Med_Purchase(batch_no,voucher_no,supplier_id,med_id,no_of_boxes,units_in_box,expiry,date,unit_price,purchase_price) SELECT CONCAT('Hello',COALESCE(MAX(id),0)+1),'{Convert.ToInt32(voucher_no.Text)}','NULL','NULL','{Convert.ToInt32(noofboxes.Text)}'");
        }
    }
}
