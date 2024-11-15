﻿using Final_Project.Classes;
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
        private int invoice_id;
        private Database db = new Database();
        public LabReportResultPage(int id,string name)
        {
            InitializeComponent();
            //CreateWrapPanel();
            invoice_id=id;
            Database db=new Database();
            DataTable dt = db.Read($"select * from Lab_Invoice where id={id}");
            if (dt.Rows.Count > 0)
            {
                patientname.Text = name;
                patientid.Text = dt.Rows[0]["unregistered_patient_id"].ToString();
                DataTable dtt = db.Read($"SELECT ii.template_id, lt.name as template_name FROM Invoice_Items ii LEFT JOIN Lab_Templates lt ON ii.template_id = lt.id WHERE ii.invoice_id = {id}");
                //MessageBox.Show(dtt.Rows.Count.ToString());
                foreach (DataRow row in dtt.Rows)
                {
          
                    StackPanel sp = CreateTags.create_stackpanel(null);
                    WrapPanel wp = CreateTags.create_wrappanel("Horizontal");
                    TextBlock tb = CreateTags.create_textblock("Template Name: "+row["template_name"].ToString(),20);
                    StackPanel spid = CreateTags.create_stackpanel(null, "Vertical");
                    spid.Children.Add(CreateTags.create_textblock("Name"));
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
                    
                    wp.Children.Add(spid);
                    wp.Children.Add(spname);
                    wp.Children.Add(spunit);
                    wp.Children.Add(spresult);
                    wp.Children.Add(spmale);
                    wp.Children.Add(spfemale);
                    wp.Children.Add(spheading);

                    sp.Children.Add(tb);
                    sp.Children.Add(wp);

                    TestReportFieldsPanel.Children.Add(sp);

                    DataTable fields_table = db.Read($"select * From Lab_Templates_Fields where template_id={row["template_id"]}");
                    foreach (DataRow f_row in fields_table.Rows)
                    {
                    //var field = new { name = f_row["name"].ToString(), unit = f_row["unit"].ToString(), result = 0.ToString(), mrange = f_row["mrange"].ToString(), frange = f_row["frange"].ToString(), subheading = f_row["subheading"].ToString() };
                        spid.Children.Add(CreateTags.create_textbox(f_row["id"].ToString(), 100,false));
                        spname.Children.Add(CreateTags.create_textbox(f_row["name"].ToString(), 100,false));
                        spunit.Children.Add(CreateTags.create_textbox(f_row["unit"].ToString(), 100, false));
                        spresult.Children.Add(CreateTags.create_textbox("", 100));
                        spmale.Children.Add(CreateTags.create_textbox(f_row["mrange"].ToString(), 100, false));
                        spfemale.Children.Add(CreateTags.create_textbox(f_row["frange"].ToString(), 100, false));
                        spheading.Children.Add(CreateTags.create_textbox(f_row["subheading"].ToString(), 100, false));
                    }
                }
            }
            //DataTable dtt = db.Read($"select ii.template_id from Invoice_Items ii LEFT JOIN Lab_Invoice i ON i.id = ii.invoice_id ");
            //DataTable dtt = db.Read($"SELECT tf.name\r\nFROM Lab_Invoice i\r\nINNER JOIN Invoice_Items ii ON i.id = ii.invoice_id\r\nINNER JOIN Lab_Templates t ON ii.template_id = t.id\r\nINNER JOIN Lab_Templates_Fields tf ON t.id = tf.template_id\r\nWHERE i.id = {id};\r\n");
            //MessageBox.Show(dtt.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string data = "INSERT INTO Lab_Result(field_id,invoice_id,result) VALUES ";
            foreach (var child in TestReportFieldsPanel.Children)
            {
                if (child is StackPanel sp)
                {

                    if (sp.Children.Count > 1 && sp.Children[1] is WrapPanel secondChild)
                    {
                        StackPanel first_Son = secondChild.Children[0] as StackPanel;
                        StackPanel third_Son = secondChild.Children[3] as StackPanel;
                        for (int i=0; i<first_Son.Children.Count;i++)
                        {
                            if (first_Son.Children[i] is TextBox id && third_Son.Children[i] is TextBox result)
                            {
                                data += first_Son.Children.Count == i + 1 && TestReportFieldsPanel.Children.Count - 1 == TestReportFieldsPanel.Children.IndexOf(sp)? 
                                    $"('{Convert.ToInt64(id.Text)}','{invoice_id}','{result.Text}')"
                                  : $"('{Convert.ToInt64(id.Text)}','{invoice_id}','{result.Text}'),";
                            }
                        }
                    }
                }
            }
            MessageBox.Show(data);
            db.Add(data);
            db.Update($"UPDATE Lab_Invoice SET status = 'Test Validation' WHERE id = {invoice_id}");
        }
    }
}
