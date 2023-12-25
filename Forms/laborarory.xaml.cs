using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for laborarory.xaml
    /// </summary>
    public partial class laborarory : Page
    {
        public ObservableCollection<DataItem> DataItems { get; set; }
        public laborarory()
        {
            InitializeComponent();
            DataItems = new ObservableCollection<DataItem>();
            tests.ItemsSource = DataItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (addtest.Visibility==Visibility.Hidden)
            {
                addtest.Visibility = Visibility.Visible;
                selecttest.Visibility = Visibility.Hidden;
                addtesttext.Text = "Select Test";
            }
            else
            {
                addtest.Visibility = Visibility.Hidden;
                selecttest.Visibility = Visibility.Visible;
                addtesttext.Text = "Add Test";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String val;
            // Add the TextBox value to a new row in the DataGrid
            if (addtest.Visibility == Visibility.Hidden)
            {
               val= selecttest.Text;
               
            }
            else
            {
                val = addtest.Text;
            }
            DataItem newItem = new DataItem { Examination = exatype.Text, Result = testname.Text, Name = testresult.Text, spicemen = val };
            DataItems.Add(newItem);
          

            // Optional: Clear the TextBox after adding the value
            testname.Clear();
        }
    }
    public class DataItem
    {
        public string Examination { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string spicemen { get; set; }


        // Add more columns as needed
    }
}
