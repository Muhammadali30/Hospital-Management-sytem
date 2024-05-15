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
    /// Interaction logic for ReportResultPdfPage.xaml
    /// </summary>
    public partial class ReportResultPdfPage : Page
    {
        public ReportResultPdfPage(int id, string name)
        {
            InitializeComponent();
            invoice.Text = "Invoice No: " + id;
            customer.Text = "Customer Name: " + name;
            Database db = new Database();
            DataTable dt = db.Read($"select * from Lab_Invoice where id={id}");
            if (dt.Rows.Count > 0)
            {
                
                DataTable dtt = db.Read($"SELECT ii.template_id, lt.name as template_name FROM Invoice_Items ii LEFT JOIN Lab_Templates lt ON ii.template_id = lt.id WHERE ii.invoice_id = {id}");
                //MessageBox.Show(dtt.Rows.Count.ToString());
                foreach (DataRow row in dtt.Rows)
                {
                    StackPanel sp = CreateTags.create_stackpanel(null);
                    WrapPanel wp = CreateTags.create_wrappanel("Horizontal");
                    TextBlock tb = CreateTags.create_textblock("Template Name: " + row["template_name"].ToString(), 20);
                    StackPanel spname = CreateTags.create_stackpanel(null, "Vertical");
                    spname.Children.Add(CreateTags.create_textblock("Name"));
                    StackPanel spunit = CreateTags.create_stackpanel(null, "Vertical");
                    spunit.Children.Add(CreateTags.create_textblock("Unit"));
                    StackPanel spresult = CreateTags.create_stackpanel(null, "Vertical");
                    spresult.Children.Add(CreateTags.create_textblock("Result"));
                    StackPanel spmale = CreateTags.create_stackpanel(null, "Vertical");
                    spmale.Children.Add(CreateTags.create_textblock("Range(Male)"));
                    StackPanel spfemale = CreateTags.create_stackpanel(null, "Vertical");
                    spfemale.Children.Add(CreateTags.create_textblock("Range(Female)"));

                    wp.Children.Add(spname);
                    wp.Children.Add(spunit);
                    wp.Children.Add(spresult);
                    wp.Children.Add(spmale);
                    wp.Children.Add(spfemale);

                    sp.Children.Add(tb);
                    sp.Children.Add(wp);

                    TestvalidationFieldsPanel.Children.Add(sp);

                    DataTable fields_table = db.Read($"select f.*, r.result From Lab_Result as r INNER JOIN Lab_Templates_Fields as f ON r.field_id = f.id where template_id={row["template_id"]}");
                    foreach (DataRow f_row in fields_table.Rows)
                    {
                        //var field = new { name = f_row["name"].ToString(), unit = f_row["unit"].ToString(), result = 0.ToString(), mrange = f_row["mrange"].ToString(), frange = f_row["frange"].ToString(), subheading = f_row["subheading"].ToString() };
                        spname.Children.Add(CreateTags.create_textbox(f_row["name"].ToString(), 100, false));
                        spunit.Children.Add(CreateTags.create_textbox(f_row["unit"].ToString(), 100, false));
                        spresult.Children.Add(CreateTags.create_textbox(f_row["result"].ToString(), 100, false));
                        spmale.Children.Add(CreateTags.create_textbox(f_row["mrange"].ToString(), 100, false));
                        spfemale.Children.Add(CreateTags.create_textbox(f_row["frange"].ToString(), 100, false));
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(LabInvoicePdf, "Invoice");
            }
        }
    }
}
