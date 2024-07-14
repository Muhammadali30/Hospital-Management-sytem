using Final_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using System.Windows.Controls;
using Icon = MahApps.Metro.IconPacks;
using System.Numerics;
using Humanizer;
using System.Windows.Markup;

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for AddMedicinePage.xaml
    /// </summary>
    public partial class AddMedicinePage : Page
    {
        private  Database db = new Database();
        public AddMedicinePage()
        {
            InitializeComponent();
            load();
            LoadCategory();
        }

        private void load()
        {
            DataTable template_name = db.Read("SELECT id, CONCAT(name, ' - ' ,active_ingredients) name from Medicines");
            DataRow newRow = template_name.NewRow();
            newRow["name"] = "Select Medicine";
            newRow["id"] = -1; // Set an arbitrary value for the ID
            template_name.Rows.InsertAt(newRow, 0);
            //medicinecombobox.SelectionChanged += comboBoxtemplate_SelectionChanged;
            medicinecombobox.ItemsSource = template_name.DefaultView;
            medicinecombobox.DisplayMemberPath = "name";
            medicinecombobox.SelectedValue = "price";
            medicinecombobox.SelectedIndex = 0;
        }

        private void BackToMedListPage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                // Remove the forward navigation entry
                if (NavigationService.CanGoForward)
                {
                    NavigationService.RemoveBackEntry();
                }
                // Go back to the previous page
                NavigationService.GoBack();
            }
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView alt_medicine = (DataRowView)medicinecombobox.SelectedItem;
            MessageBox.Show(alt_medicine["name"].ToString());
            StackPanel spid = CreateTags.create_stackpanel(null, "vertical");
            spid.Tag = alt_medicine["id"];
            spid.Children.Add(CreateTags.create_textblock(alt_medicine["name"].ToString()));
            StackPanel head = CreateTags.create_stackpanel(null, "horizontal");
            head.Children.Add(CreateTags.create_textbox(null, 250,true,"Reason"));
            Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete","Red");
            newbutton.Click += new RoutedEventHandler(OnButtonClick);
            head.Children.Add(newbutton);
            spid.Children.Add(head);
            alternativemedicinelist.Children.Add(spid);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel buttonparent = button.Parent as StackPanel;
            StackPanel buttonparent_parent = buttonparent.Parent as StackPanel;
            if (buttonparent_parent != null)
            {
                MessageBox.Show(buttonparent_parent.Tag.ToString());
                alternativemedicinelist.Children.Remove(buttonparent_parent);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BigInteger med_id = 0;
            ComboBoxItem dosage = (ComboBoxItem)meddosageform.SelectedItem;
            if (dosage != null)
            {
                med_id = db.GetInsertedId($"INSERT INTO Medicines (name,active_ingredients,rack_no,storage_condition,dosageForm,medication_unit,unit_value,instructions) OUTPUT INSERTED.id  VALUES ('{medname.Text}','{medingredients.Text}','{medrackno.Text}','{medstoragecondition.Text}','{dosage.Content.ToString()}','{medunit.Text}','{float.Parse(medunitvalue.Text)}','{medinstructions.Text}')");
                MessageBox.Show("Medicine Added Successfully");
            }

            if (alternativemedicinelist.Children.Count > 0)
            {
                string data = "INSERT INTO Medicine_Alternatives (med_id,med_alternative_id,reason) VALUES";
                for (int i = 0; i < alternativemedicinelist.Children.Count; i++)
                {
                    if (alternativemedicinelist.Children[i] is StackPanel stackPanel)
                    {
                        if (stackPanel.Children.Count >= 2)
                        { 
                            StackPanel secondChild = stackPanel.Children[1] as StackPanel;
                            
                            if (secondChild != null)
                            { 
                                TextBox textbox = secondChild.Children[0] as TextBox;
                                
                                if (textbox != null)
                                {
                                    string tagValue = stackPanel.Tag.ToString();

                                    if (alternativemedicinelist.Children.Count == i + 1)
                                    {
                                        data += $"('{med_id}',{Convert.ToInt32(tagValue)},'{textbox.Text}')";
                                    }
                                    else
                                    {
                                        data += $"('{med_id}',{Convert.ToInt32(tagValue)},'{textbox.Text}'),";
                                    }
                                }
                            }
                        }
                    }
                }
                db.Add(data);
                MessageBox.Show("All data inserted Suucessfully");
                //MessageBox.Show(alternativemedicinelist.Children.Count.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddCategoryPage());
            AF.ShowDialog();
        }
        private void LoadCategory()
        {
            Database db = new Database();
            DataTable template_name = db.Read($"SELECT * from Medicine_Categories");
            DataRow newRow = template_name.NewRow();
            newRow["name"] = "Select Category";
            newRow["id"] = -1; // Set an arbitrary value for the ID
            template_name.Rows.InsertAt(newRow, 0);

            medcategorycombo.ItemsSource = template_name.DefaultView;
            medcategorycombo.DisplayMemberPath = "name";
            medcategorycombo.SelectedIndex = 0;
        }

        private void medcategorycombo_PreviewDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("asd");
        }

        private void medcategorycombo_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                // Set the drop-down width to be larger
                comboBox.Width = 300; // Or any desired width
                comboBox.FontSize = 30;
                comboBox.FontWeight = FontWeights.SemiBold;
            }
        }

        private void medcategorycombo_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                // Set the drop-down width to be larger
                comboBox.Width = 230; // Or any desired width
                comboBox.FontSize = 14;
                comboBox.FontWeight = FontWeights.Normal;
            }
        }

        private void medunitvalue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CreateTags.IsTextAllowed(e.Text);
        }

        private void medunitvalue_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            CreateTags.IsTextAllowedPasting(e);
        }
    }
}
