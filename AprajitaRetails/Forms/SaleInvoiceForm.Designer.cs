namespace AprajitaRetails.Forms
{
    partial class SaleInvoiceForm
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
            this.GBInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.TLPInvoiceDetails = new System.Windows.Forms.TableLayoutPanel();
            this.TXTGrandTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBInvoiceNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBMobileNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTFirstName = new System.Windows.Forms.TextBox();
            this.TXTLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTSubTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTTaxAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXTCashAmount = new System.Windows.Forms.TextBox();
            this.TXTCardAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TXTAuthCode = new System.Windows.Forms.TextBox();
            this.BTNNewCustomer = new System.Windows.Forms.Button();
            this.RBDebitCard = new System.Windows.Forms.RadioButton();
            this.RBCreditCard = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TXTFourDigit = new System.Windows.Forms.TextBox();
            this.CBCardType = new System.Windows.Forms.ComboBox();
            this.GBProductDetails = new System.Windows.Forms.GroupBox();
            this.DGVSaleItems = new System.Windows.Forms.DataGridView();
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.GBItemDetails = new System.Windows.Forms.GroupBox();
            this.TLPItemDetails = new System.Windows.Forms.TableLayoutPanel();
            this.TXTBarCode = new System.Windows.Forms.TextBox();
            this.TXTItemDetail = new System.Windows.Forms.TextBox();
            this.TXTQty = new System.Windows.Forms.TextBox();
            this.TXTRate = new System.Windows.Forms.TextBox();
            this.TXTAmount = new System.Windows.Forms.TextBox();
            this.BTNItemAdd = new System.Windows.Forms.Button();
            this.BTNDiscount = new System.Windows.Forms.Button();
            this.TXTItemDiscount = new System.Windows.Forms.TextBox();
            this.GBInvoiceDetails.SuspendLayout();
            this.TLPInvoiceDetails.SuspendLayout();
            this.GBProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleItems)).BeginInit();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.GBItemDetails.SuspendLayout();
            this.TLPItemDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBInvoiceDetails
            // 
            this.GBInvoiceDetails.Controls.Add(this.TLPInvoiceDetails);
            this.GBInvoiceDetails.Location = new System.Drawing.Point(23, 39);
            this.GBInvoiceDetails.Margin = new System.Windows.Forms.Padding(5);
            this.GBInvoiceDetails.Name = "GBInvoiceDetails";
            this.GBInvoiceDetails.Padding = new System.Windows.Forms.Padding(5);
            this.GBInvoiceDetails.Size = new System.Drawing.Size(2014, 412);
            this.GBInvoiceDetails.TabIndex = 0;
            this.GBInvoiceDetails.TabStop = false;
            this.GBInvoiceDetails.Text = "Invoice Details";
            // 
            // TLPInvoiceDetails
            // 
            this.TLPInvoiceDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.TLPInvoiceDetails.ColumnCount = 6;
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.Controls.Add(this.TXTGrandTotal, 3, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label1, 0, 0);
            this.TLPInvoiceDetails.Controls.Add(this.CBInvoiceNo, 1, 0);
            this.TLPInvoiceDetails.Controls.Add(this.label2, 2, 0);
            this.TLPInvoiceDetails.Controls.Add(this.CBMobileNo, 3, 0);
            this.TLPInvoiceDetails.Controls.Add(this.label3, 4, 0);
            this.TLPInvoiceDetails.Controls.Add(this.DTPInvoiceDate, 5, 0);
            this.TLPInvoiceDetails.Controls.Add(this.label4, 0, 1);
            this.TLPInvoiceDetails.Controls.Add(this.TXTFirstName, 1, 1);
            this.TLPInvoiceDetails.Controls.Add(this.TXTLastName, 2, 1);
            this.TLPInvoiceDetails.Controls.Add(this.label5, 0, 2);
            this.TLPInvoiceDetails.Controls.Add(this.TXTSubTotal, 1, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label6, 0, 3);
            this.TLPInvoiceDetails.Controls.Add(this.TXTDiscount, 1, 3);
            this.TLPInvoiceDetails.Controls.Add(this.label7, 0, 4);
            this.TLPInvoiceDetails.Controls.Add(this.TXTTaxAmount, 1, 4);
            this.TLPInvoiceDetails.Controls.Add(this.label8, 2, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label9, 2, 3);
            this.TLPInvoiceDetails.Controls.Add(this.label10, 2, 4);
            this.TLPInvoiceDetails.Controls.Add(this.TXTCashAmount, 3, 3);
            this.TLPInvoiceDetails.Controls.Add(this.TXTCardAmount, 3, 4);
            this.TLPInvoiceDetails.Controls.Add(this.label11, 4, 4);
            this.TLPInvoiceDetails.Controls.Add(this.TXTAuthCode, 5, 4);
            this.TLPInvoiceDetails.Controls.Add(this.BTNNewCustomer, 3, 1);
            this.TLPInvoiceDetails.Controls.Add(this.RBDebitCard, 4, 1);
            this.TLPInvoiceDetails.Controls.Add(this.RBCreditCard, 5, 1);
            this.TLPInvoiceDetails.Controls.Add(this.label12, 4, 3);
            this.TLPInvoiceDetails.Controls.Add(this.label13, 4, 2);
            this.TLPInvoiceDetails.Controls.Add(this.TXTFourDigit, 5, 3);
            this.TLPInvoiceDetails.Controls.Add(this.CBCardType, 5, 2);
            this.TLPInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPInvoiceDetails.Location = new System.Drawing.Point(5, 36);
            this.TLPInvoiceDetails.Margin = new System.Windows.Forms.Padding(5);
            this.TLPInvoiceDetails.Name = "TLPInvoiceDetails";
            this.TLPInvoiceDetails.RowCount = 5;
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPInvoiceDetails.Size = new System.Drawing.Size(2004, 371);
            this.TLPInvoiceDetails.TabIndex = 0;
            // 
            // TXTGrandTotal
            // 
            this.TXTGrandTotal.Location = new System.Drawing.Point(708, 148);
            this.TXTGrandTotal.Margin = new System.Windows.Forms.Padding(5);
            this.TXTGrandTotal.Name = "TXTGrandTotal";
            this.TXTGrandTotal.ReadOnly = true;
            this.TXTGrandTotal.Size = new System.Drawing.Size(239, 38);
            this.TXTGrandTotal.TabIndex = 226;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "InvoiceNo";
            // 
            // CBInvoiceNo
            // 
            this.CBInvoiceNo.FormattingEnabled = true;
            this.CBInvoiceNo.Location = new System.Drawing.Point(240, 8);
            this.CBInvoiceNo.Margin = new System.Windows.Forms.Padding(5);
            this.CBInvoiceNo.Name = "CBInvoiceNo";
            this.CBInvoiceNo.Size = new System.Drawing.Size(222, 39);
            this.CBInvoiceNo.TabIndex = 1;
            this.CBInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.CBInvoiceNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "MobileNo";
            // 
            // CBMobileNo
            // 
            this.CBMobileNo.FormattingEnabled = true;
            this.CBMobileNo.Location = new System.Drawing.Point(708, 8);
            this.CBMobileNo.Margin = new System.Windows.Forms.Padding(5);
            this.CBMobileNo.Name = "CBMobileNo";
            this.CBMobileNo.Size = new System.Drawing.Size(239, 39);
            this.CBMobileNo.TabIndex = 2;
            this.CBMobileNo.SelectedIndexChanged += new System.EventHandler(this.CBMobileNo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(960, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "InvoiceDate";
            // 
            // DTPInvoiceDate
            // 
            this.DTPInvoiceDate.Location = new System.Drawing.Point(1217, 8);
            this.DTPInvoiceDate.Margin = new System.Windows.Forms.Padding(5);
            this.DTPInvoiceDate.Name = "DTPInvoiceDate";
            this.DTPInvoiceDate.Size = new System.Drawing.Size(249, 38);
            this.DTPInvoiceDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Customer Name";
            // 
            // TXTFirstName
            // 
            this.TXTFirstName.Location = new System.Drawing.Point(240, 60);
            this.TXTFirstName.Margin = new System.Windows.Forms.Padding(5);
            this.TXTFirstName.Name = "TXTFirstName";
            this.TXTFirstName.ReadOnly = true;
            this.TXTFirstName.Size = new System.Drawing.Size(222, 38);
            this.TXTFirstName.TabIndex = 112;
            // 
            // TXTLastName
            // 
            this.TXTLastName.Location = new System.Drawing.Point(475, 60);
            this.TXTLastName.Margin = new System.Windows.Forms.Padding(5);
            this.TXTLastName.Name = "TXTLastName";
            this.TXTLastName.ReadOnly = true;
            this.TXTLastName.Size = new System.Drawing.Size(220, 38);
            this.TXTLastName.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total";
            // 
            // TXTSubTotal
            // 
            this.TXTSubTotal.Location = new System.Drawing.Point(240, 148);
            this.TXTSubTotal.Margin = new System.Windows.Forms.Padding(5);
            this.TXTSubTotal.Name = "TXTSubTotal";
            this.TXTSubTotal.ReadOnly = true;
            this.TXTSubTotal.Size = new System.Drawing.Size(222, 38);
            this.TXTSubTotal.TabIndex = 222;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Discount";
            // 
            // TXTDiscount
            // 
            this.TXTDiscount.Location = new System.Drawing.Point(240, 215);
            this.TXTDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTDiscount.Name = "TXTDiscount";
            this.TXTDiscount.ReadOnly = true;
            this.TXTDiscount.Size = new System.Drawing.Size(222, 38);
            this.TXTDiscount.TabIndex = 223;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 283);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tax";
            // 
            // TXTTaxAmount
            // 
            this.TXTTaxAmount.Location = new System.Drawing.Point(240, 288);
            this.TXTTaxAmount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTTaxAmount.Name = "TXTTaxAmount";
            this.TXTTaxAmount.ReadOnly = true;
            this.TXTTaxAmount.Size = new System.Drawing.Size(222, 38);
            this.TXTTaxAmount.TabIndex = 224;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(475, 143);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 32);
            this.label8.TabIndex = 15;
            this.label8.Text = "Grand Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 210);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 32);
            this.label9.TabIndex = 17;
            this.label9.Text = "Cash";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(475, 283);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 32);
            this.label10.TabIndex = 18;
            this.label10.Text = "Card";
            // 
            // TXTCashAmount
            // 
            this.TXTCashAmount.Location = new System.Drawing.Point(708, 215);
            this.TXTCashAmount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTCashAmount.Name = "TXTCashAmount";
            this.TXTCashAmount.Size = new System.Drawing.Size(239, 38);
            this.TXTCashAmount.TabIndex = 8;
            this.TXTCashAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TXTCashAmount_MouseClick);
            this.TXTCashAmount.TextChanged += new System.EventHandler(this.TXTCashAmount_TextChanged);
            // 
            // TXTCardAmount
            // 
            this.TXTCardAmount.Location = new System.Drawing.Point(708, 288);
            this.TXTCardAmount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTCardAmount.Name = "TXTCardAmount";
            this.TXTCardAmount.Size = new System.Drawing.Size(239, 38);
            this.TXTCardAmount.TabIndex = 9;
            this.TXTCardAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TXTCardAmount_MouseClick);
            this.TXTCardAmount.TextChanged += new System.EventHandler(this.TXTCardAmount_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(960, 283);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 32);
            this.label11.TabIndex = 19;
            this.label11.Text = "AuthCode";
            // 
            // TXTAuthCode
            // 
            this.TXTAuthCode.Location = new System.Drawing.Point(1215, 286);
            this.TXTAuthCode.Name = "TXTAuthCode";
            this.TXTAuthCode.Size = new System.Drawing.Size(249, 38);
            this.TXTAuthCode.TabIndex = 15;
            // 
            // BTNNewCustomer
            // 
            this.BTNNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNNewCustomer.AutoSize = true;
            this.BTNNewCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNNewCustomer.Location = new System.Drawing.Point(706, 76);
            this.BTNNewCustomer.Name = "BTNNewCustomer";
            this.BTNNewCustomer.Size = new System.Drawing.Size(243, 42);
            this.BTNNewCustomer.TabIndex = 27;
            this.BTNNewCustomer.Text = "Add Customer";
            this.BTNNewCustomer.UseVisualStyleBackColor = true;
            this.BTNNewCustomer.Click += new System.EventHandler(this.BTNNewCustomer_Click);
            // 
            // RBDebitCard
            // 
            this.RBDebitCard.AutoSize = true;
            this.RBDebitCard.Location = new System.Drawing.Point(960, 60);
            this.RBDebitCard.Margin = new System.Windows.Forms.Padding(5);
            this.RBDebitCard.Name = "RBDebitCard";
            this.RBDebitCard.Size = new System.Drawing.Size(187, 36);
            this.RBDebitCard.TabIndex = 10;
            this.RBDebitCard.TabStop = true;
            this.RBDebitCard.Text = "Debit Card";
            this.RBDebitCard.UseVisualStyleBackColor = true;
            this.RBDebitCard.CheckedChanged += new System.EventHandler(this.RBDebitCard_CheckedChanged);
            // 
            // RBCreditCard
            // 
            this.RBCreditCard.AutoSize = true;
            this.RBCreditCard.Location = new System.Drawing.Point(1217, 60);
            this.RBCreditCard.Margin = new System.Windows.Forms.Padding(5);
            this.RBCreditCard.Name = "RBCreditCard";
            this.RBCreditCard.Size = new System.Drawing.Size(196, 36);
            this.RBCreditCard.TabIndex = 11;
            this.RBCreditCard.TabStop = true;
            this.RBCreditCard.Text = "Credit Card";
            this.RBCreditCard.UseVisualStyleBackColor = true;
            this.RBCreditCard.CheckedChanged += new System.EventHandler(this.RBCreditCard_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(958, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(199, 32);
            this.label12.TabIndex = 25;
            this.label12.Text = "Last Four Digit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(958, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 32);
            this.label13.TabIndex = 28;
            this.label13.Text = "Card Type";
            // 
            // TXTFourDigit
            // 
            this.TXTFourDigit.Location = new System.Drawing.Point(1217, 215);
            this.TXTFourDigit.Margin = new System.Windows.Forms.Padding(5);
            this.TXTFourDigit.Name = "TXTFourDigit";
            this.TXTFourDigit.Size = new System.Drawing.Size(249, 38);
            this.TXTFourDigit.TabIndex = 13;
            // 
            // CBCardType
            // 
            this.CBCardType.FormattingEnabled = true;
            this.CBCardType.Location = new System.Drawing.Point(1215, 146);
            this.CBCardType.Name = "CBCardType";
            this.CBCardType.Size = new System.Drawing.Size(249, 39);
            this.CBCardType.TabIndex = 12;
//            this.CBCardType.SelectedIndexChanged += new System.EventHandler(this.CBCardType_SelectedIndexChanged);
            // 
            // GBProductDetails
            // 
            this.GBProductDetails.Controls.Add(this.DGVSaleItems);
            this.GBProductDetails.Location = new System.Drawing.Point(23, 489);
            this.GBProductDetails.Margin = new System.Windows.Forms.Padding(5);
            this.GBProductDetails.Name = "GBProductDetails";
            this.GBProductDetails.Padding = new System.Windows.Forms.Padding(5);
            this.GBProductDetails.Size = new System.Drawing.Size(2014, 325);
            this.GBProductDetails.TabIndex = 1;
            this.GBProductDetails.TabStop = false;
            this.GBProductDetails.Text = "Product Details";
            // 
            // DGVSaleItems
            // 
            this.DGVSaleItems.AllowUserToAddRows = false;
            this.DGVSaleItems.AllowUserToOrderColumns = true;
            this.DGVSaleItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DGVSaleItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DGVSaleItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSaleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSaleItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVSaleItems.Location = new System.Drawing.Point(5, 36);
            this.DGVSaleItems.Margin = new System.Windows.Forms.Padding(5);
            this.DGVSaleItems.Name = "DGVSaleItems";
            this.DGVSaleItems.RowTemplate.Height = 28;
            this.DGVSaleItems.Size = new System.Drawing.Size(2004, 284);
            this.DGVSaleItems.TabIndex = 0;
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBControls.Location = new System.Drawing.Point(0, 923);
            this.GBControls.Margin = new System.Windows.Forms.Padding(5);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(5);
            this.GBControls.Size = new System.Drawing.Size(2059, 116);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 36);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(2049, 75);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // BTNAdd
            // 
            this.BTNAdd.AutoSize = true;
            this.BTNAdd.Location = new System.Drawing.Point(5, 5);
            this.BTNAdd.Margin = new System.Windows.Forms.Padding(5);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(135, 65);
            this.BTNAdd.TabIndex = 16;
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
            this.BTNDelete.TabIndex = 17;
            this.BTNDelete.Text = "Delete";
            this.BTNDelete.UseVisualStyleBackColor = true;
            this.BTNDelete.Click += new System.EventHandler(this.BTNDelete_Click);
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.Location = new System.Drawing.Point(352, 5);
            this.Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(203, 65);
            this.Cancel.TabIndex = 18;
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
            this.BTNUpdate.TabIndex = 19;
            this.BTNUpdate.Text = "Update";
            this.BTNUpdate.UseVisualStyleBackColor = true;
            // 
            // GBItemDetails
            // 
            this.GBItemDetails.AutoSize = true;
            this.GBItemDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBItemDetails.Controls.Add(this.TLPItemDetails);
            this.GBItemDetails.Location = new System.Drawing.Point(23, 823);
            this.GBItemDetails.Name = "GBItemDetails";
            this.GBItemDetails.Size = new System.Drawing.Size(1621, 91);
            this.GBItemDetails.TabIndex = 6;
            this.GBItemDetails.TabStop = false;
            this.GBItemDetails.Text = "Item Details";
            // 
            // TLPItemDetails
            // 
            this.TLPItemDetails.AutoSize = true;
            this.TLPItemDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPItemDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.TLPItemDetails.ColumnCount = 8;
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPItemDetails.Controls.Add(this.TXTBarCode, 0, 0);
            this.TLPItemDetails.Controls.Add(this.TXTItemDetail, 1, 0);
            this.TLPItemDetails.Controls.Add(this.TXTQty, 2, 0);
            this.TLPItemDetails.Controls.Add(this.TXTRate, 3, 0);
            this.TLPItemDetails.Controls.Add(this.TXTAmount, 4, 0);
            this.TLPItemDetails.Controls.Add(this.BTNItemAdd, 6, 0);
            this.TLPItemDetails.Controls.Add(this.BTNDiscount, 7, 0);
            this.TLPItemDetails.Controls.Add(this.TXTItemDiscount, 5, 0);
            this.TLPItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPItemDetails.Location = new System.Drawing.Point(3, 34);
            this.TLPItemDetails.Name = "TLPItemDetails";
            this.TLPItemDetails.RowCount = 1;
            this.TLPItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPItemDetails.Size = new System.Drawing.Size(1615, 54);
            this.TLPItemDetails.TabIndex = 0;
            // 
            // TXTBarCode
            // 
            this.TXTBarCode.AccessibleName = "BarCode";
            this.TXTBarCode.Location = new System.Drawing.Point(6, 6);
            this.TXTBarCode.Name = "TXTBarCode";
            this.TXTBarCode.Size = new System.Drawing.Size(276, 38);
            this.TXTBarCode.TabIndex = 4;
            this.TXTBarCode.Tag = "Bar Code";
            this.TXTBarCode.TextChanged += new System.EventHandler(this.TXTBarCode_TextChanged);
            // 
            // TXTItemDetail
            // 
            this.TXTItemDetail.ForeColor = System.Drawing.Color.Red;
            this.TXTItemDetail.Location = new System.Drawing.Point(291, 6);
            this.TXTItemDetail.Name = "TXTItemDetail";
            this.TXTItemDetail.ReadOnly = true;
            this.TXTItemDetail.Size = new System.Drawing.Size(325, 38);
            this.TXTItemDetail.TabIndex = 1;
            this.TXTItemDetail.Tag = "Item Details";
            // 
            // TXTQty
            // 
            this.TXTQty.Location = new System.Drawing.Point(625, 6);
            this.TXTQty.Name = "TXTQty";
            this.TXTQty.Size = new System.Drawing.Size(136, 38);
            this.TXTQty.TabIndex = 6;
            this.TXTQty.Tag = "Qty";
            this.TXTQty.TextChanged += new System.EventHandler(this.TXTQty_TextChanged);
            // 
            // TXTRate
            // 
            this.TXTRate.Location = new System.Drawing.Point(770, 6);
            this.TXTRate.Name = "TXTRate";
            this.TXTRate.ReadOnly = true;
            this.TXTRate.Size = new System.Drawing.Size(197, 38);
            this.TXTRate.TabIndex = 3;
            this.TXTRate.Tag = "Rate";
            // 
            // TXTAmount
            // 
            this.TXTAmount.Location = new System.Drawing.Point(976, 6);
            this.TXTAmount.Name = "TXTAmount";
            this.TXTAmount.ReadOnly = true;
            this.TXTAmount.Size = new System.Drawing.Size(197, 38);
            this.TXTAmount.TabIndex = 4;
            this.TXTAmount.Tag = "Amount";
            // 
            // BTNItemAdd
            // 
            this.BTNItemAdd.AutoSize = true;
            this.BTNItemAdd.Location = new System.Drawing.Point(1388, 6);
            this.BTNItemAdd.Name = "BTNItemAdd";
            this.BTNItemAdd.Size = new System.Drawing.Size(76, 42);
            this.BTNItemAdd.TabIndex = 7;
            this.BTNItemAdd.Text = "Add";
            this.BTNItemAdd.UseVisualStyleBackColor = true;
            this.BTNItemAdd.Click += new System.EventHandler(this.BTNItemAdd_Click);
            // 
            // BTNDiscount
            // 
            this.BTNDiscount.AutoSize = true;
            this.BTNDiscount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTNDiscount.Location = new System.Drawing.Point(1473, 6);
            this.BTNDiscount.Name = "BTNDiscount";
            this.BTNDiscount.Size = new System.Drawing.Size(136, 42);
            this.BTNDiscount.TabIndex = 8;
            this.BTNDiscount.Text = "Discount";
            this.BTNDiscount.UseVisualStyleBackColor = true;
            this.BTNDiscount.Click += new System.EventHandler(this.BTNDiscount_Click);
            // 
            // TXTItemDiscount
            // 
            this.TXTItemDiscount.Location = new System.Drawing.Point(1182, 6);
            this.TXTItemDiscount.Name = "TXTItemDiscount";
            this.TXTItemDiscount.ReadOnly = true;
            this.TXTItemDiscount.Size = new System.Drawing.Size(197, 38);
            this.TXTItemDiscount.TabIndex = 9;
            this.TXTItemDiscount.Text = "0.0";
            // 
            // SaleInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2059, 1039);
            this.Controls.Add(this.GBItemDetails);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.GBProductDetails);
            this.Controls.Add(this.GBInvoiceDetails);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SaleInvoiceForm";
            this.Text = "Manual Sale Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.SaleInvoiceForm_Activated);
            this.Load += new System.EventHandler(this.SaleInvoiceForm_Load);
            this.Shown += new System.EventHandler(this.SaleInvoiceForm_Shown);
            this.GBInvoiceDetails.ResumeLayout(false);
            this.TLPInvoiceDetails.ResumeLayout(false);
            this.TLPInvoiceDetails.PerformLayout();
            this.GBProductDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleItems)).EndInit();
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.GBItemDetails.ResumeLayout(false);
            this.GBItemDetails.PerformLayout();
            this.TLPItemDetails.ResumeLayout(false);
            this.TLPItemDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBInvoiceDetails;
        private System.Windows.Forms.TableLayoutPanel TLPInvoiceDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBInvoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBMobileNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPInvoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTFirstName;
        private System.Windows.Forms.TextBox TXTLastName;
        private System.Windows.Forms.GroupBox GBProductDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTSubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTTaxAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTGrandTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TXTCashAmount;
        private System.Windows.Forms.TextBox TXTFourDigit;
        private System.Windows.Forms.TextBox TXTCardAmount;
        private System.Windows.Forms.RadioButton RBDebitCard;
        private System.Windows.Forms.RadioButton RBCreditCard;
        private System.Windows.Forms.DataGridView DGVSaleItems;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TXTAuthCode;
        private System.Windows.Forms.Button BTNNewCustomer;
        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CBCardType;
        private System.Windows.Forms.GroupBox GBItemDetails;
        private System.Windows.Forms.TableLayoutPanel TLPItemDetails;
        private System.Windows.Forms.TextBox TXTBarCode;
        private System.Windows.Forms.TextBox TXTItemDetail;
        private System.Windows.Forms.TextBox TXTQty;
        private System.Windows.Forms.TextBox TXTRate;
        private System.Windows.Forms.TextBox TXTAmount;
        private System.Windows.Forms.Button BTNItemAdd;
        private System.Windows.Forms.Button BTNDiscount;
        private System.Windows.Forms.TextBox TXTItemDiscount;
    }
}