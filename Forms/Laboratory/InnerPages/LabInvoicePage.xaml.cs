using Final_Project.Classes;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabInvoicePage.xaml
    /// </summary>
    public partial class LabInvoicePage : Page
    {
        private DataTable template_name = null;
        public LabInvoicePage()
        {
            InitializeComponent();
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
            comboBoxtemplate.SelectedValue = "id";

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
            TextBox textBoxUnit = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Description",
                Style = textBoxStyle
            };
            discription.Children.Add(textBoxUnit);

            // For fieldnormalrangemale
            TextBox ratefield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Rate",
                Style = textBoxStyle
            };
            rate.Children.Add(ratefield);

            // For fieldnormalrangefemale
            TextBox quantityfield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Quantity",
                Style = textBoxStyle
            };
            quantity.Children.Add(quantityfield);

            // For fieldsubheading
            TextBox datefield = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Date",
                Style = textBoxStyle
            };
            date.Children.Add(datefield);

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

        private void comboBoxtemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                DataRowView selectedRow = comboBox.SelectedItem as DataRowView;
                //int deparment_id = selectedRow != null ? Convert.ToInt32(selectedRow["id"]) : 0;
                int id = Convert.ToInt32(selectedRow["id"]);
                MessageBox.Show(id.ToString());
            }
        }

        public void OnButtonClick(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            int del = delete.Children.IndexOf(button);
            delete.Children.RemoveAt(del);
            template.Children.RemoveAt(del);
            rate.Children.RemoveAt(del);
            date.Children.RemoveAt(del);
            quantity.Children.RemoveAt(del);
            discription.Children.RemoveAt(del);
        }

        private void printbutton(object sender, RoutedEventArgs e)
        {
            EmailClass.Send_Email();
            //PdfClass pc = new PdfClass(); 

            //PdfDocument pdfDocument = pc.Main();

            //// Convert the PDF document to a FlowDocument
            //FlowDocument flowDocument = ConvertToFlowDocument(pdfDocument);

            //// Show the FlowDocument in the FlowDocumentScrollViewer
            //flowDocumentViewer.Document = flowDocument;

        }
        private FlowDocument ConvertToFlowDocument(PdfDocument pdfDocument)
        {
            FlowDocument flowDocument = new FlowDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                // Save the PDF document to the memory stream
                pdfDocument.Save(stream, false);

                // Reset the stream position to the beginning
                stream.Position = 0;

                // Load the content of the memory stream into the FlowDocument
                TextRange textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                textRange.Load(stream, DataFormats.Xaml);
            }

            return flowDocument;
        }
    }
}
