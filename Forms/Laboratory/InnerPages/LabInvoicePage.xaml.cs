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

namespace Final_Project.Forms.Laboratory.InnerPages
{
    /// <summary>
    /// Interaction logic for LabInvoicePage.xaml
    /// </summary>
    public partial class LabInvoicePage : Page
    {
        public LabInvoicePage()
        {
            InitializeComponent();
        }

        private void AddNewFieldButton(object sender, RoutedEventArgs e)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");

            // For fieldname
            TextBox textBoxFieldName = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "Template Name",
                Style = textBoxStyle
            };
            template.Children.Add(textBoxFieldName);

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

            TextBox discountfield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            discount.Children.Add(discountfield);

            TextBox valuefield = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "value",
                Style = textBoxStyle
            };
            value.Children.Add(valuefield);

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
        public void OnButtonClick(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            int del = delete.Children.IndexOf(button);
            delete.Children.RemoveAt(del);
            discount.Children.RemoveAt(del);
            template.Children.RemoveAt(del);
            rate.Children.RemoveAt(del);
            date.Children.RemoveAt(del);
            quantity.Children.RemoveAt(del);
            discription.Children.RemoveAt(del);
            value.Children.RemoveAt(del);
        }
    }
}
