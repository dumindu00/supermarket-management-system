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
    public partial class DailySale : Form
    {


        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;
        public string solduser;

        MainForm main;


        public DailySale(MainForm mn)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            main = mn;
            LoadCashier();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM tbUser WHERE role LIKE 'Cashier'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadSold()
        {


            //MessageBox.Show("date " + dtFrom + "time" + dtTo);

            //string dateFrom = dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //string dateTo = dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

            //MessageBox.Show(
            //    "dateFrom = " + dateFrom +
            //    "\n\n" +
            //    "dateTo = " + dateTo
            //);









            int i = 0;
            double total = 0;
            dgvSold.Rows.Clear();
            cn.Open();
            if (cboCashier.Text == "All Cashier")
            {
                cmd = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tbCart as c INNER JOIN tbProduct AS p ON c.pcode = p.pcode  WHERE STATUS LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'", cn);
            }
            else
            {
                cmd = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tbCart as c INNER JOIN tbProduct AS p ON c.pcode = p.pcode WHERE STATUS LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND cashier LIKE '" + cboCashier.Text + "'", cn);
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                total += double.Parse(dr["total"].ToString());
                dgvSold.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = total.ToString("#, ##0.00");
        }

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DailySale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Dispose();
            }
        }

        private void dgvSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSold.Columns[e.ColumnIndex].Name;
            if(colName=="Cancle")
            {
                CancelOrder cancelOrder = new CancelOrder(this);
                cancelOrder.txtId.Text = dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancelOrder.txtTransno.Text = dgvSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancelOrder.txtPcode.Text = dgvSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancelOrder.txtDesc.Text = dgvSold.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancelOrder.txtPrice.Text = dgvSold.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancelOrder.txtQty.Text = dgvSold.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancelOrder.txtDisc.Text = dgvSold.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancelOrder.txtTotal.Text = dgvSold.Rows[e.RowIndex].Cells[8].Value.ToString();
                cancelOrder.txtCancelBy.Text = solduser;
                cancelOrder.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "Date From: " + dtFrom.Value.ToShortDateString() + " To: " + dtTo.Value.ToShortDateString();
            if (cboCashier.Text == "All Cashier")
            {
                report.LoadDailyReport("SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc AS discount, c.total FROM tbCart as c INNER JOIN tbProduct AS p ON c.pcode = p.pcode  WHERE STATUS LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'", param, cboCashier.Text);
            }
            else
            {
                report.LoadDailyReport("SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc AS discount, c.total FROM tbCart as c INNER JOIN tbProduct AS p ON c.pcode = p.pcode WHERE STATUS LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND cashier LIKE '" + cboCashier.Text + "'", param, cboCashier.Text);
            }

            report.ShowDialog();
        }




        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    POSReport report = new POSReport();

        //    string param = "Date From: " +
        //        dtFrom.Value.ToShortDateString() +
        //        " To: " +
        //        dtTo.Value.ToShortDateString();

        //    string dateFrom = dtFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
        //    string dateTo = dtTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

        //    if (cboCashier.Text == "All Cashier")
        //    {
        //        report.LoadDailyReport(
        //            "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, " +
        //            "c.disc AS discount, c.total " +
        //            "FROM tbCart AS c " +
        //            "INNER JOIN tbProduct AS p ON c.pcode = p.pcode " +
        //            "WHERE STATUS LIKE 'Sold' " +
        //            "AND sdate BETWEEN '" + dateFrom + "' AND '" + dateTo + "'",
        //            param,
        //            cboCashier.Text
        //        );
        //    }
        //    else
        //    {
        //        report.LoadDailyReport(
        //            "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, " +
        //            "c.disc AS discount, c.total " +
        //            "FROM tbCart AS c " +
        //            "INNER JOIN tbProduct AS p ON c.pcode = p.pcode " +
        //            "WHERE STATUS LIKE 'Sold' " +
        //            "AND sdate BETWEEN '" + dateFrom + "' AND '" + dateTo + "' " +
        //            "AND cashier LIKE '" + cboCashier.Text + "'",
        //            param,
        //            cboCashier.Text
        //        );
        //    }

        //    report.ShowDialog();
        //}

        private void dgvSold_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSold.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                CancelOrder cancel = new CancelOrder(this);
                cancel.txtId.Text = dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancel.txtTransno.Text = dgvSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancel.txtPcode.Text = dgvSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancel.txtDesc.Text = dgvSold.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancel.txtPrice.Text = dgvSold.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancel.txtQty.Text = dgvSold.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancel.txtDisc.Text = dgvSold.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancel.txtTotal.Text = dgvSold.Rows[e.RowIndex].Cells[8].Value.ToString();
                
                if (lblTitle.Visible==false)
                    cancel.txtCancelBy.Text = main.lblUsername.Text;
                else
                            cancel.txtCancelBy.Text = solduser;
                cancel.ShowDialog();


            }
        }
    }
}
