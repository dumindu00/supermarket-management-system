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
using System.Xml.Linq;

namespace POSales
{
    public partial class Void : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;

        CancelOrder cancelOrder;


        public Void(CancelOrder cancel)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            txtUsername.Focus();
            cancelOrder = cancel;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                string user;
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM tbUser WHERE username = @username and password = @password", cn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    user = dr["username"].ToString();
                    dr.Close();
                    cn.Close();
                    SaveCancelOrder(user);
                    if(cancelOrder.cboInventory.Text=="yes")
                    {
                        dbcon.ExecuteQuery("UPDATE tbProduct SET qty = qty + " + cancelOrder.udCancelQty.Value + " WHERE pcode= '" + cancelOrder.txtPcode.Text + "'");
                    }
                    dbcon.ExecuteQuery("UPDATE tbCart SET qty = qty + " + cancelOrder.udCancelQty.Value + " WHERE id LIKE '" + cancelOrder.txtId.Text + "'");
                    MessageBox.Show("Order transaction successfully cancelled!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    cancelOrder.ReloadSoldList();
                    cancelOrder.Dispose();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SaveCancelOrder(string user)
        {
            try
            {
                if (txtUsername.Text == cancelOrder.txtCancelBy.Text)
                {
                    MessageBox.Show("Void by name and cancelled by are same!. Please void by another person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                cmd = new MySqlCommand("INSERT INTO tbCancel (transno, pcode, price, qty, total, sdate, voidby, cancelledby, reason, action) VALUES (@transno, @pcode, @price, @qty, @total, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
                cmd.Parameters.AddWithValue("@transno", cancelOrder.txtTransno.Text);
                cmd.Parameters.AddWithValue("@pcode", cancelOrder.txtPcode.Text);
                cmd.Parameters.AddWithValue("@price", double.Parse(cancelOrder.txtPrice.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(cancelOrder.txtQty.Text));
                cmd.Parameters.AddWithValue("@total", double.Parse(cancelOrder.txtTotal.Text));
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@voidby", user);
                cmd.Parameters.AddWithValue("@cancelledby", cancelOrder.txtCancelBy.Text);
                cmd.Parameters.AddWithValue("@reason", cancelOrder.txtReason.Text);
                cmd.Parameters.AddWithValue("@action", cancelOrder.cboInventory.Text);
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
