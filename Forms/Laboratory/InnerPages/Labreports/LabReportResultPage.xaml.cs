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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

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
            //CreateWrapPanel();
            Database db=new Database();
            DataTable dt = db.Read($"select * from Lab_Invoice where id={id}");
            if (dt.Rows.Count > 0)
            {
                patientname.Text = name;
                patientid.Text = dt.Rows[0]["unregistered_patient_id"].ToString();
                DataTable dtt = db.Read($"SELECT template_id From Invoice_Items where id={id}");
                foreach (DataRow row in dtt.Rows)
                {
                    StackPanel sp = CreateTags.create_stackpanel(null);
                    WrapPanel wp = CreateTags.create_wrappanel("Horizontal");
                    TextBlock tb = CreateTags.create_textblock(row["template_id"].ToString());

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
                    StackPanel spheading = CreateTags.create_stackpanel(null, "Vertical");
                    spheading.Children.Add(CreateTags.create_textblock("SubHeading"));

                    wp.Children.Add(spname);
                    wp.Children.Add(spunit);
                    wp.Children.Add(spresult);
                    wp.Children.Add(spmale);
                    wp.Children.Add(spfemale);
                    wp.Children.Add(spheading);

                    sp.Children.Add(tb);
                    sp.Children.Add(wp);

                    TestReportFieldsPanel.Children.Add(sp);

                    DataTable fields_table = db.Read($"select * From Lab_Templates_Fields where template_id=14");
                    foreach (DataRow f_row in fields_table.Rows)
                    {
                    //var field = new { name = f_row["name"].ToString(), unit = f_row["unit"].ToString(), result = 0.ToString(), mrange = f_row["mrange"].ToString(), frange = f_row["frange"].ToString(), subheading = f_row["subheading"].ToString() };
                        spname.Children.Add(CreateTags.create_textbox(f_row["name"].ToString()));
                        spunit.Children.Add(CreateTags.create_textbox(f_row["unit"].ToString()));
                        spresult.Children.Add(CreateTags.create_textbox(""));
                        spmale.Children.Add(CreateTags.create_textbox(f_row["mrange"].ToString()));
                        spfemale.Children.Add(CreateTags.create_textbox(f_row["frange"].ToString()));
                        spheading.Children.Add(CreateTags.create_textbox(f_row["subheading"].ToString()));
                    }
                }
            }
            //DataTable dtt = db.Read($"select ii.template_id from Invoice_Items ii LEFT JOIN Lab_Invoice i ON i.id = ii.invoice_id ");
            //DataTable dtt = db.Read($"SELECT tf.name\r\nFROM Lab_Invoice i\r\nINNER JOIN Invoice_Items ii ON i.id = ii.invoice_id\r\nINNER JOIN Lab_Templates t ON ii.template_id = t.id\r\nINNER JOIN Lab_Templates_Fields tf ON t.id = tf.template_id\r\nWHERE i.id = {id};\r\n");
            //MessageBox.Show(dtt.ToString());
        }
    }
}
