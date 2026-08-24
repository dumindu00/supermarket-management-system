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
    public partial class BrandModule : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        Brand brand;




        public BrandModule(Brand br)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            brand = br;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // To inser brand name to brand table

            try
            {
                if (MessageBox.Show("Are you sure you want to save this brand ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new MySqlCommand("INSERT INTO theBrand(brand)VALUES(@brand)", cn);
                    cmd.Parameters.AddWithValue("@brand", textBrand.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved.", "POS");
                    Clear();
                    brand.LoadBrand();
                }
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
        public void Clear() 
        {
            textBrand.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            textBrand.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update brand name
            if (MessageBox.Show("Are you sure you want to update this brand?", "Update Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  
            {
                cn.Open();
                cmd = new MySqlCommand(
                        "UPDATE theBrand SET brand = @brand WHERE id = @id", cn);

                cmd.Parameters.AddWithValue("@brand", textBrand.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblId.Text));
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Brand has been successfully updated.", "POS");
                Clear();
                this.Dispose(); // To close this from after update data
            }
        }
    }
}
