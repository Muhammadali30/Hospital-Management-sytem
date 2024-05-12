using Final_Project.Classes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
    public partial class NewLabTestTemplatePage : Page
    {
        private int department_id;
        private int updateid = 0;

        public NewLabTestTemplatePage(int? id = null)
        {
            InitializeComponent();
            if (id != null)
            {
                updateid = id.Value;
                submitbtn.Content = "Update";
                loadtemplatedata(id);
            }
            else
            {
                Set_Departments_Combox();
            }
        }

        private void loadtemplatedata(int? id)
        {
            Database db = new Database();
            DataTable dt = db.Read($"SELECT * from Lab_Templates where id = '{id}'");
            if (dt.Rows.Count > 0)
            {
                testname.Text = dt.Rows[0]["name"].ToString();
                price.Text = dt.Rows[0]["price"].ToString();
                samplequantity.Text = dt.Rows[0]["sample_quantity"].ToString();
                code.Text = dt.Rows[0]["code"].ToString();
                comments.Text = dt.Rows[0]["comments"].ToString();
            }
            Set_Departments_Combox();
            DataTable fields = db.Read($"select * from Lab_Templates_Fields where template_id = '{id}'");
            foreach (DataRow row in fields.Rows)
            {
                fieldname.Children.Add(CreateTags.create_textbox(row["name"].ToString(), 100, true, "Field Name"));
                fieldunit.Children.Add(CreateTags.create_textbox(row["unit"].ToString(), 80, true, "Unit"));
                fieldnormalrangemale.Children.Add(CreateTags.create_textbox(row["mrange"].ToString(), 120, true, "Range (M)"));
                fieldnormalrangefemale.Children.Add(CreateTags.create_textbox(row["frange"].ToString(), 120, true, "Range (F)"));
                fieldsubheading.Children.Add(CreateTags.create_textbox(row["subheading"].ToString(), 100, true, "SubHeading"));
                Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete", "Red");
                newbutton.Click += new RoutedEventHandler(OnButtonClick);
                delete.Children.Add(newbutton);
            }
        }


        private void Set_Departments_Combox(int? id = null)
        {
            Database database = new Database();
            DataTable dt = database.Read("select * from Lab_Departments");

            combodepartment.ItemsSource = dt.DefaultView;
            combodepartment.DisplayMemberPath = "department_name";

            //if (id != null)
            //{
            //    DataRow[] rows = dt.Select($"id = '{id}'");
            //    if (rows.Length > 0)
            //    {
            //        combodepartment.SelectedItem = rows[0];
            //        combodepartment.UpdateLayout(); // Refresh UI
            //    }
            //}
            //else
            //{
            //    combodepartment.SelectedIndex = 0;
            //}
        }

        private void AddNewFieldButton(object sender, RoutedEventArgs e)
        {
            fieldname.Children.Add(CreateTags.create_textbox(null, 100, true, "Field Name"));
            fieldunit.Children.Add(CreateTags.create_textbox(null, 80, true, "Unit"));
            fieldnormalrangemale.Children.Add(CreateTags.create_textbox(null, 120, true, "Range (M)"));
            fieldnormalrangefemale.Children.Add(CreateTags.create_textbox(null, 120, true, "Range (F)"));
            fieldsubheading.Children.Add(CreateTags.create_textbox(null, 100, true, "SubHeading"));
            Button newbutton = CreateTags.create_button("Delete", null, 30, "Delete", "Red");
            newbutton.Click += new RoutedEventHandler(OnButtonClick);
            delete.Children.Add(newbutton);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                // Remove the forward navigation entry
                if (NavigationService.CanGoForward)
                {
                    NavigationService.RemoveBackEntry();
                }
                // Go back to the previous page
                NavigationService.GoBack();
            }
        }

        private void combodepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = combodepartment.SelectedItem as DataRowView;
            department_id = selectedRow != null ? Convert.ToInt32(selectedRow["id"]) : 0;
        }
        //Add Nested Fields 
        private string add_nested_fields(BigInteger id)
        {
            string data = "INSERT INTO Lab_Templates_Fields (name,unit,mrange,frange,subheading,template_id) VALUES ";
            for (int i = 0; i < fieldname.Children.Count; i++)
            {
                var fn = fieldname.Children[i]as TextBox;
                var fu = fieldunit.Children[i] as TextBox;
                var fm = fieldnormalrangemale.Children[i] as TextBox;
                var ff = fieldnormalrangefemale.Children[i] as TextBox;
                var fs = fieldsubheading.Children[i] as TextBox;
                if (fn != null && fu != null && fm != null && ff != null && fs != null)
                {
                    data += fieldname.Children.Count == i + 1 ? $"('{fn.Text}','{fu.Text}','{fm.Text}','{ff.Text}','{fs.Text}','{id}')"
                    : $"('{fn.Text}','{fu.Text}','{fm.Text}','{ff.Text}','{fs.Text}','{id}'),";
                }
            }
            return data;
        }
            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Submit_Record(updateid);
        }

        private void Submit_Record(int? update_id = null)
        {
            int priceValue, sampleQuantityValue, codeValue;
            Database db = new Database();
            bool priceParsed = int.TryParse(price.Text, out priceValue);
            bool sampleQuantityParsed = int.TryParse(samplequantity.Text, out sampleQuantityValue);
            bool codeParsed = int.TryParse(code.Text, out codeValue);
            MessageBox.Show(update_id.ToString());
            // Check if parsing was successful for all values
            if (priceParsed && sampleQuantityParsed && codeParsed)
            {
                if (submitbtn.Content == "Update")
                {
                    db.Add($"Delete from Lab_Templates_Fields where template_id = '{update_id}'");
                    db.Add($"UPDATE Lab_Templates SET name = '{testname.Text}', price = {priceValue}, sample_quantity = {sampleQuantityValue}, code = {codeValue}, comments = '{comments.Text}',department_id = '{department_id}' WHERE id = '{update_id}'");
                    db.Add(add_nested_fields(updateid));
                    MessageBox.Show("Record Updated Successfully");
                    return;
                }


                // Use the parsed integer values in the SQL query
                BigInteger id = db.GetInsertedId($@"
                    INSERT INTO Lab_Templates (name, price, sample_quantity, code, comments,department_id) 
                    OUTPUT INSERTED.id
                    VALUES ('{testname.Text}', {priceValue}, {sampleQuantityValue}, {codeValue}, '{comments.Text}','{department_id}');
                ");
                db.Add(add_nested_fields(id));

            }
            else
            {
                // Handle parsing errors here
                MessageBox.Show("Invalid input for price, sample quantity, or code.");
            }
        }

    }
}
