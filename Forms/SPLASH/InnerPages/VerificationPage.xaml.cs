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

namespace Final_Project.Forms.SPLASH.InnerPages
{
    /// <summary>
    /// Interaction logic for VerificationPage.xaml
    /// </summary>
    public partial class VerificationPage : Page
    {
        private string email = "";
        public VerificationPage(string e)
        {
            InitializeComponent();
            sendotp();
            email = e;
        }
        private void sendotp()
        {
            string firstThree = email.Substring(0, Math.Min(3, email.Length));
            string lastThree = email.Substring(Math.Max(0, email.Length - 3));
            confirmemail.Text = "Code has sent to " + firstThree + "****" + lastThree;
            EmailClass.Send_Email(email, "Verification Code", "Your verification code is 2345");
        }
    }
}
