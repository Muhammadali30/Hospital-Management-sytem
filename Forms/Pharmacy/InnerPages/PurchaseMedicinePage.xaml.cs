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

namespace Final_Project.Forms.Pharmacy.InnerPages
{
    /// <summary>
    /// Interaction logic for PurchaseMedicinePage.xaml
    /// </summary>
    public partial class PurchaseMedicinePage : Page
    {
        public PurchaseMedicinePage()
        {
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT * from Med_Purchase");
            //Load Style from App.xaml
            //ResourceDictionary resourceDict = Application.Current.Resources;
            //Style ButtonStyle = resourceDict["button"] as Style;

            ////Make Custom Column for actions
            //DataGridTemplateColumn expanderColumn = new DataGridTemplateColumn();
            //expanderColumn.Header = "Actions";
            //expanderColumn.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);

            //FrameworkElementFactory expanderFactory = new FrameworkElementFactory(typeof(Expander));
            //FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));

            //// Add buttons to the stack panel inside the expander
            //FrameworkElementFactory editButtonFactory = new FrameworkElementFactory(typeof(Button));
            //editButtonFactory.SetValue(Button.ContentProperty, "Edit");
            //editButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            //editButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            //{
            //    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this form?", "Confirmation", MessageBoxButton.YesNo);
            //}));

            //FrameworkElementFactory deleteButtonFactory = new FrameworkElementFactory(typeof(Button));
            //deleteButtonFactory.SetValue(Button.ContentProperty, "Delete");
            //deleteButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            //deleteButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            //{
            //    // Get the data associated with the row
            //    DataRowView row = (DataRowView)((Button)sender).DataContext;
            //    int medicineID = (int)row["id"];
            //    //MessageBox.Show(medicineID.ToString());
            //    // Prompt the user for confirmation
            //    MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete this Record?", "Confirmation", MessageBoxButton.YesNo);
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        database.Add($"Delete from Med_Purchase where id='{medicineID}'");
            //        dt = database.Read("SELECT * FROM Medicines"); // Assuming Read method returns a new DataTable
            //        purchasedmedgrid.ItemsSource = dt.DefaultView;
            //    }
            //}));

            //stackPanelFactory.AppendChild(editButtonFactory);
            //stackPanelFactory.AppendChild(deleteButtonFactory);
            //expanderFactory.AppendChild(stackPanelFactory);

            //DataTemplate expanderTemplate = new DataTemplate();
            //expanderTemplate.VisualTree = expanderFactory;

            //expanderColumn.CellTemplate = expanderTemplate;

            //// Add the expander column to the DataGrid
            //purchasedmedgrid.Columns.Add(expanderColumn);

            // Set the ItemsSource of the DataGrid
            purchasedmedgrid.ItemsSource = dt.DefaultView;

            // Set column width for other columns
            purchasedmedgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }
        

        private void purchase_button(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new PurchasePage());
            AF.ShowDialog();
        }
    }
}
