using Final_Project.Classes;
using Final_Project.Forms.Pharmacy.InnerPages;
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

namespace Final_Project.Forms.Admin
{
    /// <summary>
    /// Interaction logic for UsersListPage.xaml
    /// </summary>
    public partial class UsersListPage : Page
    {
        public UsersListPage()
        {
            InitializeComponent();
            Loadusers();
        }

        private void Loadusers()
        {
            Database database = new Database();
            DataTable dt = database.Read("SELECT id,name,email,age,role,status from Users");

            //Load Style from App.xaml
            ResourceDictionary resourceDict = Application.Current.Resources;
            Style ButtonStyle = resourceDict["button"] as Style;

            //Make Custom Column for actions
            DataGridTemplateColumn expanderColumn = new DataGridTemplateColumn();
            expanderColumn.Header = "Actions";
            expanderColumn.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);

            FrameworkElementFactory expanderFactory = new FrameworkElementFactory(typeof(Expander));
            expanderFactory.SetValue(Expander.HeaderProperty, "Actions");
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));

            // Add buttons to the stack panel inside the expander
            FrameworkElementFactory editButtonFactory = new FrameworkElementFactory(typeof(Button));
            editButtonFactory.SetValue(Button.ContentProperty, "Edit");
            editButtonFactory.SetValue(Button.BackgroundProperty, Brushes.Green);

            editButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            editButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            {
                DataRowView row = (DataRowView)((Button)sender).DataContext;
                int userid = (int)row["id"];
                AlertForm AF = new AlertForm(new AddUsersPage(userid));
                AF.ShowDialog();
                //MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this form?", "Confirmation", MessageBoxButton.YesNo);
            }));

            FrameworkElementFactory deleteButtonFactory = new FrameworkElementFactory(typeof(Button));
            deleteButtonFactory.SetValue(Button.ContentProperty, "Show");
            deleteButtonFactory.SetValue(Button.StyleProperty, ButtonStyle);
            deleteButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
            {
                DataRowView row = (DataRowView)((Button)sender).DataContext;
                int medicineID = (int)row["id"];
            }));

            stackPanelFactory.AppendChild(editButtonFactory);
            stackPanelFactory.AppendChild(deleteButtonFactory);
            expanderFactory.AppendChild(stackPanelFactory);

            DataTemplate expanderTemplate = new DataTemplate();
            expanderTemplate.VisualTree = expanderFactory;

            expanderColumn.CellTemplate = expanderTemplate;

            // Add the expander column to the DataGrid
            usersgrid.Columns.Add(expanderColumn);

            // Set the ItemsSource of the DataGrid
            usersgrid.ItemsSource = dt.DefaultView;

            // Set column width for other columns
            usersgrid.AutoGeneratingColumn += (sender, e) =>
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AlertForm AF = new AlertForm(new AddUsersPage());
            AF.ShowDialog();
        }
    }
}
