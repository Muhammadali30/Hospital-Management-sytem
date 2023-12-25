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
    /// Interaction logic for NewLabTestTemplatePage.xaml
    /// </summary>
    public partial class NewLabTestTemplatePage : Page
    {
        public NewLabTestTemplatePage()
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
                Tag = "Field Name",
                Style = textBoxStyle
            };
            fieldname.Children.Add(textBoxFieldName);

            // For fieldunit
            TextBox textBoxUnit = new TextBox
            {
                Width = 90,
                Margin = new Thickness(5),
                Tag = "Unit",
                Style = textBoxStyle
            };
            fieldunit.Children.Add(textBoxUnit);

            // For fieldnormalrangemale
            TextBox textBoxNormalRangeMale = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Range",
                Style = textBoxStyle
            };
            fieldnormalrangemale.Children.Add(textBoxNormalRangeMale);

            // For fieldnormalrangefemale
            TextBox textBoxNormalRangeFemale = new TextBox
            {
                Width = 140,
                Margin = new Thickness(5),
                Tag = "Range",
                Style = textBoxStyle
            };
            fieldnormalrangefemale.Children.Add(textBoxNormalRangeFemale);

            // For fieldsubheading
            TextBox textBoxSubHeading = new TextBox
            {
                Width = 100,
                Margin = new Thickness(5),
                Tag = "SubHeading",
                Style = textBoxStyle
            };
            fieldsubheading.Children.Add(textBoxSubHeading);

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
            fieldsubheading.Children.RemoveAt(del);
            delete.Children.RemoveAt(del);
            fieldname.Children.RemoveAt(del);
            fieldunit.Children.RemoveAt(del);
            fieldnormalrangefemale.Children.RemoveAt(del);
            fieldnormalrangemale.Children.RemoveAt(del);
        }
    }
}
