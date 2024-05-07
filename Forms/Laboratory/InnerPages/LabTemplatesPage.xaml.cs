using Final_Project.Classes;
using Final_Project.Forms.Pharmacy.InnerPages;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for LabTemplatesPage.xaml
    /// </summary>
    public partial class LabTemplatesPage : Page
    {
        public LabTemplatesPage()
        {
            InitializeComponent();
            LoadTemplates();
        }
        private void LoadTemplates()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT t.name as Name, t.price as Price, t.sample_quantity as Sample_Qty, t.code as Code, d.department_name as Department FROM Lab_Templates AS t LEFT JOIN Lab_Departments AS d ON t.department_id = d.id");

            //Load Style from App.xaml
            ResourceDictionary resourceDict = Application.Current.Resources;
            Style ButtonStyle = resourceDict["button"] as Style;

            //Make Custom Column for actions
            DataGridTemplateColumn expanderColumn = new DataGridTemplateColumn();
            expanderColumn.SetValue(Expander.HeaderProperty, "Actions");
            expanderColumn.Header = "Actions";
            expanderColumn.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);

            FrameworkElementFactory expanderFactory = new FrameworkElementFactory(typeof(Expander));
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));

            // Add buttons to the stack panel inside the expander
            FrameworkElementFactory editButtonFactory = new FrameworkElementFactory(typeof(Button));
            editButtonFactory.SetValue(Button.ContentProperty, "Edit");
            editButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            editButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            {
                DataRowView row = (DataRowView)((Button)sender).DataContext;
                int templateid = (int)row["id"];
                if (NavigationService != null)
                {
                    // Remove the current page from the navigation history
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.RemoveBackEntry();
                    }

                    // Load the new page within the same frame
                    NavigationService.Navigate(new NewLabTestTemplatePage(templateid));
                }
                //MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this form?", "Confirmation", MessageBoxButton.YesNo);
            }));

            FrameworkElementFactory deleteButtonFactory = new FrameworkElementFactory(typeof(Button));
            deleteButtonFactory.SetValue(Button.ContentProperty, "Delete");
            deleteButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            deleteButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            {
                // Get the data associated with the row
                DataRowView row = (DataRowView)((Button)sender).DataContext;
                int templateid = (int)row["id"];
                //MessageBox.Show(medicineID.ToString());
                // Prompt the user for confirmation
                MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete this Record?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    database.Add($"Delete from Medicines where id='{templateid}'");
                    dt = database.Read("SELECT * FROM Medicines"); // Assuming Read method returns a new DataTable
                    templategrid.ItemsSource = dt.DefaultView;
                }
            }));

            stackPanelFactory.AppendChild(editButtonFactory);
            //stackPanelFactory.AppendChild(deleteButtonFactory);
            expanderFactory.AppendChild(stackPanelFactory);

            DataTemplate expanderTemplate = new DataTemplate();
            expanderTemplate.VisualTree = expanderFactory;

            expanderColumn.CellTemplate = expanderTemplate;

            templategrid.Columns.Add(expanderColumn);

            templategrid.ItemsSource = dt.DefaultView;
            templategrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };

    
        }
        private void AddNewTemplatePage(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new NewLabTestTemplatePage());
            }
        }

        private void EditTemplatesPrice(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                // Remove the current page from the navigation history
                if (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

                // Load the new page within the same frame
                NavigationService.Navigate(new EditPricePage());
            }
        }
    }
}
