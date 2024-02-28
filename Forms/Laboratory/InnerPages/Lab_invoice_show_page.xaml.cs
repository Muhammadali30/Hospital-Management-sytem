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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for Lab_invoice_show_page.xaml
    /// </summary>
    public partial class Lab_invoice_show_page : Page
    {
        public Lab_invoice_show_page(int id)
        {
            InitializeComponent();
            h.Text += id.ToString();
        }
    }
}
