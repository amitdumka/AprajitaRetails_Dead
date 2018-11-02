namespace AprajitaRetails.Forms
{
    partial class ExpensesCategoryForm
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
            this.GBExpenseCategory = new System.Windows.Forms.GroupBox();
            this.TLPExpensesCategory = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.GBExpenseCategory.SuspendLayout();
            this.TLPExpensesCategory.SuspendLayout();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBExpenseCategory
            // 
            this.GBExpenseCategory.AutoSize = true;
            this.GBExpenseCategory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBExpenseCategory.Controls.Add(this.TLPExpensesCategory);
            this.GBExpenseCategory.Location = new System.Drawing.Point(27, 25);
            this.GBExpenseCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBExpenseCategory.Name = "GBExpenseCategory";
            this.GBExpenseCategory.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.GBExpenseCategory.Size = new System.Drawing.Size(336, 157);
            this.GBExpenseCategory.TabIndex = 0;
            this.GBExpenseCategory.TabStop = false;
            this.GBExpenseCategory.Text = "Category";
            // 
            // TLPExpensesCategory
            // 
            this.TLPExpensesCategory.AutoSize = true;
            this.TLPExpensesCategory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPExpensesCategory.ColumnCount = 2;
            this.TLPExpensesCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpensesCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPExpensesCategory.Controls.Add(this.label1, 0, 0);
            this.TLPExpensesCategory.Controls.Add(this.label2, 0, 1);
            this.TLPExpensesCategory.Controls.Add(this.label3, 0, 2);
            this.TLPExpensesCategory.Controls.Add(this.comboBox1, 1, 0);
            this.TLPExpensesCategory.Controls.Add(this.textBox1, 1, 1);
            this.TLPExpensesCategory.Controls.Add(this.comboBox2, 1, 2);
            this.TLPExpensesCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPExpensesCategory.Location = new System.Drawing.Point(11, 36);
            this.TLPExpensesCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPExpensesCategory.Name = "TLPExpensesCategory";
            this.TLPExpensesCategory.RowCount = 3;
            this.TLPExpensesCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpensesCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpensesCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPExpensesCategory.Size = new System.Drawing.Size(314, 109);
            this.TLPExpensesCategory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 2);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 33);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 39);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 31);
            this.textBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(131, 74);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(92, 33);
            this.comboBox2.TabIndex = 5;
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Location = new System.Drawing.Point(1, 303);
            this.GBControls.Margin = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBControls.Size = new System.Drawing.Size(593, 92);
            this.GBControls.TabIndex = 7;
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
            this.BTNAdd.TabIndex = 18;
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
            this.BTNDelete.TabIndex = 19;
            this.BTNDelete.Text = "Delete";
            this.BTNDelete.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.Location = new System.Drawing.Point(265, 4);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(152, 52);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // BTNUpdate
            // 
            this.BTNUpdate.AutoSize = true;
            this.BTNUpdate.Location = new System.Drawing.Point(425, 4);
            this.BTNUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNUpdate.Name = "BTNUpdate";
            this.BTNUpdate.Size = new System.Drawing.Size(156, 52);
            this.BTNUpdate.TabIndex = 21;
            this.BTNUpdate.Text = "Update";
            this.BTNUpdate.UseVisualStyleBackColor = true;
            // 
            // ExpensesCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(595, 456);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.GBExpenseCategory);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ExpensesCategoryForm";
            this.Text = "ExpensesCategoryForm";
            this.GBExpenseCategory.ResumeLayout(false);
            this.GBExpenseCategory.PerformLayout();
            this.TLPExpensesCategory.ResumeLayout(false);
            this.TLPExpensesCategory.PerformLayout();
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBExpenseCategory;
        private System.Windows.Forms.TableLayoutPanel TLPExpensesCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
    }
}