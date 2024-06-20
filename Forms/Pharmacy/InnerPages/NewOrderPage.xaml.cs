using Final_Project.Classes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        BigInteger order_id = 0;
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
            SuggestionsListBox.ItemsSource = null;
            TextBox tb = (TextBox)sender;
            Database db = new Database();
            ComboBoxItem dosageform = (ComboBoxItem)meddosageform.SelectedItem;
            string df = dosageform.Content.ToString();
            DataTable dt = db.Read($"SELECT p.id,m.name,m.rack_no,ROUND((p.sale_price / p.units_in_box), 2) as PricePerUnit,p.batch_no as batch,p.date from Medicines m JOIN Med_Purchase p ON m.id = p.med_id where name like '{tb.Text}%' and dosageForm = '{df}' and p.stock_qty > 0");
            SuggestionsListBox.ItemsSource = dt.DefaultView;
            SuggestionsListBox.Visibility = dt.Rows.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            MessageBox.Show(tb.Text);
            //SuggestionsListBox.MouseDoubleClick += Collectsamplegrid_MouseDoubleClick;
        }
        private void Collectsamplegrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SuggestionsListBox.SelectedItem is DataRowView selectedRow)
            {
                int id = Convert.ToInt32(selectedRow["id"]);
                MessageBoxResult mbr = MessageBox.Show($"The ID of the selected row is: {id}", "Confirmation!", MessageBoxButton.YesNo);

                if (mbr == MessageBoxResult.Yes)
                {
                    StackPanel spid = CreateTags.create_stackpanel(null, "vertical");
                    spid.Tag = selectedRow["id"];

                    // Name Panel
                    StackPanel namepanel = CreateTags.create_stackpanel(null, "horizontal");
                    namepanel.Children.Add(CreateTags.create_textblock("Name"));
                    namepanel.Children.Add(CreateTags.create_textblock(selectedRow["name"].ToString()));
                    spid.Children.Add(namepanel);

                    // Price Panel
                    StackPanel pricepanel = CreateTags.create_stackpanel(null, "horizontal");
                    pricepanel.Children.Add(CreateTags.create_textblock("PricePerPiece(Rs)"));
                    pricepanel.Children.Add(CreateTags.create_textblock(selectedRow["PricePerUnit"].ToString()));
                    spid.Children.Add(pricepanel);

                    // Quantity Control Panel
                    StackPanel heada = CreateTags.create_stackpanel(null, "horizontal");
                    Button decrement = CreateTags.create_button("WindowMinimize", null, 30, "Remove", "Gray");
                    decrement.Click += (sender, e) => cartitemcount(sender, e, false);
                    Button increment = CreateTags.create_button("Plus", null, 30, "Add", "Gray");
                    increment.Click += (sender, e) => cartitemcount(sender, e, true);
                    heada.Children.Add(decrement);
                    heada.Children.Add(CreateTags.create_textbox("0", 50, false, "0"));
                    heada.Children.Add(increment);
                    spid.Children.Add(heada);

                    // Delete Button
                    Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete", "Red");
                    newbutton.Click += new RoutedEventHandler(DeleteFromCart);
                    spid.Children.Add(newbutton);

                    cartpanel.Children.Add(spid);

                    // Update total price (uncomment and adapt if you have a total price TextBlock)
                    // totalpricetextblock.Text = (float.Parse(totalpricetextblock.Text) + float.Parse(selectedRow["PricePerUnit"].ToString())).ToString();
                }
            }
        }
        private void DeleteFromCart(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel buttonparent = button.Parent as StackPanel;
            if (buttonparent != null)
            {
                MessageBox.Show(buttonparent.Tag.ToString());
                cartpanel.Children.Remove(buttonparent);
            }
        }
        private void cartitemcount(object sender, RoutedEventArgs e, bool flag)
        {
            Button button = (Button)sender;
            StackPanel buttonparent = button.Parent as StackPanel;
            StackPanel buttongrandparent = buttonparent.Parent as StackPanel;
            StackPanel grandparentsecondchild = (StackPanel)buttongrandparent.Children[1];
            TextBlock uncle = (TextBlock)grandparentsecondchild.Children[1];
            if (buttonparent != null)
            {
                TextBox itemcount = (TextBox)buttonparent.Children[1];
                int value = Convert.ToInt32(itemcount.Text);
                float totalprice = float.Parse(totalpricetextblock.Text);
                float itemprice = float.Parse(uncle.Text);
                if (flag == true)
                {
                    itemcount.Text = (++value).ToString();
                    totalpricetextblock.Text = ((value * itemprice)).ToString();
                }
                else
                {
                    if (value == 0) { return; }
                    totalpricetextblock.Text = (totalprice - itemprice).ToString();
                    itemcount.Text = (value -= 1).ToString();

                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int discount = 0;
            if (int.TryParse(discounttextbox.Text, out discount))
            {
                afterdiscount.Text = (Convert.ToInt16(totalpricetextblock.Text) - discount).ToString();
            }
            else
            {
                // Handle invalid discounttextbox.Text
                afterdiscount.Text = "Invalid discount";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            order_id = db.GetInsertedId($@"INSERT INTO [Order] ([date], discount, total) OUTPUT INSERTED.id 
            VALUES ('{currentDate}', {float.Parse(discounttextbox.Text.ToString())}, '{float.Parse(totalpricetextblock.Text.ToString())}')");

            string data = "INSERT INTO Medicine_Orders(med_id,item_qty,order_id) VALUES";
            for (int i = 0; i < cartpanel.Children.Count; i++)
            {
                StackPanel cartpanelchild = (StackPanel)cartpanel.Children[i];
                StackPanel child1 = (StackPanel)cartpanelchild.Children[1];
                StackPanel child2 = (StackPanel)cartpanelchild.Children[2];

                //TextBlock price = (TextBlock)child1.Children[1];
                TextBox item_qty = (TextBox)child2.Children[1];
                db.Add($"Update Med_Purchase set stock_qty = stock_qty - '{Convert.ToInt32(item_qty.Text)}' where id = '{Convert.ToInt32(cartpanelchild.Tag)}'");
                if (cartpanel.Children.Count == i + 1)
                {
                    data += $"({Convert.ToInt32(cartpanelchild.Tag.ToString())},{Convert.ToInt32(item_qty.Text)},{order_id})";
                }
                else
                {
                    data += $"({Convert.ToInt32(cartpanelchild.Tag.ToString())},{Convert.ToInt32(item_qty.Text)},{order_id}),";
                }
                db.Add(data);
                MessageBox.Show("Record Successfully Created");
                if (NavigationService != null)
                {
                    // Remove the current page from the navigation history
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.RemoveBackEntry();
                    }

                    // Load the new page within the same frame
                    NavigationService.Navigate(new OrderInvoicePage(order_id));
                }
            }
        }
    }
}
