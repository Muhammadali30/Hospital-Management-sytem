using Final_Project.Classes;
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
            TextBox textBoxUnit = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Description",
                Style = textBoxStyle
            };
            discription.Children.Add(textBoxUnit);

            // For fieldnormalrangemale
            TextBox pricefield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Rate",
                Style = textBoxStyle
            };
            price.Children.Add(pricefield);

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
            discription.Children.RemoveAt(del);
        }

        private void printbutton(object sender, RoutedEventArgs e)
        {
           int total_price = 0;
            for (int i=0;i<template.Children.Count;i++)
            {
                var t = template.Children[i] is Border border ? border.Child as TextBox : null;
                var p = price.Children.Count > i ? price.Children[i] as TextBox : null;
                var da = date.Children.Count > i ? date.Children[i] as TextBox : null;
                var q = quantity.Children.Count > i ? quantity.Children[i] as TextBox : null;
                var di = discription.Children.Count > i ? discription.Children[i] as TextBox : null;

                if (p != null && !string.IsNullOrEmpty(p.Text))
                {
                    total_price += Convert.ToInt32(p.Text);
                }
            }
            totaltextblock.Text = total_price.ToString();






            //EmailClass.Send_Email();
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

        private void TogglePatientButton(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (registerpatients.Visibility==Visibility.Collapsed)
            {
                btn.Content = "Un-Registered";
                registerpatients.Visibility = Visibility.Visible;
                unregisterpatients.Visibility = Visibility.Hidden;
            }
            else
            {
                btn.Content = "Registered";
                registerpatients.Visibility = Visibility.Collapsed;
                unregisterpatients.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
          

        }

        private void discounttextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (combodiscount?.Text == "Value")
            {
               
                    int discount = 0;
                    if (int.TryParse(discounttextbox.Text, out discount))
                    {
                        grandtotaltextblock.Text = (Convert.ToInt16(totaltextblock.Text) - discount).ToString();
                    }
                    else
                    {
                        // Handle invalid discounttextbox.Text
                        grandtotaltextblock.Text = "Invalid discount";
                    }
                }
       

            
        }
    }
}
