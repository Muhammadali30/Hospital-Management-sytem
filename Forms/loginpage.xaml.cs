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
using System.Windows.Shapes;

namespace Final_Project.Forms
{
    /// <summary>
    /// Interaction logic for loginpage.xaml
    /// </summary>
    public partial class loginpage : Window
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (username.Text=="Ali"&&password.Text=="123")
            //{
            //    MainWindow mainwindow=new MainWindow();
            //    mainwindow.Show();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid UserName or Password");
            //}
        }
    }
}
