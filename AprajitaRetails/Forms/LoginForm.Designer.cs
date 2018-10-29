namespace AprajitaRetails
{
    partial class LoginForm
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
            this.GBLogin = new System.Windows.Forms.GroupBox();
            this.LBStoreCity = new System.Windows.Forms.Label();
            this.LBStoreName = new System.Windows.Forms.Label();
            this.TLPLoginControls = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PBLogo = new System.Windows.Forms.PictureBox();
            this.splashControl1 = new Syncfusion.Windows.Forms.Tools.SplashControl();
            this.GBLogin.SuspendLayout();
            this.TLPLoginControls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // GBLogin
            // 
            this.GBLogin.AutoSize = true;
            this.GBLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBLogin.Controls.Add(this.LBStoreCity);
            this.GBLogin.Controls.Add(this.LBStoreName);
            this.GBLogin.Controls.Add(this.TLPLoginControls);
            this.GBLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBLogin.Location = new System.Drawing.Point(0, 311);
            this.GBLogin.Margin = new System.Windows.Forms.Padding(2);
            this.GBLogin.Name = "GBLogin";
            this.GBLogin.Padding = new System.Windows.Forms.Padding(2);
            this.GBLogin.Size = new System.Drawing.Size(873, 297);
            this.GBLogin.TabIndex = 0;
            this.GBLogin.TabStop = false;
            this.GBLogin.Text = "Login";
            this.GBLogin.Enter += new System.EventHandler(this.GBLogin_Enter);
            // 
            // LBStoreCity
            // 
            this.LBStoreCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBStoreCity.AutoSize = true;
            this.LBStoreCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBStoreCity.ForeColor = System.Drawing.Color.Red;
            this.LBStoreCity.Location = new System.Drawing.Point(171, 118);
            this.LBStoreCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBStoreCity.Name = "LBStoreCity";
            this.LBStoreCity.Size = new System.Drawing.Size(445, 31);
            this.LBStoreCity.TabIndex = 2;
            this.LBStoreCity.Text = "The Arvind Store, Dumka(JH006)";
            this.LBStoreCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBStoreName
            // 
            this.LBStoreName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBStoreName.AutoSize = true;
            this.LBStoreName.Font = new System.Drawing.Font("Segoe Print", 15.9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBStoreName.ForeColor = System.Drawing.Color.DarkRed;
            this.LBStoreName.Location = new System.Drawing.Point(208, 28);
            this.LBStoreName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBStoreName.Name = "LBStoreName";
            this.LBStoreName.Size = new System.Drawing.Size(369, 76);
            this.LBStoreName.TabIndex = 1;
            this.LBStoreName.Text = "Aprajita Retails";
            this.LBStoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPLoginControls
            // 
            this.TLPLoginControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPLoginControls.AutoScroll = true;
            this.TLPLoginControls.AutoSize = true;
            this.TLPLoginControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPLoginControls.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.TLPLoginControls.ColumnCount = 2;
            this.TLPLoginControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPLoginControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPLoginControls.Controls.Add(this.label2, 0, 1);
            this.TLPLoginControls.Controls.Add(this.btnLogin, 0, 2);
            this.TLPLoginControls.Controls.Add(this.btnCancel, 1, 2);
            this.TLPLoginControls.Controls.Add(this.txtUserName, 1, 0);
            this.TLPLoginControls.Controls.Add(this.txtPassword, 1, 1);
            this.TLPLoginControls.Controls.Add(this.label1, 0, 0);
            this.TLPLoginControls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TLPLoginControls.Location = new System.Drawing.Point(216, 160);
            this.TLPLoginControls.Margin = new System.Windows.Forms.Padding(2);
            this.TLPLoginControls.Name = "TLPLoginControls";
            this.TLPLoginControls.Padding = new System.Windows.Forms.Padding(8);
            this.TLPLoginControls.RowCount = 3;
            this.TLPLoginControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPLoginControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPLoginControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPLoginControls.Size = new System.Drawing.Size(344, 137);
            this.TLPLoginControls.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.AutoSize = true;
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.Location = new System.Drawing.Point(49, 89);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(77, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Location = new System.Drawing.Point(133, 89);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(133, 13);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(198, 31);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(133, 51);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(198, 31);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "admin";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.PBLogo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(873, 311);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // PBLogo
            // 
            this.PBLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBLogo.Image = global::AprajitaRetails.Properties.Resources.logo;
            this.PBLogo.Location = new System.Drawing.Point(2, 26);
            this.PBLogo.Margin = new System.Windows.Forms.Padding(2);
            this.PBLogo.Name = "PBLogo";
            this.PBLogo.Size = new System.Drawing.Size(869, 283);
            this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBLogo.TabIndex = 2;
            this.PBLogo.TabStop = false;
            // 
            // splashControl1
            // 
            this.splashControl1.CloseSplashForm = true;
            this.splashControl1.HostForm = this;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(907, 582);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(933, 653);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.GBLogin.ResumeLayout(false);
            this.GBLogin.PerformLayout();
            this.TLPLoginControls.ResumeLayout(false);
            this.TLPLoginControls.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLPLoginControls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label LBStoreCity;
        private System.Windows.Forms.Label LBStoreName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PBLogo;
        private Syncfusion.Windows.Forms.Tools.SplashControl splashControl1;
    }
}