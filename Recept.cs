
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    public partial class Recept : Form
    {

        MySqlConnection cn;
        MySqlCommand cmd;
        DBConnect dbcon = new DBConnect();
        MySqlDataReader dr;

        string store;
        string address;
        Cashier cashier;


        public Recept(Cashier cash)
        {
            InitializeComponent();
            cn = dbcon.GetConnection();
            cashier = cash;
            LoadStore();
        }


        public void LoadStore()
        {
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM tbStore", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                store = dr["store"].ToString();
                address = dr["address"].ToString();
            }
            dr.Close();
            cn.Close();
        }



        private void Recept_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void LoadRecept(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;

            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptRecept.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                MySqlDataAdapter da = new MySqlDataAdapter();

                cn.Open();
                da.SelectCommand = new MySqlCommand("SELECT c.id, c.transno, c.pcode, c.price, c.qty, c.disc, c.total, c.sdate, c.status, p.pdesc FROM tbCart AS c INNER JOIN tbProduct AS P ON p.pcode=c.pcode WHERE c.transno LIKE '" + cashier.lblTranNo.Text + "'", cn);
                da.Fill(ds.Tables["dtRecept"]);
                cn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", cashier.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", cashier.lblVat.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", cashier.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", cashier.lblDisplayTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction", "Invoice #: " + cashier.lblTranNo.Text);
                ReportParameter pCashier = new ReportParameter("pCashier", cashier.lblUsername.Text);


                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);

                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtRecept"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 30;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Recept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void Recept_Load_1(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
