using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace POSales
{
    internal class DBConnect
    {

        MySqlConnection cn;
        MySqlCommand cmd;


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
    }
}
