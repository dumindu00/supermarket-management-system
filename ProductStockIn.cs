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
    public partial class ProductStockIn : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();

        string stitle = "Point of Sale";
        MySqlDataReader dr;
        StockIn stockIn;



        public ProductStockIn(StockIn stk)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            stockIn = stk;
            LoadProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cmd = new MySqlCommand("SELECT pcode, pdesc, qty FROM tbProduct  WHERE pdesc LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {

                if (stockIn.txtStockInBy.Text == string.Empty)
                {
                    MessageBox.Show("Please enter stock in by name", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stockIn.txtStockInBy.Focus();
                    this.Dispose();

                }



                if (MessageBox.Show("Add this item ?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cn.Open();
                        cmd = new MySqlCommand("INSERT INTO tbStockIn (refno, pcode, sdate, stockinby, supplierId)VALUES (@refno, @pcode, @sdate, @stockinby, @supplierId)", cn);
                        cmd.Parameters.AddWithValue("@refno", stockIn.txtRefNo.Text);
                        cmd.Parameters.AddWithValue("@pcode", dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@sdate", stockIn.dtStockIn.Value);
                        cmd.Parameters.AddWithValue("@stockinby", stockIn.txtStockInBy.Text);
                        cmd.Parameters.AddWithValue("@supplierId", stockIn.lblId.Text);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        stockIn.LoadStockIn();
                        MessageBox.Show("Successfully added", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, stitle);
                    }
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
