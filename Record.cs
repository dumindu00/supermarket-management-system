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
            LoadCriticalItems();
            LoadInventoryList();
        }

        public void LoadTopSelling () 
        {
            int i = 0;
            dgvTopSelling.Rows.Clear();
            cn.Open();
            if(cbTopSell.Text == "Sort By Qty")
            {
                //cmd=new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC", cn);

                cmd = new MySqlCommand("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwTopSelling WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC LIMIT 10", cn);
            }
            else if(cbTopSell.Text == "Sort By Total Amount")
            {
                //cmd = new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC", cn);

                cmd = new MySqlCommand("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwTopSelling WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC LIMIT 10", cn);

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

        public void LoadSoldItems()
        {
            try
            {

                dgvSoldItems.Rows.Clear();
                int i = 0;
                cn.Open();
                cmd = new MySqlCommand("SELECT c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total FROM tbCart AS c INNER JOIN tbProduct AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFromSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' GROUP BY c.pcode, p.pdesc, c.price", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvSoldItems.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), double.Parse(dr["price"].ToString()).ToString("#.##0.00"), dr["qty"].ToString(), double.Parse(dr["disc"].ToString()), double.Parse(dr["total"].ToString()).ToString("#.##0.00"));
                }
                dr.Close();
                cn.Close();

                cn.Open();
                cmd = new MySqlCommand("SELECT IFNULL(SUM(total),0) FROM tbCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFromSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'", cn);
                lblTotal.Text = double.Parse(cmd.ExecuteScalar().ToString()).ToString("#.##0.00");
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadCriticalItems()
        {
            try
            {
                dgvCriticalItems.Rows.Clear();
                int i = 0;
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM vwCriticalItems", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    i++;
                    dgvCriticalItems.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void LoadInventoryList()
        {
            try
            {
                dgvInventoryList.Rows.Clear();
                int i = 0;
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM vwInventoryList", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvInventoryList.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadCancelItems()
        {
            try
            {   
                int i = 0;
                dvgCancel.Rows.Clear();
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM vwCancelItems WHERE sdate BETWEEN '" + dtFromCancel.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToCancel.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'", cn);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    i++;
                    dvgCancel.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadStockInHist()
        {
            try
            {
                int i = 0;
                dgvStockIn.Rows.Clear();
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM vwStockIn WHERE CAST(sdate AS date) BETWEEN '" + dtFromStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Done'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvStockIn.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToLongDateString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnLoadSoldItems_Click(object sender, EventArgs e)
        {
            LoadSoldItems();
        }

        private void btnPrintSoldItems_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "From : " + dtFromSoldItems.Value.ToString() + " To : " + dtToSoldItems.Value.ToString();
            report.LoadSoldItems("SELECT c.pcode, p.pdesc, c.price, SUM(c.qty) AS qty, SUM(c.disc) AS disc, SUM(c.total) AS total FROM tbCart AS c INNER JOIN tbProduct AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFromSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToSoldItems.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' GROUP BY c.pcode, p.pdesc, c.price", param);
            report.ShowDialog();
        }

        private void btnLoadCancel_Click(object sender, EventArgs e)
        {
            LoadCancelItems();
        }

        private void btnLoadStockIn_Click(object sender, EventArgs e)
        {
            LoadStockInHist();
        }

        private void btnPrintTPItems_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "From : " + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + " To : " + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (cbTopSell.Text == "Sort By Qty")
            {
                //cmd=new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC", cn);

                report.LoadTopSelling("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwTopSelling WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC LIMIT 10", param, "TOP SELLING ITEMS SORT BY QTY");
            }
            else if (cbTopSell.Text == "Sort By Total Amount")
            {
                //cmd = new MySqlCommand("SELECT LIMIT 10 pcode, pdesc, IFNULL(sum(total)) AS total FROM vwSoldItems WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString() + "' AND '" + dtToTopSell.Value.ToString() + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC", cn);

                report.LoadTopSelling("SELECT pcode, pdesc, SUM(qty) AS qty, SUM(total) AS total FROM vwTopSelling WHERE sdate BETWEEN '" + dtFromTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToTopSell.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC LIMIT 10", param, "TOP SELLING ITEMS SORT BY TOTAL AMOUNT");

            }
            report.ShowDialog();
        }

        private void btnPrintInventoryList_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            report.LoadInventory("SELECT * FROM vwInventoryList");
            report.ShowDialog();
        }

        private void btnPrintCancel_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "From : " + dtFromCancel.Value.ToString("yyyy-MM-dd HH:mm:ss") + " To : " + dtToCancel.Value.ToString("yyyy-MM-dd HH:mm:ss");
            report.LoadCancelledOrder("SELECT * FROM vwCancelItems WHERE sdate BETWEEN '" + dtFromCancel.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToCancel.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'", param);
            report.ShowDialog();
        }

        private void btnPrintStockIn_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "From : " + dtFromStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss") + " To : " + dtToStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss");
            report.LoadStockInHist("SELECT * FROM vwStockIn WHERE CAST(sdate AS date) BETWEEN '" + dtFromStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtToStockIn.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND status LIKE 'Done'", param);
            report.ShowDialog();
        }
    }
}
