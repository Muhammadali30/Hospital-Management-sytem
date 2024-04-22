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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for RequestMultipleItemsPage.xaml
    /// </summary>
    public partial class RequestMultipleItemsPage : Page
    {
        public RequestMultipleItemsPage()
        {
            InitializeComponent();
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
            TextBox textgenericname = new TextBox
            {
                Width = 130,
                Margin = new Thickness(5),
                Tag = "Generic Name",
                Style = textBoxStyle
            };
            genericname.Children.Add(textgenericname);

            // For fieldnormalrangemale
            TextBox textrack = new TextBox
            {
                Width = 70,
                Margin = new Thickness(5),
                Tag = "Rack#",
                Style = textBoxStyle
            };
            rack.Children.Add(textrack  );

            // For fieldnormalrangefemale
            TextBox textbarcode = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "Barcode",
                Style = textBoxStyle
            };
            barcode.Children.Add(textbarcode);

            // For fieldsubheading
            TextBox textmanufacturer = new TextBox
            {
                Width = 100,
                Margin = new Thickness(5),
                Tag = "Manufacturer",
                Style = textBoxStyle
            };
            manufacturer.Children.Add(textmanufacturer);

            TextBox textsupplier = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Supplier",
                Style = textBoxStyle
            };
            suppliers.Children.Add(textsupplier);

            TextBox textcategory = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Category",
                Style = textBoxStyle
            };
            category.Children.Add(textcategory);

            TextBox textunit = new TextBox
            {
                Width = 120,
                Margin = new Thickness(5),
                Tag = "E.G,Strips,Boxes",
                Style = textBoxStyle
            };
            unit.Children.Add(textunit);

            TextBox textconversionunit = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Conversion Unit",
                Style = textBoxStyle
            };
            conversionunit.Children.Add(textconversionunit);

            TextBox textnoofstrips = new TextBox
            {
                Width = 60,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            noofstrips.Children.Add(textnoofstrips);

            TextBox textreorderinglevel = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Level",
                Style = textBoxStyle
            };
            reordering.Children.Add(textreorderinglevel);

            //TextBox textretail = new TextBox
            //{
            //    Width = 70,
            //    Margin = new Thickness(5),
            //    Tag = "0",
            //    Style = textBoxStyle
            //};
            //retailprice.Children.Add(textretail);

            //TextBox textopeningstock = new TextBox
            //{
            //    Width = 70,
            //    Margin = new Thickness(5),
            //    Tag = "Stock",
            //    Style = textBoxStyle
            //};
            //openingstock.Children.Add(textopeningstock);

            //TextBox textcostprice = new TextBox
            //{
            //    Width = 80,
            //    Margin = new Thickness(5),
            //    Tag = "0",
            //    Style = textBoxStyle
            //};
            //unitcostprice.Children.Add(textcostprice);

            TextBox textnarcotic = new TextBox
            {
                Width = 20,
                Margin = new Thickness(5),
                Tag = "",
                Style = textBoxStyle
            };
            narcotic.Children.Add(textnarcotic);

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
            genericname.Children.RemoveAt(del);
            rack.Children.RemoveAt(del);
            barcode.Children.RemoveAt(del);
            manufacturer.Children.RemoveAt(del);
            suppliers.Children.RemoveAt(del);
            category.Children.RemoveAt(del);
            unit.Children.RemoveAt(del);
            conversionunit.Children.RemoveAt(del);
            noofstrips.Children.RemoveAt(del);
            reordering.Children.RemoveAt(del);
            //retailprice.Children.RemoveAt(del);
            //openingstock.Children.RemoveAt(del);
            //unitcostprice.Children.RemoveAt(del);
            narcotic.Children.RemoveAt(del);
        }
    }
}
