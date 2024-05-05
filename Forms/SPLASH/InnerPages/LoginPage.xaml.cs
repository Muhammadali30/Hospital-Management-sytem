using Final_Project.Classes;
using Final_Project.Forms.Pharmacy.InnerPages;
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

namespace Final_Project.Forms.SPLASH.InnerPages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SplashForm sf;
        public LoginPage(SplashForm f)
        {
            InitializeComponent();
            sf = f;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            DataTable dt = db.Read($"Select * from Users where email = '{email.Text}' AND password = '{password.Text}'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["status"].ToString() == "Pending")
                {
                    MessageBox.Show("Your account is not active yet");
                    //if (NavigationService != null)
                    //{
                    //    // Remove the current page from the navigation history
                    //    if (NavigationService.CanGoBack)
                    //    {
                    //        NavigationService.RemoveBackEntry();
                    //    }
                    //    NavigationService.Navigate(new VerificationPage(dt.Rows[0]["email"].ToString()));
                    //}
                }
                else
                {
                    MainWindow mw = new MainWindow(dt.Rows[0]["role"].ToString(), dt.Rows[0]["name"].ToString(), dt.Rows[0]["email"].ToString());
                    mw.Show();
                    sf.Close();   
                }
            }
        }
    }
}
