namespace POSales
{
    partial class Record
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Record));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTopSelling = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFromTopSell = new System.Windows.Forms.DateTimePicker();
            this.dtToTopSell = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTopSell = new System.Windows.Forms.ComboBox();
            this.btnPrintTopSell = new System.Windows.Forms.Button();
            this.btnLoadTopSell = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 89);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Record";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Controls.Add(this.tabPage3);
            this.metroTabControl1.Controls.Add(this.tabPage4);
            this.metroTabControl1.Controls.Add(this.tabPage5);
            this.metroTabControl1.Controls.Add(this.tabPage6);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(982, 464);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvTopSelling);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(974, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Top Selling";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(974, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sold Items";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(974, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Critical Stocks";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(974, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Inventory List";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 38);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(974, 422);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cancelled Order";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 38);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(974, 422);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Stock In History";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadTopSell);
            this.panel2.Controls.Add(this.btnPrintTopSell);
            this.panel2.Controls.Add(this.cbTopSell);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtToTopSell);
            this.panel2.Controls.Add(this.dtFromTopSell);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 75);
            this.panel2.TabIndex = 6;
            // 
            // dgvTopSelling
            // 
            this.dgvTopSelling.AllowUserToAddRows = false;
            this.dgvTopSelling.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSelling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopSelling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTopSelling.ColumnHeadersHeight = 30;
            this.dgvTopSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTopSelling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column7});
            this.dgvTopSelling.EnableHeadersVisualStyles = false;
            this.dgvTopSelling.Location = new System.Drawing.Point(0, 75);
            this.dgvTopSelling.Name = "dgvTopSelling";
            this.dgvTopSelling.RowHeadersVisible = false;
            this.dgvTopSelling.RowHeadersWidth = 51;
            this.dgvTopSelling.RowTemplate.Height = 24;
            this.dgvTopSelling.Size = new System.Drawing.Size(974, 344);
            this.dgvTopSelling.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Pcode";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 88;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Description";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Qty";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 65;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Total Sales";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter By : From";
            // 
            // dtFromTopSell
            // 
            this.dtFromTopSell.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromTopSell.Location = new System.Drawing.Point(146, 18);
            this.dtFromTopSell.Name = "dtFromTopSell";
            this.dtFromTopSell.Size = new System.Drawing.Size(119, 28);
            this.dtFromTopSell.TabIndex = 1;
            // 
            // dtToTopSell
            // 
            this.dtToTopSell.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToTopSell.Location = new System.Drawing.Point(307, 18);
            this.dtToTopSell.Name = "dtToTopSell";
            this.dtToTopSell.Size = new System.Drawing.Size(119, 28);
            this.dtToTopSell.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // cbTopSell
            // 
            this.cbTopSell.FormattingEnabled = true;
            this.cbTopSell.Items.AddRange(new object[] {
            "Sort By Qty",
            "Sort By Total Amount"});
            this.cbTopSell.Location = new System.Drawing.Point(462, 17);
            this.cbTopSell.Name = "cbTopSell";
            this.cbTopSell.Size = new System.Drawing.Size(121, 29);
            this.cbTopSell.TabIndex = 4;
            this.cbTopSell.Text = "Select sort type";
            // 
            // btnPrintTopSell
            // 
            this.btnPrintTopSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintTopSell.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintTopSell.Image")));
            this.btnPrintTopSell.Location = new System.Drawing.Point(916, 14);
            this.btnPrintTopSell.Name = "btnPrintTopSell";
            this.btnPrintTopSell.Size = new System.Drawing.Size(41, 41);
            this.btnPrintTopSell.TabIndex = 24;
            this.btnPrintTopSell.UseVisualStyleBackColor = true;
            // 
            // btnLoadTopSell
            // 
            this.btnLoadTopSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadTopSell.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadTopSell.Image")));
            this.btnLoadTopSell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadTopSell.Location = new System.Drawing.Point(601, 18);
            this.btnLoadTopSell.Name = "btnLoadTopSell";
            this.btnLoadTopSell.Size = new System.Drawing.Size(136, 33);
            this.btnLoadTopSell.TabIndex = 25;
            this.btnLoadTopSell.Text = "Load Data";
            this.btnLoadTopSell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadTopSell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadTopSell.UseVisualStyleBackColor = true;
            this.btnLoadTopSell.Click += new System.EventHandler(this.btnLoadTopSell_Click);
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.ControlBox = false;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECORD";
            this.panel1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTopSelling;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DateTimePicker dtFromTopSell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTopSell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtToTopSell;
        private System.Windows.Forms.Button btnLoadTopSell;
        private System.Windows.Forms.Button btnPrintTopSell;
    }
}