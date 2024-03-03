using System;
using System.Collections.Generic;
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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for Lab_invoice_show_page.xaml
    /// </summary>
    public partial class Lab_invoice_show_page : Page
    {
        public Lab_invoice_show_page(BigInteger id)
        {
            InitializeComponent();
            //h.Text += id.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog()==true)
            {
                printDialog.PrintVisual(LabInvoicePdf, "Invoice");
            }
        }
    }
}
