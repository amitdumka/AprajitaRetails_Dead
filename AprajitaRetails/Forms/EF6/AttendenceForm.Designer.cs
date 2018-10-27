namespace AprajitaRetails.Forms
{
    partial class AttendenceForm
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
            this.GBAttendence = new System.Windows.Forms.GroupBox();
            this.TLPAttendence = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CBEmpCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTFirstName = new System.Windows.Forms.TextBox();
            this.TXTLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTAttendenceNo = new System.Windows.Forms.TextBox();
            this.LBAttenceDate = new System.Windows.Forms.Label();
            this.CKAbesent = new System.Windows.Forms.CheckBox();
            this.CKPaidLeaves = new System.Windows.Forms.CheckBox();
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.GBAttendence.SuspendLayout();
            this.TLPAttendence.SuspendLayout();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBAttendence
            // 
            this.GBAttendence.AutoSize = true;
            this.GBAttendence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBAttendence.Controls.Add(this.TLPAttendence);
            this.GBAttendence.Location = new System.Drawing.Point(9, 10);
            this.GBAttendence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.GBAttendence.Name = "GBAttendence";
            this.GBAttendence.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBAttendence.Size = new System.Drawing.Size(658, 147);
            this.GBAttendence.TabIndex = 0;
            this.GBAttendence.TabStop = false;
            this.GBAttendence.Text = "Attendence";
            // 
            // TLPAttendence
            // 
            this.TLPAttendence.AutoScroll = true;
            this.TLPAttendence.AutoSize = true;
            this.TLPAttendence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPAttendence.BackColor = System.Drawing.Color.LightPink;
            this.TLPAttendence.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.TLPAttendence.ColumnCount = 4;
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPAttendence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLPAttendence.Controls.Add(this.label1, 0, 0);
            this.TLPAttendence.Controls.Add(this.CBEmpCode, 1, 0);
            this.TLPAttendence.Controls.Add(this.label2, 0, 1);
            this.TLPAttendence.Controls.Add(this.TXTFirstName, 1, 1);
            this.TLPAttendence.Controls.Add(this.TXTLastName, 2, 1);
            this.TLPAttendence.Controls.Add(this.label3, 2, 0);
            this.TLPAttendence.Controls.Add(this.label5, 0, 2);
            this.TLPAttendence.Controls.Add(this.TXTAttendenceNo, 1, 2);
            this.TLPAttendence.Controls.Add(this.LBAttenceDate, 3, 0);
            this.TLPAttendence.Controls.Add(this.CKAbesent, 2, 2);
            this.TLPAttendence.Controls.Add(this.CKPaidLeaves, 3, 2);
            this.TLPAttendence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPAttendence.Location = new System.Drawing.Point(2, 26);
            this.TLPAttendence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPAttendence.Name = "TLPAttendence";
            this.TLPAttendence.RowCount = 3;
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TLPAttendence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TLPAttendence.Size = new System.Drawing.Size(654, 119);
            this.TLPAttendence.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "EMP Code";
            // 
            // CBEmpCode
            // 
            this.CBEmpCode.FormattingEnabled = true;
            this.CBEmpCode.Location = new System.Drawing.Point(181, 5);
            this.CBEmpCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBEmpCode.Name = "CBEmpCode";
            this.CBEmpCode.Size = new System.Drawing.Size(144, 33);
            this.CBEmpCode.TabIndex = 1;
            this.CBEmpCode.SelectedIndexChanged += new System.EventHandler(this.CBEmpCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee Name";
            // 
            // TXTFirstName
            // 
            this.TXTFirstName.Location = new System.Drawing.Point(181, 45);
            this.TXTFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXTFirstName.Name = "TXTFirstName";
            this.TXTFirstName.Size = new System.Drawing.Size(159, 31);
            this.TXTFirstName.TabIndex = 3;
            // 
            // TXTLastName
            // 
            this.TXTLastName.Location = new System.Drawing.Point(347, 45);
            this.TXTLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXTLastName.Name = "TXTLastName";
            this.TXTLastName.Size = new System.Drawing.Size(132, 31);
            this.TXTLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Attendece";
            // 
            // TXTAttendenceNo
            // 
            this.TXTAttendenceNo.Location = new System.Drawing.Point(181, 83);
            this.TXTAttendenceNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXTAttendenceNo.Name = "TXTAttendenceNo";
            this.TXTAttendenceNo.Size = new System.Drawing.Size(159, 31);
            this.TXTAttendenceNo.TabIndex = 10;
            // 
            // LBAttenceDate
            // 
            this.LBAttenceDate.AutoSize = true;
            this.LBAttenceDate.Location = new System.Drawing.Point(486, 3);
            this.LBAttenceDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBAttenceDate.Name = "LBAttenceDate";
            this.LBAttenceDate.Size = new System.Drawing.Size(160, 25);
            this.LBAttenceDate.TabIndex = 29;
            this.LBAttenceDate.Text = "Attendece Date";
            // 
            // CKAbesent
            // 
            this.CKAbesent.AutoSize = true;
            this.CKAbesent.Location = new System.Drawing.Point(347, 83);
            this.CKAbesent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CKAbesent.Name = "CKAbesent";
            this.CKAbesent.Size = new System.Drawing.Size(111, 29);
            this.CKAbesent.TabIndex = 30;
            this.CKAbesent.Text = "Absent";
            this.CKAbesent.UseVisualStyleBackColor = true;
            // 
            // CKPaidLeaves
            // 
            this.CKPaidLeaves.AutoSize = true;
            this.CKPaidLeaves.Location = new System.Drawing.Point(486, 83);
            this.CKPaidLeaves.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CKPaidLeaves.Name = "CKPaidLeaves";
            this.CKPaidLeaves.Size = new System.Drawing.Size(163, 29);
            this.CKPaidLeaves.TabIndex = 31;
            this.CKPaidLeaves.Text = "Paid Leaves";
            this.CKPaidLeaves.UseVisualStyleBackColor = true;
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Location = new System.Drawing.Point(28, 182);
            this.GBControls.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBControls.Size = new System.Drawing.Size(593, 92);
            this.GBControls.TabIndex = 5;
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 28);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(585, 60);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // BTNAdd
            // 
            this.BTNAdd.AutoSize = true;
            this.BTNAdd.Location = new System.Drawing.Point(4, 4);
            this.BTNAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(101, 52);
            this.BTNAdd.TabIndex = 4;
            this.BTNAdd.Text = "Add";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // BTNDelete
            // 
            this.BTNDelete.AutoSize = true;
            this.BTNDelete.Location = new System.Drawing.Point(113, 4);
            this.BTNDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(144, 52);
            this.BTNDelete.TabIndex = 6;
            this.BTNDelete.Text = "Delete";
            this.BTNDelete.UseVisualStyleBackColor = true;
            this.BTNDelete.Visible = false;
            this.BTNDelete.Click += new System.EventHandler(this.BTNDelete_Click);
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.Location = new System.Drawing.Point(265, 4);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(152, 52);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // BTNUpdate
            // 
            this.BTNUpdate.AutoSize = true;
            this.BTNUpdate.Location = new System.Drawing.Point(425, 4);
            this.BTNUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNUpdate.Name = "BTNUpdate";
            this.BTNUpdate.Size = new System.Drawing.Size(156, 52);
            this.BTNUpdate.TabIndex = 5;
            this.BTNUpdate.Text = "Update";
            this.BTNUpdate.UseVisualStyleBackColor = true;
            this.BTNUpdate.Visible = false;
            this.BTNUpdate.Click += new System.EventHandler(this.BTNUpdate_Click);
            // 
            // AttendenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 306);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.GBAttendence);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "AttendenceForm";
            this.Text = "Attendence";
            this.Load += new System.EventHandler(this.AttendenceForm_Load);
            this.GBAttendence.ResumeLayout(false);
            this.GBAttendence.PerformLayout();
            this.TLPAttendence.ResumeLayout(false);
            this.TLPAttendence.PerformLayout();
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBAttendence;
        private System.Windows.Forms.TableLayoutPanel TLPAttendence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBEmpCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTFirstName;
        private System.Windows.Forms.TextBox TXTLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTAttendenceNo;
        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
        private System.Windows.Forms.Label LBAttenceDate;
        private System.Windows.Forms.CheckBox CKAbesent;
        private System.Windows.Forms.CheckBox CKPaidLeaves;
    }
}