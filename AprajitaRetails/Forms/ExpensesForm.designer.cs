namespace AprajitaRetails.Forms
{
    partial class ExpensesForm
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
            this.GBExpenses = new System.Windows.Forms.GroupBox();
            this.TLPExpenses = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPOnDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CBCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBBankAccount = new System.Windows.Forms.Label();
            this.LBTrType = new System.Windows.Forms.Label();
            this.LBBankRef = new System.Windows.Forms.Label();
            this.LBTrRef = new System.Windows.Forms.Label();
            this.TXTReason = new System.Windows.Forms.TextBox();
            this.CBApprovedBy = new System.Windows.Forms.ComboBox();
            this.TXTAmount = new System.Windows.Forms.TextBox();
            this.CBPaymentMode = new System.Windows.Forms.ComboBox();
            this.CBBankAccount = new System.Windows.Forms.ComboBox();
            this.CBTranscationType = new System.Windows.Forms.ComboBox();
            this.TXTBankRef = new System.Windows.Forms.TextBox();
            this.TXTTranscationRef = new System.Windows.Forms.TextBox();
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.GBExpenses.SuspendLayout();
            this.TLPExpenses.SuspendLayout();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBExpenses
            // 
            this.GBExpenses.AutoSize = true;
            this.GBExpenses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBExpenses.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GBExpenses.Controls.Add(this.TLPExpenses);
            this.GBExpenses.Location = new System.Drawing.Point(12, 12);
            this.GBExpenses.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.GBExpenses.Name = "GBExpenses";
            this.GBExpenses.Size = new System.Drawing.Size(1060, 261);
            this.GBExpenses.TabIndex = 0;
            this.GBExpenses.TabStop = false;
            this.GBExpenses.Text = "Expenses";
            // 
            // TLPExpenses
            // 
            this.TLPExpenses.AutoSize = true;
            this.TLPExpenses.ColumnCount = 4;
            this.TLPExpenses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpenses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpenses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpenses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpenses.Controls.Add(this.label1, 0, 0);
            this.TLPExpenses.Controls.Add(this.DTPOnDate, 1, 0);
            this.TLPExpenses.Controls.Add(this.label2, 2, 0);
            this.TLPExpenses.Controls.Add(this.CBCategory, 3, 0);
            this.TLPExpenses.Controls.Add(this.label3, 0, 1);
            this.TLPExpenses.Controls.Add(this.label4, 2, 1);
            this.TLPExpenses.Controls.Add(this.label5, 0, 2);
            this.TLPExpenses.Controls.Add(this.label6, 2, 2);
            this.TLPExpenses.Controls.Add(this.LBBankAccount, 0, 3);
            this.TLPExpenses.Controls.Add(this.LBTrType, 2, 3);
            this.TLPExpenses.Controls.Add(this.LBBankRef, 0, 4);
            this.TLPExpenses.Controls.Add(this.LBTrRef, 2, 4);
            this.TLPExpenses.Controls.Add(this.TXTReason, 1, 1);
            this.TLPExpenses.Controls.Add(this.CBApprovedBy, 3, 1);
            this.TLPExpenses.Controls.Add(this.TXTAmount, 1, 2);
            this.TLPExpenses.Controls.Add(this.CBPaymentMode, 3, 2);
            this.TLPExpenses.Controls.Add(this.CBBankAccount, 1, 3);
            this.TLPExpenses.Controls.Add(this.CBTranscationType, 3, 3);
            this.TLPExpenses.Controls.Add(this.TXTBankRef, 1, 4);
            this.TLPExpenses.Controls.Add(this.TXTTranscationRef, 3, 4);
            this.TLPExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPExpenses.Location = new System.Drawing.Point(3, 34);
            this.TLPExpenses.Name = "TLPExpenses";
            this.TLPExpenses.RowCount = 5;
            this.TLPExpenses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpenses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpenses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpenses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpenses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpenses.Size = new System.Drawing.Size(1054, 224);
            this.TLPExpenses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // DTPOnDate
            // 
            this.DTPOnDate.Location = new System.Drawing.Point(199, 3);
            this.DTPOnDate.Name = "DTPOnDate";
            this.DTPOnDate.Size = new System.Drawing.Size(303, 38);
            this.DTPOnDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // CBCategory
            // 
            this.CBCategory.FormattingEnabled = true;
            this.CBCategory.Location = new System.Drawing.Point(748, 3);
            this.CBCategory.Name = "CBCategory";
            this.CBCategory.Size = new System.Drawing.Size(303, 39);
            this.CBCategory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reason";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "ApprovedBy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Payment Mode";
            // 
            // LBBankAccount
            // 
            this.LBBankAccount.AutoSize = true;
            this.LBBankAccount.Location = new System.Drawing.Point(3, 135);
            this.LBBankAccount.Name = "LBBankAccount";
            this.LBBankAccount.Size = new System.Drawing.Size(190, 32);
            this.LBBankAccount.TabIndex = 8;
            this.LBBankAccount.Text = "Bank Account";
            this.LBBankAccount.Visible = false;
            // 
            // LBTrType
            // 
            this.LBTrType.AutoSize = true;
            this.LBTrType.Location = new System.Drawing.Point(508, 135);
            this.LBTrType.Name = "LBTrType";
            this.LBTrType.Size = new System.Drawing.Size(234, 32);
            this.LBTrType.TabIndex = 9;
            this.LBTrType.Text = "Transcation Type";
            this.LBTrType.Visible = false;
            // 
            // LBBankRef
            // 
            this.LBBankRef.AutoSize = true;
            this.LBBankRef.Location = new System.Drawing.Point(3, 180);
            this.LBBankRef.Name = "LBBankRef";
            this.LBBankRef.Size = new System.Drawing.Size(139, 32);
            this.LBBankRef.TabIndex = 10;
            this.LBBankRef.Text = "Bank Ref.";
            this.LBBankRef.Visible = false;
            // 
            // LBTrRef
            // 
            this.LBTrRef.AutoSize = true;
            this.LBTrRef.Location = new System.Drawing.Point(508, 180);
            this.LBTrRef.Name = "LBTrRef";
            this.LBTrRef.Size = new System.Drawing.Size(215, 32);
            this.LBTrRef.TabIndex = 11;
            this.LBTrRef.Text = "Transcation Ref";
            this.LBTrRef.Visible = false;
            // 
            // TXTReason
            // 
            this.TXTReason.Location = new System.Drawing.Point(199, 48);
            this.TXTReason.Name = "TXTReason";
            this.TXTReason.Size = new System.Drawing.Size(303, 38);
            this.TXTReason.TabIndex = 12;
            // 
            // CBApprovedBy
            // 
            this.CBApprovedBy.FormattingEnabled = true;
            this.CBApprovedBy.Location = new System.Drawing.Point(748, 48);
            this.CBApprovedBy.Name = "CBApprovedBy";
            this.CBApprovedBy.Size = new System.Drawing.Size(303, 39);
            this.CBApprovedBy.TabIndex = 13;
            // 
            // TXTAmount
            // 
            this.TXTAmount.Location = new System.Drawing.Point(199, 93);
            this.TXTAmount.Name = "TXTAmount";
            this.TXTAmount.Size = new System.Drawing.Size(303, 38);
            this.TXTAmount.TabIndex = 0;
            // 
            // CBPaymentMode
            // 
            this.CBPaymentMode.Location = new System.Drawing.Point(748, 93);
            this.CBPaymentMode.Name = "CBPaymentMode";
            this.CBPaymentMode.Size = new System.Drawing.Size(303, 39);
            this.CBPaymentMode.TabIndex = 0;
            // 
            // CBBankAccount
            // 
            this.CBBankAccount.Location = new System.Drawing.Point(199, 138);
            this.CBBankAccount.Name = "CBBankAccount";
            this.CBBankAccount.Size = new System.Drawing.Size(303, 39);
            this.CBBankAccount.TabIndex = 0;
            this.CBBankAccount.Visible = false;
            // 
            // CBTranscationType
            // 
            this.CBTranscationType.Location = new System.Drawing.Point(748, 138);
            this.CBTranscationType.Name = "CBTranscationType";
            this.CBTranscationType.Size = new System.Drawing.Size(303, 39);
            this.CBTranscationType.TabIndex = 0;
            this.CBTranscationType.Visible = false;
            // 
            // TXTBankRef
            // 
            this.TXTBankRef.Location = new System.Drawing.Point(199, 183);
            this.TXTBankRef.Name = "TXTBankRef";
            this.TXTBankRef.Size = new System.Drawing.Size(303, 38);
            this.TXTBankRef.TabIndex = 0;
            this.TXTBankRef.Visible = false;
            // 
            // TXTTranscationRef
            // 
            this.TXTTranscationRef.Location = new System.Drawing.Point(748, 183);
            this.TXTTranscationRef.Name = "TXTTranscationRef";
            this.TXTTranscationRef.Size = new System.Drawing.Size(303, 38);
            this.TXTTranscationRef.TabIndex = 0;
            this.TXTTranscationRef.Visible = false;
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Location = new System.Drawing.Point(12, 315);
            this.GBControls.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(5);
            this.GBControls.Size = new System.Drawing.Size(788, 116);
            this.GBControls.TabIndex = 4;
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
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
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
            // ExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1113, 513);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.GBExpenses);
            this.MaximizeBox = false;
            this.Name = "ExpensesForm";
            this.Text = "ExpensesForm";
            this.Load += new System.EventHandler(this.ExpensesForm_Load);
            this.GBExpenses.ResumeLayout(false);
            this.GBExpenses.PerformLayout();
            this.TLPExpenses.ResumeLayout(false);
            this.TLPExpenses.PerformLayout();
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBExpenses;
        private System.Windows.Forms.TableLayoutPanel TLPExpenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPOnDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBBankAccount;
        private System.Windows.Forms.Label LBTrType;
        private System.Windows.Forms.Label LBBankRef;
        private System.Windows.Forms.Label LBTrRef;
        private System.Windows.Forms.TextBox TXTReason;
        private System.Windows.Forms.ComboBox CBApprovedBy;
        private System.Windows.Forms.TextBox TXTAmount;
        private System.Windows.Forms.ComboBox CBPaymentMode;
        private System.Windows.Forms.ComboBox CBBankAccount;
        private System.Windows.Forms.ComboBox CBTranscationType;
        private System.Windows.Forms.TextBox TXTBankRef;
        private System.Windows.Forms.TextBox TXTTranscationRef;
        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
    }
}