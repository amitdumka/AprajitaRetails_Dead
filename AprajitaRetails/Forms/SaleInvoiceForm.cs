using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AprajitaRetails.ViewModel;
using AprajitaRetails.Printers;


namespace AprajitaRetails.Forms
{
    public partial class SaleInvoiceForm : Form
    {
        private int ItemID = 0;
        private DataTable itemTable;
        private SaleInvoiceVM sVM;
        private BindingSource vBsource = new BindingSource ();
        int vCustId = -1;
        double vGrandTotal = 0.0;
        bool vIsNew = false;
        private ProductItems vItem;
        private DataTable vItemTable;
        SalePayMode vPayMode = SalePayMode.Cash;

        double vRoundOffAmt = 0.0;
        double vTotalAmount = 0.0;
        double vTotalDiscount = 0.0;
        int vTotalItems = 0;
        double vTotalQty = 0;
        double vTotalRoundOff = 0.0;
        double vTotalTax = 0.0;
        double vTotalGST = 0.0;
        //Recipt Printing Delcartation
        bool wantToPrint = true;
        ReceiptFooter vReciptFooter;
        ReceiptHeader vReciptHeader;
        ReceiptDetails vReciptDetails;
        List<ReceiptItemDetails> vReciptItems;
        ReceiptItemTotal vReciptItemTotal;
        const int MinimumSize = 10;
        private int CurrentSize = MinimumSize;
        int ItemCount = 0;
        /// <summary>
        /// Reset of variable which controls UI and Data
        /// </summary>
        private void ResetVariables()
        {
            ItemID = 0;
            vCustId = -1;
            vGrandTotal = 0.0;
            vIsNew = false;
            vPayMode = SalePayMode.Cash;
            vRoundOffAmt = 0.0;
            vTotalAmount = 0.0;
            vTotalDiscount = 0.0;
            vTotalItems = 0;
            vTotalQty = 0;
            vTotalRoundOff = 0.0;
            vTotalTax = 0.0;
            vTotalGST = 0.0;
            wantToPrint = true;
            CurrentSize = MinimumSize;
            ItemCount = 0;
        }
        public SaleInvoiceForm()
        {
            InitializeComponent ();
            //sVM = new SaleInvoiceVM ();
            //itemTable = new DataTable ();
        }
        private void AddPrintInvoiceTotalItem()
        {   //TODO: Recipt Printer Do it First

        }
        private void AddItemRow()
        {
            if ( vItem != null )
            {
                string vBarcode = TXTBarCode.Text;
                string vQty = TXTQty.Text;
                string vAmount = TXTAmount.Text;
                DataTable dt = ( DGVSaleItems.DataSource as BindingSource ).DataSource as DataTable;
                DataRow nRow = dt.NewRow ();
                double vAmtd = double.Parse (vAmount);
                double vAmtWhole = Math.Round (vAmtd);
                vRoundOffAmt = vAmtWhole - vAmtd;
                double vDiscount = double.Parse (TXTItemDiscount.Text.Trim ());
                //ID, InvoiceNo, ItemCode, BarCode, StyleCode,  Qty, Rate, Discount, Tax, Amount         
                nRow [0] = ( ++ItemID );
                nRow [1] = CBInvoiceNo.Text;
                nRow [2] = vItem.ID;
                nRow [3] = vBarcode;
                nRow [4] = vItem.StyleCode;
                nRow [5] = vQty;
                nRow [6] = vItem.MRP;
                nRow [7] = vDiscount;
                nRow [8] = vItem.Tax; //TODO: GST ChangesTax need to update
                nRow [9] = double.Parse (vAmount);
                nRow [10] = "SM001";
                dt.Rows.Add (nRow);


                vTotalItems++;
                vTotalQty = vTotalQty + double.Parse (vQty);

                //Total Section 
                vTotalRoundOff += vRoundOffAmt;
                vTotalAmount += vAmtWhole;
                vTotalTax += vItem.Tax;
                vTotalDiscount += vDiscount;
                vGrandTotal = vTotalAmount + vTotalTax - vTotalDiscount;
                //Update UI
                TXTGrandTotal.Text = "" + vGrandTotal;
                TXTTaxAmount.Text = "" + vTotalTax;
                TXTDiscount.Text = "" + vTotalDiscount;
                TXTSubTotal.Text = "" + vTotalAmount;
                double gstRate = 0.00;
                double basicrate = 0.00;
                double gstAmount = 0.00;
                if ( vItem.Tax > 0 )
                {
                    gstRate = 5.00;
                }
                else
                {       //TODO: make 1000 as readable from GST Table and parameterised and make cosnt vairable while load app
                    if ( vItem.MRP <= 1000 || double.Parse (vAmount) <= 1000 )
                    {
                        gstRate = 5.00;
                    }
                    else
                    {
                        gstRate = 12.00;
                    }
                }
                basicrate = double.Parse (vAmount) / ( 1 + ( gstRate / 100 ) );
                gstAmount = ( basicrate * gstRate / 100 ) / 2;

                vReciptItems.Add(  new ReceiptItemDetails ()
                {       //TODO: Need to Implement GST  and Make Int/Double
                    QTY = vQty,
                    Discount = "" + vDiscount,
                    MRP = "" + vItem.MRP,
                    SKU_Description = vItem.Barcode + " / " + vItem.ItemDesc,
                    HSN = "00000000",
                    GSTAmount = "" + Math.Round (( gstAmount ), 2),
                    BasicPrice = "" + Math.Round (basicrate, 2),
                    GSTPercentage = "" + Math.Round (( gstRate / 2 ), 2)
                } );
                vTotalGST += gstAmount;//TODO: GST Update
                ItemCount++; //Incrementing InvoiceCount.

                Basic.ClearUIFields (TLPItemDetails);
            }
        }
        // Mouse Click Operation
        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if ( BTNAdd.Text == "Add" )
            {
                PerformAdd ();
                InitPrintInvoice ();//Init Print Serive
            }
            else if ( BTNAdd.Text == "Save" )
            {
                PerformSave ();
            }
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            //TODO: Implement delete
        }

        private void BTNDiscount_Click(object sender, EventArgs e)
        {
            //TODO: Implement Discount
              
            PdfPrinter.PrintRecipts ();
        }

        private void BTNItemAdd_Click(object sender, EventArgs e)
        {
            if ( Basic.ValidateFormUI (TLPItemDetails) )
                AddItemRow ();
        }

        private void BTNNewCustomer_Click(object sender, EventArgs e)
        {
            //TODO: when MobileNo is added to text , disable  field change event
            CustomersForm c = new CustomersForm ()
            {
                IsDailog = true
            };
            DialogResult r = c.ShowDialog ();
            if ( c.DialogResult == DialogResult.OK )
            {
                TXTFirstName.Text = c.CustomerFirstName;
                TXTLastName.Text = c.CustomerLastName;
                CBMobileNo.Items.Add (c.CustomerMobileNo);
                CBMobileNo.Text = c.CustomerMobileNo;
            }
            c.Dispose ();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Basic.ClearUIFields (TLPInvoiceDetails);
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }
        //End of Mouse Click Operations


        private void GetItemDetais(string barCode)
        {
            vItem = sVM.GetProductItemDetais (barCode);
            if ( vItem != null )
            {
                TXTItemDetail.Text = vItem.ItemDesc;// ["ItemDetail"];
                TXTRate.Text = "" + vItem.MRP;// ["MRP"];
                TXTQty.Text = "" + vItem.Qty;//["Qty"];
            }
        }

        private DataTable GetTableReady()
        {
            DataTable vsItemTable = new DataTable ("SaleDetails");
            vsItemTable.Columns.Add ("ID", typeof (int));
            vsItemTable.Columns.Add ("InvoiceNo", typeof (string));
            vsItemTable.Columns.Add ("ItemCode", typeof (int));
            vsItemTable.Columns.Add ("BarCode", typeof (string));
            vsItemTable.Columns.Add ("StyleCode", typeof (string));
            vsItemTable.Columns.Add ("QTY", typeof (double));
            vsItemTable.Columns.Add ("MRP", typeof (double));
            vsItemTable.Columns.Add ("Discount", typeof (double));
            vsItemTable.Columns.Add ("Tax", typeof (double));
            vsItemTable.Columns.Add ("Amount", typeof (double));
            vItemTable.Columns.Add ("Salesman", typeof (string));

            return vsItemTable;
            //vBsource.DataSource = vItemTable;
            // DGVSaleItems.DataSource = vBsource;
            //DGVSaleItems.Columns [0].Visible = false;
            //DGVSaleItems.Columns [1].Visible = false;

            //DGVSaleItems.Columns [2].Visible = false;
            //DGVSaleItems.Columns [6].Visible = false;
            //ID, InvoiceNo, ItemCode, BarCode, StyleCode,  Qty, Rate, Discount, Tax, Amount
        }
        private void LoadCardTypes()
        {
            Basic.AddListToComboBox (CBCardType, Basic.FeildList (typeof (CardType)));
        }

        private void LoadInvoiceNoList()
        {
            sVM.GetInvoiceNoList (CBInvoiceNo);
        }

        private void LoadMobileNoList()
        {
            sVM.GetCustomerMobileNoList (CBMobileNo);
        }

        private void LoadUiElements()
        {
            LoadInvoiceNoList ();
            LoadMobileNoList ();
            LoadCardTypes ();
            MakeTableReady ();
        }

        private void MakeTableReady()
        {
            vItemTable = new DataTable ("SaleDetails");
            vItemTable.Columns.Add ("ID", typeof (int));
            vItemTable.Columns.Add ("InvoiceNo", typeof (string));
            vItemTable.Columns.Add ("ItemCode", typeof (int));
            vItemTable.Columns.Add ("BarCode", typeof (string));
            vItemTable.Columns.Add ("StyleCode", typeof (string));
            vItemTable.Columns.Add ("QTY", typeof (double));
            vItemTable.Columns.Add ("MRP", typeof (double));
            vItemTable.Columns.Add ("Discount", typeof (double));
            vItemTable.Columns.Add ("Tax", typeof (double));
            vItemTable.Columns.Add ("Amount", typeof (double));
            vItemTable.Columns.Add ("Salesman", typeof (string));
            //vItemTable.Columns.Add ("Date", typeof (DateTime));

            vBsource.DataSource = vItemTable;
            DGVSaleItems.DataSource = vBsource;
            DGVSaleItems.Columns [0].Visible = false;
            DGVSaleItems.Columns [1].Visible = false;

            DGVSaleItems.Columns [2].Visible = false;
            //DGVSaleItems.Columns [6].Visible = false;
            //ID, InvoiceNo, ItemCode, BarCode, StyleCode,  Qty, Rate, Discount, Tax, Amount
        }

        private void PerformAdd()
        {
            vIsNew = true;
            BTNAdd.Text = "Save";
            CBInvoiceNo.Text = sVM.GenerateInvoiceNo ().ToString ();
        }

        private void ResetForm()
        {
            Basic.ClearUIFields (TLPInvoiceDetails);
            // DGVSaleItems.Rows.Clear ();
            DataTable dt = ( DGVSaleItems.DataSource as BindingSource ).DataSource as DataTable;
            dt.Clear ();
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
            ResetVariables ();
        }
        private void PerformSave()
        {
            if ( ValidateInvoice () && ValidateSaleItems () )
            {

                //TODO: make it work
                int status = ReadAllData ();
                if ( status > 0 )
                {
                    vIsNew = false;
                    BTNAdd.Text = "Add";
                    ResetForm ();
                    if ( wantToPrint )
                    {
                        vReciptDetails.BillDate = DTPInvoiceDate.Value.ToShortDateString ();
                        vReciptDetails.BillTime = DTPInvoiceDate.Value.ToShortTimeString ();
                        vReciptDetails.BillNo = "Bill No: " + CBInvoiceNo.Text;
                        vReciptItemTotal.ItemCount = "" + ItemCount;
                        vReciptItemTotal.TotalItem = "" + vTotalQty;
                        vReciptItemTotal.NetAmount = "" + vTotalAmount;
                        vReciptItemTotal.CashAmount = "" + vTotalAmount;
                        PrintRecipts ();
                    }
                    ResetVariables ();
                }
                MessageBox.Show ("Invoice is saved: " + status);

            }
            else
            {
                //TODO: make it two step 
                MessageBox.Show ("Kindly Enter Proper details and try again");
            }

        }
        //Validation
        private bool ValidateSaleItems()
        {
            DataTable dt = ( DGVSaleItems.DataSource as BindingSource ).DataSource as DataTable;

            if ( dt.Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool ValidateInvoice()
        {
            if ( CBInvoiceNo.Text == "" )
            {
                CBInvoiceNo.Focus ();
                MessageBox.Show ("Invoice No has not been generated, kindly enter Invoice No");
                return false;
            }
            if ( CBMobileNo.Text == "" || TXTFirstName.Text == "" )
            {
                CBMobileNo.Focus ();
                MessageBox.Show ("Kindly enter Customer Details");
                return false;
            }
            if ( RBDebitCard.Checked || RBCreditCard.Checked )
            {
                if ( TXTCardAmount.Text == "" )
                {
                    TXTCardAmount.Focus ();
                    MessageBox.Show ("Enter Card Amount");
                    return false;
                }
                if ( TXTAuthCode.Text == "" )
                {
                    TXTAuthCode.Focus ();
                    MessageBox.Show ("Enter AuthCode");
                    return false;

                }
                if ( TXTFourDigit.Text == "" )
                {
                    TXTFourDigit.Focus ();
                    MessageBox.Show ("Enter Card Last Four Digit");
                    return false;

                }
                if ( CBCardType.Text == "" )
                {
                    CBCardType.Focus ();
                    MessageBox.Show ("Select Card type");
                    return false;
                }
            }
            else if(TXTCashAmount.Text=="")
            {
                TXTCashAmount.Focus ();
                MessageBox.Show ("Enter Cash Amount");
                return false;
            }
            return true;
        }

        //End of Validation 
        //Saving All Data to Database
        private int SaveAllData(SaleInvoice inv, SalePaymentDetails payments, DataTable saleItemDataTable)
        {
            return sVM.SaveInvoiceData (inv, saleItemDataTable, payments);

        }
        //Reading data for Entry

        private int ReadAllData()
        {
            SaleInvoice inv = ReadSaleInvoiceFeilds ();
            SalePaymentDetails payment = ReadPaymentDetails ();
            DataTable saleitems = ( DGVSaleItems.DataSource as BindingSource ).DataSource as DataTable;

            if ( inv != null && payment != null && saleitems != null )
                return SaveAllData (inv, payment, saleitems);
            else
                return -1;


        }

        /**
         * ReadSaleInvoiceFeilds
         * 
         * Read Sale Invoice Details
         */
        private SaleInvoice ReadSaleInvoiceFeilds()
        {
            SaleInvoice inv = new SaleInvoice ()
            {
                ID = -1,
                InvoiceNo = CBInvoiceNo.Text,
                OnDate = DTPInvoiceDate.Value,
                TotalBillAmount = double.Parse (TXTGrandTotal.Text),
                TotalDiscountAmount = double.Parse (TXTDiscount.Text),
                TotalTaxAmount = double.Parse (TXTTaxAmount.Text),
                TotalItems = vTotalItems,
                TotalQty = vTotalQty,
                RoundOffAmount = vRoundOffAmt,
                CustomerId = vCustId

            };
            return inv;
        }

        private int GetPaymentMode()
        {
            double cashA = Double.Parse (TXTCashAmount.Text);
            double cardA = Double.Parse (TXTCardAmount.Text);
            if ( vPayMode == SalePayMode.Cash && cashA > 0 && cardA == 0 )
            {
                return 1;
            }
            if ( vPayMode == SalePayMode.Card && cardA > 0 && cashA == 0 )
            {
                return 2;
            }
            if ( vPayMode == SalePayMode.Mix && cashA > 0 && cardA > 0 )
            {
                return 3;
            }

            return -1;//For cash
                      //TODO: Implement Mode of payment. Table is there
        }
        private int GetCardType(string cardType)
        {
            return ( 1 + Basic.FeildList (typeof (CardType)).IndexOf (cardType) );
        }
        private CardPaymentDetails ReadCardDetails()
        {
            CardPaymentDetails cardDetails = new CardPaymentDetails ()
            {
                ID = -1,
                Amount = Double.Parse (TXTCardAmount.Text),
                AuthCode = Int32.Parse (TXTAuthCode.Text),
                CardType = GetCardType (CBCardType.Text),
                InvoiceNo = CBInvoiceNo.Text,
                LastDigit = Int32.Parse (TXTFourDigit.Text)

            };
            return cardDetails;
        }
        private SalePaymentDetails ReadPaymentDetails()
        {
            SalePaymentDetails payDetails = new SalePaymentDetails ()
            {
                ID = -1,
                CardAmount = double.Parse (TXTCardAmount.Text),
                CashAmount = double.Parse (TXTCashAmount.Text),
                InvoiceNo = CBInvoiceNo.Text,
                PayMode = GetPaymentMode (),
                CardDetails = null
            };
            if ( vPayMode == SalePayMode.Card || vPayMode == SalePayMode.Mix )
                payDetails.CardDetails = ReadCardDetails ();
            return payDetails;

        }
        //End of Reading Data for Entry
        //Startup Code
        private void SaleInvoiceForm_Activated(object sender, EventArgs e)
        {
            sVM = new SaleInvoiceVM ();
            itemTable = new DataTable ();
        }

        private void SaleInvoiceForm_Load(object sender, EventArgs e)
        {
            // LoadUiElements ();
        }

        private void SaleInvoiceForm_Shown(object sender, EventArgs e)
        {
            LoadUiElements ();

        }

        private void ShowDVGData()
        {         //TODO: ShowDVGData
        }
        //End of Startup Code
        // Events and Events Trigger functions
        private void CBInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Urgently Display Invoice Details
            //UpdateSaleUI (CBInvoiceNo.Text);
        }

        private void CBMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCustomerField (sVM.GetCustomerInfo (CBMobileNo.Text));
        }

        private void RBCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if ( RBDebitCard.Checked || RBCreditCard.Checked )
            {
                TXTCardAmount.Text = TXTGrandTotal.Text;
                TXTCashAmount.Text = "0.0";
                vPayMode = SalePayMode.Card;
            }
        }

        private void RBDebitCard_CheckedChanged(object sender, EventArgs e)
        {
            if ( RBDebitCard.Checked || RBCreditCard.Checked )
            {
                TXTCardAmount.Text = TXTGrandTotal.Text;
                TXTCashAmount.Text = "0.0";
                vPayMode = SalePayMode.Card;
            }
        }

        private void TXTBarCode_TextChanged(object sender, EventArgs e)
        {
            // TODO: Check Constrainst so that only select Barcode will go
            if ( TXTBarCode.Text.Length >= 10 )
                GetItemDetais (TXTBarCode.Text);
            TXTItemDiscount.Text = "0.00";
        }

        private void TXTCardAmount_MouseClick(object sender, MouseEventArgs e)
        {
            TXTCardAmount.Text = TXTGrandTotal.Text;
            TXTCashAmount.Text = "0";
            vPayMode = SalePayMode.Cash;
        }

        private void TXTCardAmount_TextChanged(object sender, EventArgs e)
        {
            //   TXTCardAmount.Text = TXTGrandTotal.Text;
            //   TXTCashAmount.Text = "0";
            //  vPayMode = "Card";
        }
        private void TXTCashAmount_MouseClick(object sender, MouseEventArgs e)
        {
            TXTCashAmount.Text = TXTGrandTotal.Text;
            TXTCardAmount.Text = "0";
            vPayMode = SalePayMode.Cash;
            RBCreditCard.Checked = false;
            RBDebitCard.Checked = false;
        }

        private void TXTCashAmount_TextChanged(object sender, EventArgs e)
        {
            //TXTCashAmount.Text = TXTGrandTotal.Text;
            //TXTCardAmount.Text = "0";
            //vPayMode = "Cash";
            //TODO: check and update for mix payment
        }

        private void TXTQty_TextChanged(object sender, EventArgs e)
        {

            if ( Basic.IsDecimal (TXTQty.Text) )
            {
                double qty = double.Parse (TXTQty.Text);
                if ( qty <= vItem.Qty )
                {
                    double rate = double.Parse (TXTRate.Text);
                    double amts = rate * qty;
                    TXTAmount.Text = String.Format ("{0}", amts);
                }
                else
                {
                    TXTQty.Text = "" + vItem.Qty;

                    MessageBox.Show ("Quantity should be equal or lesser than " + vItem.Qty);
                }
            }


        }

        private void CBPrintButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            if ( cb.Checked )
            {
                cb.Text = "Print Invoice On";
                wantToPrint = true;
            }
            if ( !cb.Checked )
            {
                cb.Text = "Print Invoice Off";
                wantToPrint = false;
            }
        }

        // end of Events and Events Trigger functions

        // UI Update and refresh Section
        private void UpdateCustomerField(SortedDictionary<string, string> cinfo)
        {
            if ( cinfo != null && cinfo.Count > 0 )
            {
                SortedDictionary<string, string> cust = cinfo;
                TXTFirstName.Text = cust ["FirstName"];
                TXTLastName.Text = cust ["LastName"];
                vCustId = Basic.ToInt (cust ["ID"]);
                this.vReciptDetails.CustomerName = cust ["FirstName"] + cust ["LastName"];
            }
        }
        private void UpdateSaleUI(string invoiceNo)
        {
            SortedDictionary<string, string> saleInfo = sVM.GetInvoiceDetails (invoiceNo);
            if ( saleInfo != null && saleInfo.Count > 0 )
            {
                CBMobileNo.Text = saleInfo ["MobileNo"];
                TXTFirstName.Text = saleInfo ["FirstName"];
                TXTLastName.Text = saleInfo ["LastName"];
                TXTTaxAmount.Text = saleInfo ["TaxAmount"];
                TXTSubTotal.Text = saleInfo ["SubTotal"];
                TXTGrandTotal.Text = saleInfo ["GrandTotal"];
                TXTAuthCode.Text = saleInfo ["AuthCode"];
                TXTCardAmount.Text = saleInfo ["CardAmount"];
                TXTCashAmount.Text = saleInfo ["CashAmount"];
                TXTDiscount.Text = saleInfo ["Discount"];
                TXTFourDigit.Text = saleInfo ["FourDigit"];
            }
        }
        // End of UI Update and refresh Section

        //Print Invoice Section 
        private void InitPrintInvoice()
        {   //TODO: Print Invoice

            vReciptHeader = new ReceiptHeader ();
            vReciptFooter = new ReceiptFooter ();
            vReciptDetails = new ReceiptDetails ();
            vReciptItems = new List<ReceiptItemDetails> ();
            vReciptItemTotal = new ReceiptItemTotal ();
            CurrentSize = MinimumSize;
        }
        private void PrintRecipts()
        {
            PdfPrinter.PrintRecipts (vReciptHeader, vReciptFooter, vReciptItemTotal, vReciptDetails, vReciptItems);

        }
        //End of Invoice Print Section 
         private void LoadSalesman()
        {

        }

    }
}