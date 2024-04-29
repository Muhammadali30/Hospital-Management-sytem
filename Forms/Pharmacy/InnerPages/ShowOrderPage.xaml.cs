using Final_Project.Classes;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Interaction logic for ShowOrderPage.xaml
    /// </summary>
    public partial class ShowOrderPage : Page
    {
        private int order_id,update_flag, return_flag;
        public ShowOrderPage(int id)
        {
            InitializeComponent();
            order_id = id;
            LoadRecord();

        }
        private void LoadRecord()
        {
            Database db = new Database();
            DataTable dt = db.Read($"Select * from [Order] where id = '{order_id}'");
            DataRow order_row = dt.Rows[0];
            DateTime da = DateTime.ParseExact(order_row["date"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            date.Text = da.ToString("dd-MMMM-yyyy hh:mm:tt");
            discount.Text = order_row["discount"].ToString();
            total.Text = order_row["total"].ToString();

            DataTable items = db.Read($@"SELECT mo.id, m.name, ROUND((mp.sale_price / mp.units_in_box), 2) as itemPrice, mo.item_qty, mo.return_qty
                                        FROM Medicine_Orders mo
                                        JOIN Med_Purchase mp ON mo.med_id = mp.id
                                        JOIN Medicines m ON mp.med_id = m.id
                                        WHERE order_id = '{order_id}'
                                        ");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in items.Rows)
                {
                    itemid.Children.Add(CreateTags.create_textblock(row["id"].ToString()));

                    itemprice.Children.Add(CreateTags.create_textblock(row["itemPrice"].ToString()));
                    float item_total_price = float.Parse(row["itemPrice"].ToString()) * float.Parse(row["item_qty"].ToString());
                    itemname.Children.Add(CreateTags.create_textblock(row["name"].ToString()));
                    TextBlock totaltb = CreateTags.create_textblock(item_total_price.ToString());
                    itemtotal.Children.Add(totaltb);
                    TextBox item_qty_box = CreateTags.create_textbox(row["item_qty"].ToString(), 100, false);
                    itemqty.Children.Add(item_qty_box);
                    item_qty_box.TextChanged += (sender, e) => ItemQtyBox_TextChanged(sender, e, totaltb, row["itemPrice"].ToString());
                    TextBox returntb = CreateTags.create_textbox(row["return_qty"].ToString(), 100, false);
                    returnqty.Children.Add(returntb);
                    returntb.TextChanged += (sender, e) => return_TextChanged(sender, e, totaltb, row["item_qty"].ToString(), row["itemPrice"].ToString());
                    Button del = CreateTags.create_button("Delete", null, 30, "Delete", "Red");
                    deletepanel.Children.Add(del);
                    del.Click += new RoutedEventHandler(Deleteorderitem);

                }
                //DataTable items = db.Read($"SELECT * from Medicine_Orders where order_id = '{order_id}'");
                //ordersitemgrid.ItemsSource = items.DefaultView;
            }
           

            //private void showdoctorsbutton_Click(object sender, RoutedEventArgs e)
            //{
            //    try
            //    {
            //        reasonpanel.Visibility = Visibility.Visible;

            //        Database db = new Database();
            //        DataTable items = db.Read($"SELECT * from Medicine_Orders where order_id = '{order_id}'");

            //        // Add a new column named "Return.Qty" to your DataTable
            //        DataColumn newColumn = new DataColumn("Return.Qty", typeof(string));
            //        items.Columns.Add(newColumn);

            //        // Refresh the DataGrid to reflect changes
            //        ordersitemgrid.ItemsSource = null;

            //        ordersitemgrid.ItemsSource = items.DefaultView;
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle exceptions here
            //        MessageBox.Show($"An error occurred: {ex.Message}");
            //    }

            //}

            //private void ordersitemgrid_CurrentCellChanged(object sender, EventArgs e)
            //{
            //    // Get the selected row
            //    DataRowView selectedRow = ordersitemgrid.SelectedItem as DataRowView;

            //    if (selectedRow != null)
            //    {
            //        // Access the data in the selected row
            //        // For example, you can access a specific column like this:
            //        string valueInFirstColumn = selectedRow.Row["NewColumn"].ToString();

            //        // Or you can access all columns in the row using a loop:
            //        foreach (DataColumn column in selectedRow.Row.Table.Columns)
            //        {
            //            string columnValue = selectedRow.Row[column.ColumnName].ToString();
            //            MessageBox.Show(columnValue);
            //        }
            //    }
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            string return_data = "Update Medicine_Orders set return_qty = CASE ";
            //db.Add()

            if (return_flag == 1)
            {
                for (int i = 0; i < itemqty.Children.Count; i++)
                {
                    if (i == 0) { continue; }
                    TextBlock item_id = itemid.Children[i] as TextBlock;
                    TextBox returnTextBox = returnqty.Children[i] as TextBox;

                    return_data += $"WHEN id = {Convert.ToInt32(item_id.Text)} THEN {Convert.ToInt32(returnTextBox.Text)}";

                }
                return_data += " ELSE return_qty END;";
                //MessageBox.Show(return_data);
                db.Add(return_data);
            }
            if (update_flag == 1)
            {
                db.Add($"Delete from Medcine_Orders where order_id = '{order_id}'");
            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            return_flag = 1;
            update_flag = 0;
            deletepanel.Visibility = Visibility.Collapsed;


            for (int i = 0; i < itemqty.Children.Count; i++)
            {
                if (i == 0) { continue; }
                TextBox returnTextBox = returnqty.Children[i] as TextBox;

                if (returnTextBox != null)
                {
                    returnTextBox.IsEnabled = true;
                    discount.IsEnabled = true;
                    returnTextBox.BorderBrush = Brushes.Red;
                    discount.BorderBrush = Brushes.Red;

                }
                TextBox itemTextBox = itemqty.Children[i] as TextBox;
                if (itemTextBox != null)
                {
                    itemTextBox.IsEnabled = false;
                    itemTextBox.BorderBrush = Brushes.Gray;

                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            update_flag = 1;
            return_flag = 0;
            deletepanel.Visibility = Visibility.Visible;

            for (int i = 0; i < itemqty.Children.Count; i++)
            {
                if (i == 0) { continue; }
                TextBox itemTextBox = itemqty.Children[i] as TextBox;

                if (itemTextBox != null)
                {
                    itemTextBox.IsEnabled = true;
                    discount.IsEnabled = true;
                    itemTextBox.BorderBrush = Brushes.Red; 
                    discount.BorderBrush = Brushes.Red;
                }
                TextBox returnTextBox = returnqty.Children[i] as TextBox;

                if (returnTextBox != null)
                {
                    returnTextBox.IsEnabled = false;
                    returnTextBox.BorderBrush = Brushes.Gray;

                }
            }
        }
        private void Deleteorderitem(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int del = deletepanel.Children.IndexOf(button);
            deletepanel.Children.RemoveAt(del);
            itemname.Children.RemoveAt(del);
            itemtotal.Children.RemoveAt(del);
            itemqty.Children.RemoveAt(del);
            returnqty.Children.RemoveAt(del);
            itemid.Children.RemoveAt(del);
            itemprice.Children.RemoveAt(del);
            medtotal();
        }

        private void medtotal()
        {
            float total_order_price = 0;

            for (int i = 0; i < itemqty.Children.Count; i++)
            {
                if (i == 0) { continue; }
                TextBlock itemTextBox = itemtotal.Children[i] as TextBlock;

                if (itemTextBox != null)
                {
                    total_order_price += float.Parse(itemTextBox.Text);
                }
            }
            MessageBox.Show(total_order_price.ToString());

            total.Text = total_order_price.ToString();
        }

        private void deleteorder_button(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            MessageBoxResult result = MessageBox.Show("Are you sure to delete this order?", "Confirmation!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                db.Add($"Delete from [Order] where id = {order_id}");
                if (NavigationService != null)
                {
                    // Remove the current page from the navigation history
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.RemoveBackEntry();
                    }

                    // Load the new page within the same frame
                    NavigationService.Navigate(new MedicineOrdersPage());
                }
            }
           
        }

        private void printview_button(object sender, RoutedEventArgs e)
        {
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

        private void ItemQtyBox_TextChanged(object sender, TextChangedEventArgs e, TextBlock totalprice, string itemprice)
        {

            TextBox textBox = sender as TextBox;

            if (int.TryParse(textBox.Text, out int parsedValue))
            {
                totalprice.Text = (float.Parse(itemprice) * Convert.ToInt32(textBox.Text)).ToString();

            }
            else
            {
                MessageBox.Show("Add integer");
                textBox.Text = "0";
            }
            medtotal();
        }
        private void return_TextChanged(object sender, TextChangedEventArgs e, TextBlock totalprice, string itemqty, string p)
            {

                TextBox textBox = sender as TextBox;

                if (int.TryParse(textBox.Text, out int parsedValue))
                {
                if (Convert.ToInt32(itemqty)< Convert.ToInt32(textBox.Text)) { MessageBox.Show("Return QTy must be less than total items"); textBox.Text = "0"; return; }
                int actual_items = (Convert.ToInt32(itemqty) - Convert.ToInt32(textBox.Text));
                totalprice.Text = (float.Parse(p) * actual_items).ToString();

                //totalprice.Text = (float.Parse(itemprice) * Convert.ToInt32(textBox.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Add integer");
                    textBox.Text = "0";
                }

            medtotal();

        }
    }
}
