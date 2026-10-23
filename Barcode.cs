using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace POSales
{
    public partial class Barcode : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;
        string fname;


        public Barcode()
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            LoadProduct();
        }


        public void LoadProduct()
        {
            int i = 0;
            dgvBarcode.Rows.Clear();
            cmd = new MySqlCommand("SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.reorder FROM tbProduct AS p INNER JOIN theBrand AS b ON b.id = p.bid INNER JOIN tbCategory AS c on c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvBarcode.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvBarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBarcode.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = barcode.Draw(dgvBarcode.Rows[e.RowIndex].Cells[2].Value.ToString(), 60, 2);
                fname = dgvBarcode.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save Barcode Image As";
            savefile.FileName = fname;
            savefile.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            ImageFormat image = ImageFormat.Png;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string ftype = System.IO.Path.GetExtension(savefile.FileName);
                switch(ftype)
                {
                    case ".jpg":
                        image = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        image = ImageFormat.Png;
                        break;
                }
                picBarcode.Image.Save(savefile.FileName, image);
            }
            picBarcode.Image = null;
        }
    }
}
