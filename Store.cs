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
    public partial class Store : Form
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;

        bool havestoreinfo = false;

        public Store()
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            LoadStore();
        }

        public void LoadStore()
        {
            try
            {
                cn.Open();
                cmd = new MySqlCommand("SELECT * FROM tbStore", cn);
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows) 
                {
                    havestoreinfo = true;
                    txtStName.Text = dr["store"].ToString();
                    txtStName.Text = dr["address"].ToString();
                }
                else
                {
                    txtStName.Clear();
                    txtAddress.Clear();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Save store details ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(havestoreinfo)
                    {
                        dbcon.ExecuteQuery("UPDATE tbStore SET store= '" + txtStName.Text + "', address= " + txtAddress.Text + "'");
                    }
                    else
                    {
                        dbcon.ExecuteQuery("INSERT INTO tbStore (store, address) VALUE ('" + txtStName.Text + "','" + txtStName.Text + "')");
                    }
                    MessageBox.Show("Store has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Dispose();
            }
        }
    }
}
