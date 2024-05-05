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

namespace Final_Project.Forms.Admin
{
    /// <summary>
    /// Interaction logic for AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        private int userid;
        public AddUsersPage(int? id = null)
        {
            InitializeComponent();
            userid = id ?? 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            ComboBoxItem userrole = (ComboBoxItem)role.SelectedItem;
            ComboBoxItem userstatus = (ComboBoxItem)status.SelectedItem;
            
            if (userid != 0)
            {
                db.Add($"Update Users set name = '{name.Text}', email = '{email.Text}', password = '{password.Text}', age = '{Convert.ToInt32(age.Text)}', role = '{userrole.Content}', status = '{userstatus.Content}' where id = {userid}");
                MessageBox.Show("Your Record is Updated");
                return;
            }

            db.Add($"INSERT into USERS(name,email,password,age,role,status) VALUES ('{name.Text}','{email.Text}','{password.Text}','{age.Text}','{userrole.Content}','{userstatus.Content}')");
        }
    }
}
