using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    public partial class Record : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;


        public Record()
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
        }

        public void LoadTopSelling () 
        {
            int i = 0;
            dgvTopSelling.Rows.Clear();
            cn.Open();
            if(cbTopSell.Text == "Sort By Qty")
            {
                //cmd=new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC", cn);

                cmd = new MySqlCommand("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC LIMIT 10", cn);
            }
            else if(cbTopSell.Text == "Sort By Total Amount")
            {
                //cmd = new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC", cn);

                cmd = new MySqlCommand("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC LIMIT 10", cn);

            }
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvTopSelling.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), double.Parse(dr["total"].ToString()).ToString("#.##0.00"));
            }
            dr.Close();
            cn.Close();
        }

        private void btnLoadTopSell_Click(object sender, EventArgs e)
        {
            if(cbTopSell.Text=="Select sort type")
            {
                MessageBox.Show("Please select sort type from the dropdown list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTopSell.Focus();
                return;
            }
            
            LoadTopSelling();
        }
    }
}
