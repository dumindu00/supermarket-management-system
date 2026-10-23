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
    public partial class Dashboard : Form
    {


        MySqlConnection cn;
        DBConnect dbcon = new DBConnect();
        




        public Dashboard()
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            
        }

        //private void Dashboard_Load(object sender, EventArgs e)
        //{
        //    string sdate = DateTime.Now.ToShortDateString();
        //    lblDailySale.Text = dbcon.ExtractData("SELECT ISNULL(SUM(total),0) AS total FROM tbCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" + sdate + "' AND '" + sdate + "'").ToString("#,##0.00");
        //    lblTotalProduct.Text = dbcon.ExtractData("SELECT COUNT(*) FROM tbProduct").ToString("#,##0");
        //    lblStockOnHand.Text = dbcon.ExtractData("SELECT ISNULL(SUM(qty), 0) AS qty FROM tbProduct").ToString("#,##0");
        //    lblCriticalItems.Text = dbcon.ExtractData("SELECT COUNT(*) FROM vwCriticalItems").ToString("#,##0");
        //}


        private void Dashboard_Load(object sender, EventArgs e)
        {
            string sdate = DateTime.Now.ToString("yyyy-MM-dd");
            string nextDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            lblDailySale.Text = dbcon.ExtractData(
                "SELECT IFNULL(SUM(total), 0) AS total FROM tbCart " +
                "WHERE status = 'Sold' AND sdate >= '" + sdate +
                "' AND sdate < '" + nextDate + "'"
            ).ToString("#,##0.00");

            lblTotalProduct.Text = dbcon.ExtractData(
                "SELECT COUNT(*) FROM tbProduct"
            ).ToString("#,##0");

            lblStockOnHand.Text = dbcon.ExtractData(
                "SELECT IFNULL(SUM(qty), 0) AS qty FROM tbProduct"
            ).ToString("#,##0");

            lblCriticalItems.Text = dbcon.ExtractData(
                "SELECT COUNT(*) FROM vwCriticalItems"
            ).ToString("#,##0");
        }

    }
}
