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
    /// Interaction logic for NewSupplierPage.xaml
    /// </summary>
    public partial class NewSupplierPage : Page
    {
        public NewSupplierPage()
        {
            InitializeComponent();
        }

        private void GoBackToListSypplierPage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                // Remove the forward navigation entry
                if (NavigationService.CanGoForward)
                {
                    NavigationService.RemoveBackEntry();
                }
                // Go back to the previous page
                NavigationService.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Add($"INSERT INTO Suppliers (name,cnic,email,phone,address,account_no,bank_name) VALUES ('{suppliername.Text}','{Convert.ToInt64(cnic.Text)}','{email.Text}','{Convert.ToInt64(phone.Text)}','{address.Text}','{bankno.Text}','{bankname.Text}')");
        }
    }
}
