namespace AprajitaRetails.Forms
{
    partial class UploaderForm
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
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNGetExcel = new System.Windows.Forms.Button();
            this.BTNSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTFileName = new System.Windows.Forms.TextBox();
            this.TXTEnd = new System.Windows.Forms.TextBox();
            this.TXTStart = new System.Windows.Forms.TextBox();
            this.CBUploadType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GBDataGrid = new System.Windows.Forms.GroupBox();
            this.DGVUploadedData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CKWithProfit = new System.Windows.Forms.CheckBox();
            this.BTNReload = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.BTNByYear = new System.Windows.Forms.Button();
            this.BTNByMonth = new System.Windows.Forms.Button();
            this.BTNByDay = new System.Windows.Forms.Button();
            this.BTNQuery = new System.Windows.Forms.Button();
            this.ExcelFileOpenDialogg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.GBDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUploadedData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Size = new System.Drawing.Size(356, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Uploader";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BTNGetExcel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BTNSave, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TXTFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TXTEnd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TXTStart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CBUploadType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 86);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel File";
            this.label1.UseWaitCursor = true;
            // 
            // BTNGetExcel
            // 
            this.BTNGetExcel.AutoSize = true;
            this.BTNGetExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNGetExcel.Location = new System.Drawing.Point(185, 1);
            this.BTNGetExcel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BTNGetExcel.Name = "BTNGetExcel";
            this.BTNGetExcel.Size = new System.Drawing.Size(95, 23);
            this.BTNGetExcel.TabIndex = 2;
            this.BTNGetExcel.Text = "Select Excel File";
            this.BTNGetExcel.UseVisualStyleBackColor = true;
            this.BTNGetExcel.Click += new System.EventHandler(this.BTNGetExcel_Click);
            // 
            // BTNSave
            // 
            this.BTNSave.AutoSize = true;
            this.BTNSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNSave.Location = new System.Drawing.Point(185, 26);
            this.BTNSave.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(42, 23);
            this.BTNSave.TabIndex = 3;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Upload Type";
            // 
            // TXTFileName
            // 
            this.TXTFileName.Location = new System.Drawing.Point(74, 1);
            this.TXTFileName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TXTFileName.Name = "TXTFileName";
            this.TXTFileName.Size = new System.Drawing.Size(107, 20);
            this.TXTFileName.TabIndex = 1;
            // 
            // TXTEnd
            // 
            this.TXTEnd.Location = new System.Drawing.Point(74, 76);
            this.TXTEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXTEnd.Name = "TXTEnd";
            this.TXTEnd.Size = new System.Drawing.Size(51, 20);
            this.TXTEnd.TabIndex = 7;
            this.TXTEnd.Text = "End";
            // 
            // TXTStart
            // 
            this.TXTStart.Location = new System.Drawing.Point(74, 52);
            this.TXTStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXTStart.Name = "TXTStart";
            this.TXTStart.Size = new System.Drawing.Size(51, 20);
            this.TXTStart.TabIndex = 6;
            this.TXTStart.Text = "start";
            // 
            // CBUploadType
            // 
            this.CBUploadType.FormattingEnabled = true;
            this.CBUploadType.Location = new System.Drawing.Point(74, 26);
            this.CBUploadType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CBUploadType.Name = "CBUploadType";
            this.CBUploadType.Size = new System.Drawing.Size(107, 21);
            this.CBUploadType.TabIndex = 4;
            this.CBUploadType.SelectedIndexChanged += new System.EventHandler(this.CBUploadType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Start Row";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "End Row";
            // 
            // GBDataGrid
            // 
            this.GBDataGrid.AutoSize = true;
            this.GBDataGrid.Controls.Add(this.DGVUploadedData);
            this.GBDataGrid.Location = new System.Drawing.Point(6, 133);
            this.GBDataGrid.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GBDataGrid.Name = "GBDataGrid";
            this.GBDataGrid.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GBDataGrid.Size = new System.Drawing.Size(1222, 321);
            this.GBDataGrid.TabIndex = 1;
            this.GBDataGrid.TabStop = false;
            this.GBDataGrid.Text = "Uploaded Data";
            // 
            // DGVUploadedData
            // 
            this.DGVUploadedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUploadedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVUploadedData.Location = new System.Drawing.Point(1, 14);
            this.DGVUploadedData.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.DGVUploadedData.Name = "DGVUploadedData";
            this.DGVUploadedData.RowTemplate.Height = 40;
            this.DGVUploadedData.Size = new System.Drawing.Size(1220, 306);
            this.DGVUploadedData.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(363, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Size = new System.Drawing.Size(237, 103);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.CKWithProfit, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.BTNReload, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.pBar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BTNByYear, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BTNByMonth, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BTNByDay, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.BTNQuery, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 14);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(235, 88);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CKWithProfit
            // 
            this.CKWithProfit.AutoSize = true;
            this.CKWithProfit.Location = new System.Drawing.Point(162, 63);
            this.CKWithProfit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CKWithProfit.Name = "CKWithProfit";
            this.CKWithProfit.Size = new System.Drawing.Size(71, 17);
            this.CKWithProfit.TabIndex = 11;
            this.CKWithProfit.Text = "with profit";
            this.CKWithProfit.UseVisualStyleBackColor = true;
            // 
            // BTNReload
            // 
            this.BTNReload.AutoSize = true;
            this.BTNReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNReload.Location = new System.Drawing.Point(82, 63);
            this.BTNReload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTNReload.Name = "BTNReload";
            this.BTNReload.Size = new System.Drawing.Size(51, 23);
            this.BTNReload.TabIndex = 8;
            this.BTNReload.Text = "Reload";
            this.BTNReload.UseVisualStyleBackColor = true;
            this.BTNReload.Click += new System.EventHandler(this.BTNReload_Click);
            // 
            // pBar
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.pBar, 3);
            this.pBar.Location = new System.Drawing.Point(2, 2);
            this.pBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(230, 34);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 7;
            // 
            // BTNByYear
            // 
            this.BTNByYear.Location = new System.Drawing.Point(2, 63);
            this.BTNByYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTNByYear.Name = "BTNByYear";
            this.BTNByYear.Size = new System.Drawing.Size(76, 19);
            this.BTNByYear.TabIndex = 9;
            this.BTNByYear.Text = "By Year";
            this.BTNByYear.UseVisualStyleBackColor = true;
            this.BTNByYear.Click += new System.EventHandler(this.BTNByYear_Click);
            // 
            // BTNByMonth
            // 
            this.BTNByMonth.Location = new System.Drawing.Point(2, 40);
            this.BTNByMonth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTNByMonth.Name = "BTNByMonth";
            this.BTNByMonth.Size = new System.Drawing.Size(76, 19);
            this.BTNByMonth.TabIndex = 8;
            this.BTNByMonth.Text = "By Month";
            this.BTNByMonth.UseVisualStyleBackColor = true;
            this.BTNByMonth.Click += new System.EventHandler(this.BTNByMonth_Click);
            // 
            // BTNByDay
            // 
            this.BTNByDay.Location = new System.Drawing.Point(82, 40);
            this.BTNByDay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTNByDay.Name = "BTNByDay";
            this.BTNByDay.Size = new System.Drawing.Size(76, 19);
            this.BTNByDay.TabIndex = 10;
            this.BTNByDay.Text = "By Day";
            this.BTNByDay.UseVisualStyleBackColor = true;
            this.BTNByDay.Click += new System.EventHandler(this.BTNByDay_Click);
            // 
            // BTNQuery
            // 
            this.BTNQuery.Location = new System.Drawing.Point(161, 39);
            this.BTNQuery.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.BTNQuery.Name = "BTNQuery";
            this.BTNQuery.Size = new System.Drawing.Size(62, 20);
            this.BTNQuery.TabIndex = 12;
            this.BTNQuery.Text = "Query";
            this.BTNQuery.UseVisualStyleBackColor = true;
            this.BTNQuery.Click += new System.EventHandler(this.BTNQuery_Click);
            // 
            // ExcelFileOpenDialogg
            // 
            this.ExcelFileOpenDialogg.FileName = "ExcelFileOpenDialogg";
            // 
            // UploaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(747, 294);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GBDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "UploaderForm";
            this.Text = "UploaderForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UploaderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.GBDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUploadedData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNGetExcel;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTFileName;
        private System.Windows.Forms.TextBox TXTEnd;
        private System.Windows.Forms.TextBox TXTStart;
        private System.Windows.Forms.ComboBox CBUploadType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GBDataGrid;
        private System.Windows.Forms.DataGridView DGVUploadedData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button BTNByMonth;
        private System.Windows.Forms.Button BTNReload;
        private System.Windows.Forms.CheckBox CKWithProfit;
        private System.Windows.Forms.Button BTNByYear;
        private System.Windows.Forms.Button BTNByDay;
        private System.Windows.Forms.OpenFileDialog ExcelFileOpenDialogg;
        private System.Windows.Forms.Button BTNQuery;
    }
}