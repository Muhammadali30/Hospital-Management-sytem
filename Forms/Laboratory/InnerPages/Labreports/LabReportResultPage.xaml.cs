using Final_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Final_Project.Forms.Laboratory.InnerPages.Labreports
{
    /// <summary>
    /// Interaction logic for LabReportResultPage.xaml
    /// </summary>
    public partial class LabReportResultPage : Page
    {
        public LabReportResultPage(int id,string name)
        {
            InitializeComponent();
            CreateWrapPanel();
            Database db=new Database();
            DataTable dt = db.Read($"select * from Lab_Invoice where id={id}");
            if (dt.Rows.Count > 0)
            {
                // Get the patient ID from the first row (index 0)
                patientname.Text = name;
                patientid.Text = dt.Rows[0]["unregistered_patient_id"].ToString();

                // Now you have the patient ID in the variable patientId
            }
        }
        private void CreateWrapPanel()
        {
            // Create WrapPanel
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;
            Grid.SetRow(wrapPanel, 4); // Assuming you want to add it to Grid Row 4

            // Add WrapPanel to the parent Grid (assuming it's a Grid)
            parentGrid.Children.Add(wrapPanel);
            // Create and add StackPanels dynamically
            CreateStackPanel(wrapPanel, "Test", 130);
            CreateStackPanel(wrapPanel, "Unit", 100);
            CreateStackPanel(wrapPanel, "Result", 100);
            CreateStackPanel(wrapPanel, "Normal Range (Male)", 150);
            CreateStackPanel(wrapPanel, "Normal Range (Female)", 150);
            CreateStackPanel(wrapPanel, "SubHeading", 110);
        }

        private void CreateStackPanel(WrapPanel wrapPanel, string text, double width)
        {
            // Create StackPanel
            StackPanel stackPanel = new StackPanel();
            stackPanel.Width = width;

            // Create TextBlock
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Margin = new Thickness(5);
            textBlock.FontWeight = FontWeights.Bold;

            // Add TextBlock to StackPanel
            stackPanel.Children.Add(textBlock);

            // Add StackPanel to WrapPanel
            wrapPanel.Children.Add(stackPanel);
        }
    }
}
