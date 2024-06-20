using Final_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AddStockPage.xaml
    /// </summary>
    public partial class AddStockPage : Page
    {
        private DataTable suppliers_record = null, medicine_record = null;
        public AddStockPage()
        {
            InitializeComponent();
            Loadsupplier();
        }


        private void Loadsupplier()
        {
            if (suppliers_record == null)
            {
                Database db = new Database();
                suppliers_record = db.Read($"SELECT id,name from Suppliers");
                DataRow newRow = suppliers_record.NewRow();
                newRow["name"] = "Select Supplier";
                newRow["id"] = -1;
                suppliers_record.Rows.InsertAt(newRow, 0);
                Supplier_Combo.ItemsSource = suppliers_record.DefaultView;
                Supplier_Combo.DisplayMemberPath = "name";
                Supplier_Combo.SelectedIndex = 0;
                medicine_record = db.Read($"SELECT id,name from Medicines");
                newRow = medicine_record.NewRow();
                newRow["name"] = "Select Medicine";
                newRow["id"] = -1;
                medicine_record.Rows.InsertAt(newRow, 0);
                Medicine_Combo.ItemsSource = medicine_record.DefaultView;
                Medicine_Combo.DisplayMemberPath = "name";
                Medicine_Combo.SelectedIndex = 0;

            }
        }

        private void ItemButton(object sender, RoutedEventArgs e)
        {
            Border b = CreateTags.create_border(155);
            ComboBox c = CreateTags.create_combobox(150);
            c.ItemsSource = suppliers_record.DefaultView;
            c.DisplayMemberPath = "name";
            c.SelectedIndex = 0;
            b.Child = c;
            Supplier.Children.Add(b);
            b = CreateTags.create_border(155);
            c = CreateTags.create_combobox(150);
            c.ItemsSource = medicine_record.DefaultView;
            c.DisplayMemberPath = "name";
            c.SelectedIndex = 0;
            b.Child = c;
            Medicine.Children.Add(b);

            Voucher_No.Children.Add(CreateTags.create_textbox("", 120,null,"Voucher No"));
            Units_In_Box.Children.Add(CreateTags.create_textbox("", 80, null, "0"));
            Expiry.Children.Add(CreateTags.create_textbox("", 180, null, "Expiry"));
            Cost_Price.Children.Add(CreateTags.create_textbox("", 80, null, "Cost_Price"));
            Sale_Price.Children.Add(CreateTags.create_textbox("", 80, null, "Sale_Price"));
            Unit_Price.Children.Add(CreateTags.create_textbox("", 70, null, "0"));
            Button newButton = CreateTags.create_button("Delete", null, 30, "Delete item", "Red");
            //newButton.Click += (sender, e) => OnButtonClick("Hello from dynamic button!", count);
            newButton.Click += new RoutedEventHandler(OnButtonClick);
            delete.Children.Add(newButton);
        }

            private void OnButtonClick(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                int del = delete.Children.IndexOf(button);
                Supplier.Children.RemoveAt(del);
                Medicine.Children.RemoveAt(del);
                Voucher_No.Children.RemoveAt(del);
                delete.Children.RemoveAt(del);
                Units_In_Box.Children.RemoveAt(del);
                Expiry.Children.RemoveAt(del);
                Cost_Price.Children.RemoveAt(del);
                Sale_Price.Children.RemoveAt(del);
                Unit_Price.Children.RemoveAt(del);
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Supplier_Combo_DropDownOpened(object sender, EventArgs e)
        {
            CreateTags.tag_focus(sender, e);
        }

        private void Supplier_Combo_DropDownClosed(object sender, EventArgs e)
        {
            CreateTags.tag_focus(sender, e);
        }

        private void Medicine_Combo_DropDownClosed(object sender, EventArgs e)
        {
            CreateTags.tag_focus(sender, e);
        }

        private void Supplier_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_once(sender, e, Supplier);
        }

        private void Medicine_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_once(sender, e, Medicine);
        }

        private void select_once(object sender, SelectionChangedEventArgs e, StackPanel model)
        {
            if (sender is ComboBox comboBox)
            {
                int selectedIndex = comboBox.SelectedIndex;

                foreach (var cb in model.Children.OfType<Border>().Select(b => b.Child).OfType<ComboBox>())
                {
                    cb.SelectedIndex = selectedIndex;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Medicine_Combo_DropDownOpened(object sender, EventArgs e)
        {
            CreateTags.tag_focus(sender, e);
        }
    }
}
