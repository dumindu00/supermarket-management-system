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
    public partial class Discount : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();

        string stitle = "Point Of Sale";
        Cashier cashier;


        public Discount(Cashier cash)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            cashier = cash;
            txtDiscount.Focus();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) 
            {
                this.Dispose();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double disc = double.Parse(txtTotalPrice.Text) * double.Parse(txtDiscount.Text) * 0.01;
                txtDiscAmount.Text = disc.ToString("#,##0.00");
            }
            catch (Exception )
            {
                txtDiscAmount.Text = "0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add discount ? Click yet to confirm", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new MySqlCommand("UPDATE tbCart SET disc_percent=@disc_percent WHERE id = @id", cn);
                    cmd.Parameters.AddWithValue("@disc_percent", double.Parse(txtDiscount.Text));
                    cmd.Parameters.AddWithValue("@id", int.Parse(lbId.Text));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    cashier.LoadCart();
                    this.Dispose(); 
                }
                            
            }
            catch (Exception ex) 
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle);
            }
        }
    }
}
