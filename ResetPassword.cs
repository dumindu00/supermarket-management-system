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
    public partial class ResetPassword : Form
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;
        UserAccount user;

        public ResetPassword(UserAccount account)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            user = account;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtNPass.Text != txtResPass.Text)
            {
                MessageBox.Show("The password you typed do not match. Type the password for this account in both txt boxes.", "Add User Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Reset password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbcon.ExecuteQuery("UPDATE tbUser SET password = '" + txtNPass.Text + "'WHERE = '" + user.username + "'");
                    MessageBox.Show("Password has been successfully reset", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
