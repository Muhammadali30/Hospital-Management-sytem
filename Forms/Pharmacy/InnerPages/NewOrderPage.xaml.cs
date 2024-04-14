using Final_Project.Classes;
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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        public NewOrderPage()
        {
            InitializeComponent();


            //private void Button_Click_1(object sender, RoutedEventArgs e)
            //{
            //    DataRowView alt_medicine = (DataRowView)medicinecombobox.SelectedItem;
            //    MessageBox.Show(alt_medicine["name"].ToString());
            //    StackPanel spid = CreateTags.create_stackpanel(null, "vertical");
            //    spid.Tag = alt_medicine["id"];
            //    spid.Children.Add(CreateTags.create_textblock(alt_medicine["name"].ToString()));
            //    StackPanel head = CreateTags.create_stackpanel(null, "horizontal");
            //    head.Children.Add(CreateTags.create_textbox(null, 250, true, "Reason"));
            //    Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete");
            //    newbutton.Click += new RoutedEventHandler(OnButtonClick);
            //    head.Children.Add(newbutton);

            //    spid.Children.Add(head);
            //    alternativemedicinelist.Children.Add(spid);
            //}




        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Database db = new Database();
            ComboBoxItem dosageform = (ComboBoxItem)meddosageform.SelectedItem;
            string df = dosageform.Content.ToString();
            DataTable dt = db.Read($"SELECT m.id,m.name,m.rack_no,p.unit_price,p.batch_no from Medicines m JOIN Med_Purchase p ON m.id = p.med_id where name like '{tb.Text}%' and dosageForm = '{df}'");
            sellmedicine.ItemsSource = dt.DefaultView;
            MessageBox.Show(tb.Text);
            sellmedicine.MouseDoubleClick += Collectsamplegrid_MouseDoubleClick;
        }
    private void Collectsamplegrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DataRowView selectedRow = (DataRowView)sellmedicine.SelectedItem;
        if (selectedRow != null)
        {
            int id = Convert.ToInt32(selectedRow["id"]);
            MessageBoxResult mbr = MessageBox.Show($"The ID of the selected row is: {id}", "Confirmation!", MessageBoxButton.YesNo);
                //DataRowView alt_medicine = (DataRowView)medicinecombobox.SelectedItem;
                //MessageBox.Show(selectedRow["name"].ToString());
                StackPanel spid = CreateTags.create_stackpanel(null, "vertical");
                spid.Tag = selectedRow["id"];
                spid.Children.Add(CreateTags.create_textblock(selectedRow["name"].ToString()));
                StackPanel head = CreateTags.create_stackpanel(null, "horizontal");
                StackPanel heada = CreateTags.create_stackpanel(null, "horizontal");
                Button decrement = CreateTags.create_button("WindowMinimize", null, 30, "Remove","Gray");
                Button increment = CreateTags.create_button("Plus", null, 30, "Add","Gray");
                heada.Children.Add(decrement);
                heada.Children.Add(CreateTags.create_textbox(null, 50, false, "0"));
                heada.Children.Add(increment);
                Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete","Red");
                newbutton.Click += new RoutedEventHandler(OnButtonClick);
                head.Children.Add(heada);
                head.Children.Add(newbutton);

                spid.Children.Add(head);
                cartpanel.Children.Add(spid);
            }

        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel buttonparent = button.Parent as StackPanel;
            StackPanel buttonparent_parent = buttonparent.Parent as StackPanel;
            if (buttonparent_parent != null)
            {
                MessageBox.Show(buttonparent_parent.Tag.ToString());
                cartpanel.Children.Remove(buttonparent_parent);
            }
        }
    }
}
