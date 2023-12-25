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
    /// Interaction logic for LabDepartmentPage.xaml
    /// </summary>
    public partial class LabDepartmentPage : Page
    {
        public LabDepartmentPage()
        {
            InitializeComponent();
        }

        private void CancelDepartmentFormButton(object sender, RoutedEventArgs e)
        {
            adddepartmentform.Visibility = Visibility.Hidden;
            addbtn.Visibility = Visibility.Visible;
        }

        private void ShowDepartmentFormButton(object sender, RoutedEventArgs e)
        {
            addbtn.Visibility = Visibility.Hidden;
            adddepartmentform.Visibility = Visibility.Visible;
        }
    }
}
