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
    /// Interaction logic for AddStockPage.xaml
    /// </summary>
    public partial class AddStockPage : Page
    {
        public AddStockPage()
        {
            InitializeComponent();
        }

        private void ItemButton(object sender, RoutedEventArgs e)
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

            // For fieldunit
            TextBox textavailqty = new TextBox
                {
                    Width = 130,
                    Margin = new Thickness(5),
                    Tag = "Generic Name",
                    Style = textBoxStyle
                };
                availqty.Children.Add(textavailqty);

                // For fieldnormalrangemale
                TextBox textqty = new TextBox
                {
                    Width = 70,
                    Margin = new Thickness(5),
                    Tag = "Rack#",
                    Style = textBoxStyle
                };
                qty.Children.Add(textqty);

            TextBox textunitcost = new TextBox
            {
                Width = 80,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            unitcost.Children.Add(textunitcost);

            // For fieldnormalrangefemale
            TextBox textdesprice = new TextBox
                {
                    Width = 120,
                    Margin = new Thickness(5),
                    Tag = "Barcode",
                    Style = textBoxStyle
                };
                disprice.Children.Add(textdesprice);

                // For fieldsubheading
                TextBox texttotalcost = new TextBox
                {
                    Width = 100,
                    Margin = new Thickness(5),
                    Tag = "Manufacturer",
                    Style = textBoxStyle
                };
                totalcost.Children.Add(texttotalcost);

            TextBox textretail = new TextBox
            {
                Width = 70,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            retailprice.Children.Add(textretail);

            TextBox textnetretail = new TextBox
            {
                Width = 70,
                Margin = new Thickness(5),
                Tag = "0",
                Style = textBoxStyle
            };
            netretailprice.Children.Add(textnetretail);

            TextBox textprofirmargin = new TextBox
                {
                    Width = 140,
                    Margin = new Thickness(5),
                    Tag = "Supplier",
                    Style = textBoxStyle
                };
                profitmargin.Children.Add(textprofirmargin);

                TextBox textexpiry = new TextBox
                {
                    Width = 140,
                    Margin = new Thickness(5),
                    Tag = "Category",
                    Style = textBoxStyle
                };
                expiry.Children.Add(textexpiry);

               

                TextBox textdiscount = new TextBox
                {
                    Width = 60,
                    Margin = new Thickness(5),
                    Tag = "0",
                    Style = textBoxStyle
                };
                discount.Children.Add(textdiscount);

                TextBox textlumpsup = new TextBox
                {
                    Width = 140,
                    Margin = new Thickness(5),
                    Tag = "Level",
                    Style = textBoxStyle
                };
                lumpsum.Children.Add(textlumpsup);

               

                TextBox textsalestax = new TextBox
                {
                    Width = 70,
                    Margin = new Thickness(5),
                    Tag = "Stock",
                    Style = textBoxStyle
                };
                salestax.Children.Add(textsalestax);

                

                TextBox textnetvalue = new TextBox
                {
                    Width = 20,
                    Margin = new Thickness(5),
                    Tag = "",
                    Style = textBoxStyle
                };
                netvalue.Children.Add(textnetvalue);

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
                unit.Children.RemoveAt(del);
                conversionunit.Children.RemoveAt(del);
                availqty.Children.RemoveAt(del);
                qty.Children.RemoveAt(del);
                unitcost.Children.RemoveAt(del);
                disprice.Children.RemoveAt(del);
                totalcost.Children.RemoveAt(del);
                retailprice.Children.RemoveAt(del);
                netretailprice.Children.RemoveAt(del);
                profitmargin.Children.RemoveAt(del);
                discount.Children.RemoveAt(del);
                lumpsum.Children.RemoveAt(del);
                salestax.Children.RemoveAt(del);
                netvalue.Children.RemoveAt(del);
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
