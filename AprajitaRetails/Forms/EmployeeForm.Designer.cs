namespace AprajitaRetails.Forms
{
    partial class EmployeeForm
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
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.CBMobileSearch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CBNameSearch = new System.Windows.Forms.ComboBox();
            this.BTNFind = new System.Windows.Forms.Button();
            this.GBEmployeeDetails = new System.Windows.Forms.GroupBox();
            this.TLPEmployeeDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTFirstName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CBEmpCode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DTPJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.TXTLastName = new System.Windows.Forms.TextBox();
            this.DTPBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.CBCity = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.CBCountry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CBEmpType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TXTAttendenceID = new System.Windows.Forms.TextBox();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.GBEmployeeDetails.SuspendLayout();
            this.TLPEmployeeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Location = new System.Drawing.Point(19, 630);
            this.GBControls.Margin = new System.Windows.Forms.Padding(5);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(5);
            this.GBControls.Size = new System.Drawing.Size(788, 116);
            this.GBControls.TabIndex = 6;
            this.GBControls.TabStop = false;
            this.GBControls.Text = "Controls";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.BTNAdd);
            this.flowLayoutPanel2.Controls.Add(this.BTNDelete);
            this.flowLayoutPanel2.Controls.Add(this.Cancel);
            this.flowLayoutPanel2.Controls.Add(this.BTNUpdate);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 36);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(778, 75);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // BTNAdd
            // 
            this.BTNAdd.AutoSize = true;
            this.BTNAdd.Location = new System.Drawing.Point(5, 5);
            this.BTNAdd.Margin = new System.Windows.Forms.Padding(5);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(135, 65);
            this.BTNAdd.TabIndex = 4;
            this.BTNAdd.Text = "Add";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // BTNDelete
            // 
            this.BTNDelete.AutoSize = true;
            this.BTNDelete.Location = new System.Drawing.Point(150, 5);
            this.BTNDelete.Margin = new System.Windows.Forms.Padding(5);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(192, 65);
            this.BTNDelete.TabIndex = 6;
            this.BTNDelete.Text = "Delete";
            this.BTNDelete.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.Location = new System.Drawing.Point(352, 5);
            this.Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(203, 65);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // BTNUpdate
            // 
            this.BTNUpdate.AutoSize = true;
            this.BTNUpdate.Location = new System.Drawing.Point(565, 5);
            this.BTNUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.BTNUpdate.Name = "BTNUpdate";
            this.BTNUpdate.Size = new System.Drawing.Size(208, 65);
            this.BTNUpdate.TabIndex = 5;
            this.BTNUpdate.Text = "Update";
            this.BTNUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(24, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1028, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.CBMobileSearch);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.CBNameSearch);
            this.flowLayoutPanel1.Controls.Add(this.BTNFind);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 36);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1018, 82);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 18, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mobile";
            // 
            // CBMobileSearch
            // 
            this.CBMobileSearch.FormattingEnabled = true;
            this.CBMobileSearch.Location = new System.Drawing.Point(146, 20);
            this.CBMobileSearch.Margin = new System.Windows.Forms.Padding(5, 5, 53, 5);
            this.CBMobileSearch.Name = "CBMobileSearch";
            this.CBMobileSearch.Size = new System.Drawing.Size(212, 39);
            this.CBMobileSearch.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 36, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "Name";
            // 
            // CBNameSearch
            // 
            this.CBNameSearch.FormattingEnabled = true;
            this.CBNameSearch.Location = new System.Drawing.Point(547, 20);
            this.CBNameSearch.Margin = new System.Windows.Forms.Padding(5, 5, 53, 5);
            this.CBNameSearch.Name = "CBNameSearch";
            this.CBNameSearch.Size = new System.Drawing.Size(212, 39);
            this.CBNameSearch.TabIndex = 3;
            // 
            // BTNFind
            // 
            this.BTNFind.AutoSize = true;
            this.BTNFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNFind.Location = new System.Drawing.Point(817, 20);
            this.BTNFind.Margin = new System.Windows.Forms.Padding(5);
            this.BTNFind.Name = "BTNFind";
            this.BTNFind.Size = new System.Drawing.Size(81, 42);
            this.BTNFind.TabIndex = 4;
            this.BTNFind.Text = "Find";
            this.BTNFind.UseVisualStyleBackColor = true;
            // 
            // GBEmployeeDetails
            // 
            this.GBEmployeeDetails.AutoSize = true;
            this.GBEmployeeDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBEmployeeDetails.BackColor = System.Drawing.Color.Transparent;
            this.GBEmployeeDetails.Controls.Add(this.TLPEmployeeDetails);
            this.GBEmployeeDetails.Location = new System.Drawing.Point(19, 137);
            this.GBEmployeeDetails.Margin = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.GBEmployeeDetails.Name = "GBEmployeeDetails";
            this.GBEmployeeDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GBEmployeeDetails.Size = new System.Drawing.Size(1174, 432);
            this.GBEmployeeDetails.TabIndex = 4;
            this.GBEmployeeDetails.TabStop = false;
            this.GBEmployeeDetails.Text = "Employee Details";
            // 
            // TLPEmployeeDetails
            // 
            this.TLPEmployeeDetails.AutoSize = true;
            this.TLPEmployeeDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPEmployeeDetails.ColumnCount = 4;
            this.TLPEmployeeDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPEmployeeDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.TLPEmployeeDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPEmployeeDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.TLPEmployeeDetails.Controls.Add(this.label1, 0, 1);
            this.TLPEmployeeDetails.Controls.Add(this.label2, 0, 2);
            this.TLPEmployeeDetails.Controls.Add(this.label3, 0, 3);
            this.TLPEmployeeDetails.Controls.Add(this.label4, 0, 4);
            this.TLPEmployeeDetails.Controls.Add(this.TXTFirstName, 1, 1);
            this.TLPEmployeeDetails.Controls.Add(this.txtAge, 1, 2);
            this.TLPEmployeeDetails.Controls.Add(this.txtAddress, 1, 4);
            this.TLPEmployeeDetails.Controls.Add(this.cbGender, 1, 3);
            this.TLPEmployeeDetails.Controls.Add(this.label9, 0, 0);
            this.TLPEmployeeDetails.Controls.Add(this.CBEmpCode, 1, 0);
            this.TLPEmployeeDetails.Controls.Add(this.TXTLastName, 2, 1);
            this.TLPEmployeeDetails.Controls.Add(this.DTPBirthDate, 3, 2);
            this.TLPEmployeeDetails.Controls.Add(this.label11, 2, 2);
            this.TLPEmployeeDetails.Controls.Add(this.CBCity, 3, 4);
            this.TLPEmployeeDetails.Controls.Add(this.label12, 2, 4);
            this.TLPEmployeeDetails.Controls.Add(this.cbState, 3, 5);
            this.TLPEmployeeDetails.Controls.Add(this.CBCountry, 3, 6);
            this.TLPEmployeeDetails.Controls.Add(this.label5, 2, 5);
            this.TLPEmployeeDetails.Controls.Add(this.label15, 2, 6);
            this.TLPEmployeeDetails.Controls.Add(this.label13, 2, 0);
            this.TLPEmployeeDetails.Controls.Add(this.CBEmpType, 3, 0);
            this.TLPEmployeeDetails.Controls.Add(this.label10, 2, 3);
            this.TLPEmployeeDetails.Controls.Add(this.DTPJoiningDate, 3, 3);
            this.TLPEmployeeDetails.Controls.Add(this.label6, 0, 13);
            this.TLPEmployeeDetails.Controls.Add(this.txtMobileNo, 1, 13);
            this.TLPEmployeeDetails.Controls.Add(this.label14, 2, 13);
            this.TLPEmployeeDetails.Controls.Add(this.TXTAttendenceID, 3, 13);
            this.TLPEmployeeDetails.Location = new System.Drawing.Point(5, 37);
            this.TLPEmployeeDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TLPEmployeeDetails.Name = "TLPEmployeeDetails";
            this.TLPEmployeeDetails.RowCount = 14;
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPEmployeeDetails.Size = new System.Drawing.Size(1161, 358);
            this.TLPEmployeeDetails.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // TXTFirstName
            // 
            this.TXTFirstName.Location = new System.Drawing.Point(155, 48);
            this.TXTFirstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TXTFirstName.Name = "TXTFirstName";
            this.TXTFirstName.Size = new System.Drawing.Size(386, 38);
            this.TXTFirstName.TabIndex = 1;
            this.TXTFirstName.Text = "Amit";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(155, 92);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(386, 38);
            this.txtAge.TabIndex = 3;
            this.txtAge.Text = "29";
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsReturn = true;
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddress.Location = new System.Drawing.Point(155, 181);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.TLPEmployeeDetails.SetRowSpan(this.txtAddress, 3);
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAddress.Size = new System.Drawing.Size(386, 119);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.Text = "Dumka";
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(155, 136);
            this.cbGender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(386, 39);
            this.cbGender.TabIndex = 4;
            this.cbGender.Text = "Male";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 32);
            this.label9.TabIndex = 10;
            this.label9.Text = "EmpCode";
            // 
            // CBEmpCode
            // 
            this.CBEmpCode.FormattingEnabled = true;
            this.CBEmpCode.Location = new System.Drawing.Point(154, 3);
            this.CBEmpCode.Name = "CBEmpCode";
            this.CBEmpCode.Size = new System.Drawing.Size(193, 39);
            this.CBEmpCode.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 32);
            this.label10.TabIndex = 12;
            this.label10.Text = "Joining Date";
            // 
            // DTPJoiningDate
            // 
            this.DTPJoiningDate.Location = new System.Drawing.Point(743, 136);
            this.DTPJoiningDate.Name = "DTPJoiningDate";
            this.DTPJoiningDate.Size = new System.Drawing.Size(272, 38);
            this.DTPJoiningDate.TabIndex = 13;
            // 
            // TXTLastName
            // 
            this.TLPEmployeeDetails.SetColumnSpan(this.TXTLastName, 2);
            this.TXTLastName.Location = new System.Drawing.Point(551, 48);
            this.TXTLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TXTLastName.Name = "TXTLastName";
            this.TXTLastName.Size = new System.Drawing.Size(386, 38);
            this.TXTLastName.TabIndex = 2;
            this.TXTLastName.Text = "Kumar";
            // 
            // DTPBirthDate
            // 
            this.DTPBirthDate.Location = new System.Drawing.Point(743, 92);
            this.DTPBirthDate.Name = "DTPBirthDate";
            this.DTPBirthDate.Size = new System.Drawing.Size(272, 38);
            this.DTPBirthDate.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(550, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 32);
            this.label11.TabIndex = 15;
            this.label11.Text = "BirthDate";
            // 
            // CBCity
            // 
            this.CBCity.FormattingEnabled = true;
            this.CBCity.Location = new System.Drawing.Point(744, 181);
            this.CBCity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CBCity.Name = "CBCity";
            this.CBCity.Size = new System.Drawing.Size(386, 39);
            this.CBCity.TabIndex = 6;
            this.CBCity.Text = "Dumka";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(550, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 32);
            this.label12.TabIndex = 16;
            this.label12.Text = "City";
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(744, 227);
            this.cbState.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(386, 39);
            this.cbState.TabIndex = 7;
            this.cbState.Text = "Jharkhand";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 314);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(155, 317);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(386, 38);
            this.txtMobileNo.TabIndex = 9;
            this.txtMobileNo.Text = "7779997556";
            // 
            // CBCountry
            // 
            this.CBCountry.FormattingEnabled = true;
            this.CBCountry.Location = new System.Drawing.Point(744, 272);
            this.CBCountry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CBCountry.Name = "CBCountry";
            this.CBCountry.Size = new System.Drawing.Size(152, 39);
            this.CBCountry.TabIndex = 8;
            this.CBCountry.Text = "India";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 224);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "State";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(550, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 32);
            this.label15.TabIndex = 19;
            this.label15.Text = "Country";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(550, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 32);
            this.label13.TabIndex = 20;
            this.label13.Text = "Emp Type";
            // 
            // CBEmpType
            // 
            this.CBEmpType.FormattingEnabled = true;
            this.CBEmpType.Location = new System.Drawing.Point(743, 3);
            this.CBEmpType.Name = "CBEmpType";
            this.CBEmpType.Size = new System.Drawing.Size(272, 39);
            this.CBEmpType.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(550, 314);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 32);
            this.label14.TabIndex = 22;
            this.label14.Text = "AttendenceID";
            // 
            // TXTAttendenceID
            // 
            this.TXTAttendenceID.Location = new System.Drawing.Point(743, 317);
            this.TXTAttendenceID.Name = "TXTAttendenceID";
            this.TXTAttendenceID.Size = new System.Drawing.Size(194, 38);
            this.TXTAttendenceID.TabIndex = 23;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1690, 916);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBEmployeeDetails);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.GBEmployeeDetails.ResumeLayout(false);
            this.GBEmployeeDetails.PerformLayout();
            this.TLPEmployeeDetails.ResumeLayout(false);
            this.TLPEmployeeDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBMobileSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CBNameSearch;
        private System.Windows.Forms.Button BTNFind;
        private System.Windows.Forms.GroupBox GBEmployeeDetails;
        private System.Windows.Forms.TableLayoutPanel TLPEmployeeDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTFirstName;
        private System.Windows.Forms.TextBox TXTLastName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox CBCity;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ComboBox CBCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CBEmpCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DTPJoiningDate;
        private System.Windows.Forms.DateTimePicker DTPBirthDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CBEmpType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TXTAttendenceID;
    }
}