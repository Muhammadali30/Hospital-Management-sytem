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
    /// Interaction logic for NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        public NewOrderPage()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Database db = new Database();
            ComboBoxItem dosageform = (ComboBoxItem)meddosageform.SelectedItem;
            string df = dosageform.Content.ToString();
            DataTable dt = db.Read($"SELECT * from Medicines where name like '{tb.Text}%' and dosageForm = '{df}'");
            sellmedicine.ItemsSource = dt.DefaultView;
            MessageBox.Show(tb.Text);
        }
    }
}
