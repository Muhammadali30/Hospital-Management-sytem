using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Classes
{
    public class Database
    {
        SqlConnection con; 
        SqlCommand cmd;
        public Database() {
            con = new SqlConnection("Data Source=DESKTOP-D7PJBST;Initial Catalog=FYP_DB;Integrated Security=True");
        }
        public DataTable Read(string query)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void Add(string query)
        {
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public BigInteger GetInsertedId(string insertionQuery)
        {
            BigInteger lastInsertedId = 0;

            using (SqlCommand cmd = new SqlCommand(insertionQuery + "; SELECT SCOPE_IDENTITY();", con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null && result != DBNull.Value)
                {
                    lastInsertedId = Convert.ToInt64(result);
                }
            }

            return lastInsertedId;
        }
        public DataTable READ(string query, params SqlParameter[] parameters)
        {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
        }
        public void Update(string query)
        {
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
