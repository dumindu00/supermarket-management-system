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
    public partial class CategoryModule : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();

        Category category;




        public CategoryModule(Category ct)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            category = ct;
        }

        public void Clear()
        {
            textCategory.Clear();
            textCategory.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // To inser brand name to brand table

            try
            {
                if (MessageBox.Show("Are you sure you want to save this Category ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new MySqlCommand("INSERT INTO tbCategory(category)VALUES(@category)", cn);
                    cmd.Parameters.AddWithValue("@category", textCategory.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Category has been successfully saved.", "Point Of Sales");
                    Clear();
                }
                category.LoadCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update brand name
            if (MessageBox.Show("Are you sure you want to update this category?", "Update Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd = new MySqlCommand(
                        "UPDATE tbCategory SET category = @category WHERE id = @id", cn);

                cmd.Parameters.AddWithValue("@category", textCategory.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblId.Text));
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Category has been successfully updated.", "POS");
                Clear();
                this.Dispose(); // To close this from after update data
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
