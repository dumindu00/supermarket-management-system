using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POSales
{
    internal class DBConnect
    {
        private string connectionString = "server=localhost;database=DBPOSale;user=root;password=foodcity123;";
    
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
