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
    public partial class UserProperties : Form
    {


        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();

        UserAccount account;
        public string username;


        public UserProperties(UserAccount user)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            account = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            try
            {
                if((MessageBox.Show("Are you sure you want to change this account properties?", "Change Properties", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes))
                {
                    cn.Open();
                    cmd = new MySqlCommand("UPDATE tbUser SET name=@name, role=@role, isActivate=@isActivate WHERE username='" + username + "'", cn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@role", cbRole.Text);
                    cmd.Parameters.AddWithValue("@isActivate", cbActivate.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Account properties has been sucessfully changed!", "Update Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account.LoadUser();
                    this.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
