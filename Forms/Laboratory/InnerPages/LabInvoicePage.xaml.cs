using Final_Project.Classes;
using Final_Project.Forms.HMS.InnerPages;
using Final_Project.Forms.Pharmacy.InnerPages;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabInvoicePage.xaml
    /// </summary>
    public partial class LabInvoicePage : Page
    {
        private DataTable template_name = null;
        public BigInteger patient_id = -1;
        public LabInvoicePage()
        {
            InitializeComponent();
            
            Database db = new Database();
            DataTable patient_name = db.Read("SELECT id, CONCAT(name,' - ',phone) as name from Patients");
            DataRow newRow = patient_name.NewRow();
            newRow["name"] = "Select Patient";
            newRow["id"] = -1;
            patient_name.Rows.InsertAt(newRow, 0);
            patientscombo.SelectionChanged += patientscombo_SelectionChanged;
            patientscombo.ItemsSource = patient_name.DefaultView;
            patientscombo.DisplayMemberPath = "name";
            patientscombo.SelectedIndex = 0;
        }

        private void AddNewFieldButton(object sender, RoutedEventArgs e)
        {
            if (template_name==null)
            {
                Database db = new Database();
                template_name = db.Read("SELECT id,name,price from Lab_Templates");
                DataRow newRow = template_name.NewRow();
                newRow["name"] = "Select Template";
                newRow["id"] = -1; // Set an arbitrary value for the ID
                template_name.Rows.InsertAt(newRow, 0);
            }

            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");

            // For fieldname
            ComboBox comboBoxtemplate = new ComboBox
            {
                Name = "comboBoxtemplate",
                Background = Brushes.White,
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                Width = 155,
                IsEditable = true,
                IsTextSearchEnabled = true,
                StaysOpenOnEdit = true,
                Margin = new Thickness(2)
            };

            comboBoxtemplate.SelectionChanged += comboBoxtemplate_SelectionChanged;
            comboBoxtemplate.ItemsSource = template_name.DefaultView;
            comboBoxtemplate.DisplayMemberPath = "name";
            comboBoxtemplate.SelectedValue = "price";

            comboBoxtemplate.SelectedIndex = 0;

            Border border = new Border
            {
                CornerRadius = new CornerRadius(3),
                Margin = new Thickness(7),
                Background = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(30, 146, 155)), // #1E929B
                BorderThickness = new Thickness(1),
                Child = comboBoxtemplate
            };

            template.Children.Add(border);

            // For fieldunit
            TextBox textBoxtotal = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle,
                IsEnabled=true
            };
            Total.Children.Add(textBoxtotal);

            // For fieldnormalrangemale
            TextBox pricefield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            price.Children.Add(pricefield);

            // For fieldnormalrangefemale
            TextBox quantityfield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            quantityfield.TextChanged += QuantityField_TextChanged;
            quantity.Children.Add(quantityfield);

            date.Children.Add(CreateTags.create_datepicker(140));

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

        private void QuantityField_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox obj = ((TextBox)sender);
            int index = quantity.Children.IndexOf(obj);
            TextBox total = Total.Children[index] as TextBox;
            TextBox itemprice = price.Children[index] as TextBox;
            if (int.TryParse(obj.Text,out int quantityvalue))
            {
            total.Text = (float.Parse(itemprice.Text) * float.Parse(obj.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Please enter value in correct format e.g 1,2,3");
            }
        }

        private void patientscombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = patientscombo.SelectedItem as DataRowView;
            patient_id = selectedRow != null ? Convert.ToInt32(selectedRow["id"]) : 0;
            if (patient_id != -1)
            {
                newpatientbtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                newpatientbtn.Visibility = Visibility.Visible;
            }
            MessageBox.Show(patient_id.ToString());
        }

        private void comboBoxtemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            //StackPanel stackPanel = comboBox.Parent as StackPanel;
            int index = 0;
            if (comboBox.Parent is Border border && border.Parent is StackPanel stackPanel)
            {
                index = stackPanel.Children.IndexOf(border);
            }
            long p = 0;
            if (comboBox != null)
            {
                DataRowView selectedRow = comboBox.SelectedItem as DataRowView;
                int deparment_id = selectedRow != null ? Convert.ToInt32(selectedRow["id"]) : 0;
                p = selectedRow != null && selectedRow["price"] != DBNull.Value ? Convert.ToInt64(selectedRow["price"]) : 0;
                //MessageBox.Show(deparment_id.ToString()+$" index is {index}.. {p} ");
            }
                if (price.Children[index] is TextBox tx)
                {
                    tx.Text = p.ToString();
                    tx.IsEnabled = false;
                }
        }

        public void OnButtonClick(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            int del = delete.Children.IndexOf(button);
            delete.Children.RemoveAt(del);
            template.Children.RemoveAt(del);
            price.Children.RemoveAt(del);
            date.Children.RemoveAt(del);
            quantity.Children.RemoveAt(del);
            Total.Children.RemoveAt(del);
        }

        private void printbutton(object sender, RoutedEventArgs e)
        {

            invoice_nested_attributes(false,0);





            //EmailClass.Send_Email();
            //PdfClass pc = new PdfClass(); 

            //PdfDocument pdfDocument = pc.Main();

            //// Convert the PDF document to a FlowDocument
            //FlowDocument flowDocument = ConvertToFlowDocument(pdfDocument);

            //// Show the FlowDocument in the FlowDocumentScrollViewer
            //flowDocumentViewer.Document = flowDocument;

        }
      

        private void TogglePatientButton(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddPatientPage(this));
            AF.ShowDialog();
            if (patient_id != -1)
            {
            MessageBox.Show("New Patient is created now you don't need to select");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
          

        }

        private void discounttextbox_KeyUp(object sender, KeyEventArgs e)
        {
            int discount = 0;
            if (int.TryParse(discounttextbox.Text, out discount))
            {
                if (combodiscount?.Text == "Value")
                {
                grandtotaltextblock.Text = (Convert.ToInt16(totaltextblock.Text) - discount).ToString();
                }
                else
                {
                    grandtotaltextblock.Text = ((Convert.ToInt16(totaltextblock.Text) * discount) / 100).ToString();
                }
            }
            else
            {
                // Handle invalid discounttextbox.Text
                grandtotaltextblock.Text = "Invalid discount";
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (patient_id == -1)
            {
                MessageBox.Show("Please select a patient or add a new one","Alert!");
                return;
            }
            Database db = new Database();
            //BigInteger patient_id = db.GetInsertedId($@"INSERT INTO Patients (name,age,email,phone) OUTPUT INSERTED.id 
            //VALUES ('{unregistername.Text}',{Convert.ToInt32(unregisterage.Text)},'{unregisteremail.Text}','{unregisterphone.Text}')");
            //MessageBox.Show(patient_id.ToString());

            BigInteger invoice_id = db.GetInsertedId($@"INSERT INTO Lab_Invoice (datetime,discount,total,discount_type,priority,note,payment_method,unregistered_patient_id,status) OUTPUT INSERTED.id 
            VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',{Convert.ToInt32(discounttextbox.Text)},0,'{combodiscount.Text}','{combopriority.Text}','{notetextbox.Text}','{combopayment.Text}',{patient_id},'pending')");
            MessageBox.Show(invoice_id.ToString());

            db.Add(invoice_nested_attributes(true, invoice_id));
            //if (NavigationService != null)
            //{
            //    // Remove the current page from the navigation history
            //    if (NavigationService.CanGoBack)
            //    {
            //        NavigationService.RemoveBackEntry();
            //    }

            //    // Load the new page within the same frame
            //    NavigationService.Navigate(new Lab_invoice_show_page(long.Parse(invoice_id.ToString())));
            //}

        }

        private string invoice_nested_attributes(Boolean flag,BigInteger invoice_id)
        {

                int total_price = 0;

                string data = "INSERT INTO Invoice_Items (invoice_id,template_id,quantity_sold,price_per_unit,total_price) VALUES ";
                DataRowView selectedRow = null;

                for (int i = 0; i < template.Children.Count; i++)
                {
                    var t = template.Children[i] is Border border ? border.Child as ComboBox : null;
                    var p = price.Children.Count > i ? price.Children[i] as TextBox : null;
                    var da = date.Children.Count > i ? date.Children[i] as TextBox : null;
                    var q = quantity.Children.Count > i ? quantity.Children[i] as TextBox : null;
                    var to = Total.Children.Count > i ? Total.Children[i] as TextBox : null;
                    if (t != null && t.SelectedItem is DataRowView)
                    {
                    selectedRow = t.SelectedItem as DataRowView;
                    }

                if (p != null && !string.IsNullOrEmpty(p.Text) && flag==false)
                {
                    total_price += Convert.ToInt32(to.Text);
                    totaltextblock.Text = total_price.ToString();
                }
                else
                {
                    if (template != null && selectedRow != null && q != null && p != null && to != null)
                    {
                        data += template.Children.Count == i + 1
                            ? $"({invoice_id},{Convert.ToInt32(selectedRow["id"])},{Convert.ToInt32(q.Text)},{Convert.ToInt32(p.Text)},{Convert.ToInt32(to.Text)})"
                            : $"({invoice_id},{Convert.ToInt32(selectedRow["id"])},{Convert.ToInt32(q.Text)},{Convert.ToInt32(p.Text)},{Convert.ToInt32(to.Text)}),";
                    }
                    else
                    {
                      MessageBox.Show("enter correct data");
                    }
                }
            }
                return data;
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
    }
}
