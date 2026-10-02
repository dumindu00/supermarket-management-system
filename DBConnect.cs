using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace POSales
{
    internal class DBConnect
    {

        MySqlConnection cn;
        MySqlCommand cmd;

        MySqlDataReader dr;


        private string connectionString = "server=localhost;database=DBPOSale;user=root;password=foodcity123;";
    
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable getTable(string query)
        {
            DataTable table = new DataTable();

            using (MySqlConnection cn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, cn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public void ExecuteQuery(String sql)
        {
            try
            {
                cn = GetConnection();
                cn.Open();
                cmd = new MySqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string getPassword(string username)
        {
            string password = "";
            cn = GetConnection();
            cn.Open();
            cmd = new MySqlCommand("SELECT password FROM tbUser WHERE username = '" + username + "'", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows) 
            {
                password = dr["password"].ToString();
            }
            dr.Close();
            cn.Close();
            return password;

        }
    }
}
