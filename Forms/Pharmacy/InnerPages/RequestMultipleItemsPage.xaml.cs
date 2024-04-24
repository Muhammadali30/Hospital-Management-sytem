using Final_Project.Classes;
using Humanizer;
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
    /// Interaction logic for RequestMultipleItemsPage.xaml
    /// </summary>
    public partial class RequestMultipleItemsPage : Page
    {
        DataTable categories = null;
        DataTable manufacturers = null;
        public RequestMultipleItemsPage()
        {
            InitializeComponent();
            LoadCategory();
            LoadManufacturer();
        }

        private void LoadCategory()
        {
            Database db = new Database();
            categories = db.Read($"SELECT * from Medicine_Categories");
            DataRow newRow = categories.NewRow();
            newRow["name"] = "Select Category";
            newRow["id"] = -1;
            categories.Rows.InsertAt(newRow, 0);
        }
        private void LoadManufacturer()
        {
            Database db = new Database();
            manufacturers = db.Read($"SELECT * from Medicine_Manufacturers");
            DataRow newRow = manufacturers.NewRow();
            newRow["name"] = "Select Manufacturer";
            newRow["id"] = -1;
            manufacturers.Rows.InsertAt(newRow, 0);
        }

        private void AddNewItemButton(object sender, RoutedEventArgs e)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");

            // For fieldname
            TextBox textitemname = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "Item Name",
                Style = textBoxStyle
            };
            itemname.Children.Add(textitemname);

            // For fieldunit
            ComboBox comboboxcategory = new ComboBox
            {
                Name = "comboboxcategory",
                Background = Brushes.White,
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                Width = 125,
                IsEditable = true,
                IsTextSearchEnabled = true,
                StaysOpenOnEdit = true,
                Margin = new Thickness(2)
            };

            comboboxcategory.SelectionChanged += comboboxcategory_SelectionChanged;
            comboboxcategory.ItemsSource = categories.DefaultView;
            comboboxcategory.DisplayMemberPath = "name";
            comboboxcategory.SelectedIndex = 0;

            Border border = new Border
            {
                CornerRadius = new CornerRadius(3),
                Margin = new Thickness(7),
                Background = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(30, 146, 155)), // #1E929B
                BorderThickness = new Thickness(1),
                Child = comboboxcategory
            };

            categorypanel.Children.Add(border);
            // For fieldnormalrangemale
            TextBox textrack = new TextBox
            {
                Width = 70,
                Margin = new Thickness(5),
                Tag = "Rack#",
                Style = textBoxStyle
            };
            rack.Children.Add(textrack);

            // For fieldnormalrangefemale
            TextBox textstatus = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "Status",
                Style = textBoxStyle
            };
            status.Children.Add(textstatus);

            // For fieldsubheading
            ComboBox comboboxmanufacturer = new ComboBox
            {
                Name = "comboboxmanufacturer",
                Background = Brushes.White,
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                Width = 125,
                IsEditable = true,
                IsTextSearchEnabled = true,
                StaysOpenOnEdit = true,
                Margin = new Thickness(2)
            };

            comboboxmanufacturer.SelectionChanged += comboboxcategory_SelectionChanged;
            comboboxmanufacturer.ItemsSource = manufacturers.DefaultView;
            comboboxmanufacturer.DisplayMemberPath = "name";
            comboboxmanufacturer.SelectedIndex = 0;

            Border border1 = new Border
            {
                CornerRadius = new CornerRadius(3),
                Margin = new Thickness(7),
                Background = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(30, 146, 155)), // #1E929B
                BorderThickness = new Thickness(1),
                Child = comboboxmanufacturer
            };

            manufacturer.Children.Add(border1);

            TextBox textcondition = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Storage Condition",
                Style = textBoxStyle
            };
            storagecondition.Children.Add(textcondition);

            TextBox textdosage = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Dosage Form",
                Style = textBoxStyle
            };
            dosageForm.Children.Add(textdosage);

            TextBox textunit = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "E.G,mg, ml",
                Style = textBoxStyle
            };
            unit.Children.Add(textunit);

            TextBox textunitvalue = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            unitvalue.Children.Add(textunitvalue);

            //TextBox textnarcotic = new TextBox
            //{
            //    Width = 20,
            //    Margin = new Thickness(5),
            //    Tag = "",
            //    Style = textBoxStyle
            //};
            //narcotic.Children.Add(textnarcotic);

            Button newButton = new Button
            {
                Content = "Delete",
                Width = 90,
                Height = 30,
                Margin = new Thickness(5),
                Background = Brushes.Red,
                FontWeight = FontWeights.Bold,

            };
            Style editbutton = (Style)Application.Current.FindResource("editbutton");
            newButton.Style = editbutton;
            //newButton.Click += (sender, e) => OnButtonClick("Hello from dynamic button!", count);
            newButton.Click += new RoutedEventHandler(OnButtonClick);

            delete.Children.Add(newButton);
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int del = delete.Children.IndexOf(button);
            itemname.Children.RemoveAt(del);
            delete.Children.RemoveAt(del);
            categorypanel.Children.RemoveAt(del);
            rack.Children.RemoveAt(del);
            status.Children.RemoveAt(del);
            manufacturer.Children.RemoveAt(del);
            storagecondition.Children.RemoveAt(del);
            dosageForm.Children.RemoveAt(del);
            unit.Children.RemoveAt(del);
            unitvalue.Children.RemoveAt(del);
            //narcotic.Children.RemoveAt(del);
        }

        private void comboboxcategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string data = "INSERT INTO Medicines(name,category_id,status,rack_no,manufacturer_id,storage_condition,dosageForm,medication_unit,unit_value)VALUES";
            DataRowView categoryselectedRow = null;
            DataRowView manufacrurerselectedRow = null;

            for (int i = 0; i < itemname.Children.Count; i++)
            {
                var itemnameT = itemname.Children.Count > i ? itemname.Children[i] as TextBox : null;
                var categoryC = categorypanel.Children[i] is Border border ? border.Child as ComboBox : null;
                var rackT = rack.Children.Count > i ? rack.Children[i] as TextBox : null;
                var statusT = status.Children.Count > i ? status.Children[i] as TextBox : null;
                var manufacurerC = manufacturer.Children[i] is Border border1 ? border1.Child as ComboBox : null;
                var conditionT = storagecondition.Children.Count > i ? storagecondition.Children[i] as TextBox : null;
                var dosageT = dosageForm.Children.Count > i ? dosageForm.Children[i] as TextBox : null;
                var UnitT = unit.Children.Count > i ? unit.Children[i] as TextBox : null;
                var valueT = unitvalue.Children.Count > i ? unitvalue.Children[i] as TextBox : null;

                if (categoryC != null && categoryC.SelectedItem is DataRowView)
                {
                    categoryselectedRow = categoryC.SelectedItem as DataRowView;
                }
                if (manufacurerC != null && manufacurerC.SelectedItem is DataRowView)
                {
                    manufacrurerselectedRow = manufacurerC.SelectedItem as DataRowView;
                }
                if (itemnameT != null && rackT != null && statusT != null && conditionT != null && dosageT != null && UnitT != null && valueT != null)
                {

                if (itemname.Children.Count == i + 1)
                {
                    data += $"('{itemnameT.Text}',{Convert.ToInt32(categoryselectedRow["id"])},'{rackT.Text}','{statusT.Text}',{Convert.ToInt32(manufacrurerselectedRow["id"])},'{conditionT.Text}','{dosageT.Text}','{UnitT.Text}',{Convert.ToInt32(valueT.Text)})";
                }
                else
                {
                    data += $"('{itemnameT.Text}',{Convert.ToInt32(categoryselectedRow["id"])},'{rackT.Text}','{statusT.Text}',{Convert.ToInt32(manufacrurerselectedRow["id"])},'{conditionT.Text}','{dosageT.Text}','{UnitT.Text}',{Convert.ToInt32(valueT.Text)}),";
                }
                }
                         
                    
                    //else
                    //{
                    //    MessageBox.Show("enter correct data");
                    //}
                
            }
            MessageBox.Show(data);
            Database db = new Database();
            db.Add(data);
            //return data;
        }
    }
}
