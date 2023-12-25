using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Final_Project.Forms
{
    /// <summary>
    /// Interaction logic for appointments.xaml
    /// </summary>
    public partial class appointments : Page
    {
        public appointments()
        {
            InitializeComponent();
            DisablePreviousDates();
        }
        private void DisablePreviousDates()
        {

         
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //if (sender is StackPanel sp)
            //{
            //    String id = sp.Tag?.ToString();
            //    if (id!=null)
            //    {
            //        MessageBox.Show($"Tag name is {id}");
            //    }
            //}
        
            
        }
    }
}
