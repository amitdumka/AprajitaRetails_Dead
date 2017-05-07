using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AprajitaRetails.ViewModel;

namespace AprajitaRetails.Forms
{
    public partial class SaleInvoiceForm : Form
    {
        private int ItemID = 0;
        private DataTable itemTable;
        private SaleInvoiceVM sVM;
        private BindingSource vBsource = new BindingSource ();
        int vCustId = -1;
        private bool vIsNew = false;
        private ProductItems vItem;

        private DataTable vItemTable;

        private string vPayMode = "Cash";

        double vRoundOffAmt = 0;

        int vTotalItems = 0;

        double vTotalQty = 0;

        public SaleInvoiceForm()
        {
            InitializeComponent ();
            sVM = new SaleInvoiceVM ();
            itemTable = new DataTable ();
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
            vsItemTable.Columns.Add ("Rate", typeof (double));
            vsItemTable.Columns.Add ("Discount", typeof (double));
            vsItemTable.Columns.Add ("Tax", typeof (double));
            vsItemTable.Columns.Add ("Amount", typeof (double));
            //vItemTable.Columns.Add ("Date", typeof (DateTime));

            return vsItemTable;
            //vBsource.DataSource = vItemTable;
            // DGVSaleItems.DataSource = vBsource;
            //DGVSaleItems.Columns [0].Visible = false;
            //DGVSaleItems.Columns [1].Visible = false;

            //DGVSaleItems.Columns [2].Visible = false;
            //DGVSaleItems.Columns [6].Visible = false;
            //ID, InvoiceNo, ItemCode, BarCode, StyleCode,  Qty, Rate, Discount, Tax, Amount
        }


        private void AddItemRow()
        {   //TODO: update total fileds with rounf off and plcae it proper area
            if ( vItem != null )
            {
                string vBarcode = TXTBarCode.Text;
                string vQty = TXTQty.Text;
                string vAmount = TXTAmount.Text;
                // BindingSource bs = DGVSaleItems.DataSource as BindingSource;
                //DataTable dt = bs.DataSource as DataTable;
                DataTable dt = ( DGVSaleItems.DataSource as BindingSource ).DataSource as DataTable;
                // MessageBox.Show ("Col=" + dt.Columns.Count);
                DataRow nRow = dt.NewRow ();
                //TODO: Add  items to col in new row
                double vAmtd = double.Parse (vAmount);
                double vAmtWhole = Math.Round (vAmtd);
                vRoundOffAmt = vAmtWhole - vAmtd;
                //ID, InvoiceNo, ItemCode, BarCode, StyleCode,  Qty, Rate, Discount, Tax, Amount         
                nRow [0] = ( ++ItemID );
                nRow [1] = CBInvoiceNo.Text;
                nRow [2] = vItem.ID;
                nRow [3] = vBarcode;
                nRow [4] = vItem.StyleCode;
                nRow [5] = vQty;
                nRow [6] = vItem.MRP;
                nRow [7] = 0;//                double.Parse (TXTDiscount.Text.Trim ());
                nRow [8] = vItem.Tax;
                nRow [9] = double.Parse (vAmount);
                //nRow [10] = DateTime.Now;
                dt.Rows.Add (nRow);
                vTotalItems++;
                vTotalQty = vTotalQty + double.Parse (vQty);
                Basic.ClearUIFields (TLPItemDetails);
                //TODO: do total and grand totla calucaltins and update in UI Fields
            }
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if ( BTNAdd.Text == "Add" )
            {
                PerformAdd ();
            }
            else if ( BTNAdd.Text == "Save" )
            {
                PerformSave ();
            }
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

        private void CBInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSaleUI (CBInvoiceNo.Text);
        }

        private void CBMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCustomerField (sVM.GetCustomerInfo (CBMobileNo.Text));
        }

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

        private void LoadCardTypes()
        {
            Basic.AddListToComboBox (CBCardType, Basic.FeildList (typeof (Cards)));
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
            vItemTable.Columns.Add ("Rate", typeof (double));
            vItemTable.Columns.Add ("Discount", typeof (double));
            vItemTable.Columns.Add ("Tax", typeof (double));
            vItemTable.Columns.Add ("Amount", typeof (double));
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

        private void PerformSave()
        {
        }
        private SaleInvoice ReadFeilds()
        {//TODO: update vTotalItem, vTotalQty and VCustId 
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

        private void ReadPaymentDetails()
        {
        }
        private void SaleInvoiceForm_Load(object sender, EventArgs e)
        {
            LoadUiElements ();
        }

        private void ShowDVGData()
        {
        }

        private void TXTBarCode_TextChanged(object sender, EventArgs e)
        {   // TODO: Check Constrainst so that only select Barcode will go
            if ( TXTBarCode.Text.Length >= 10 )
                GetItemDetais (TXTBarCode.Text);
        }

        private void TXTCardAmount_TextChanged(object sender, EventArgs e)
        {
            TXTCardAmount.Text = TXTGrandTotal.Text;
            TXTCashAmount.Text = "0";
            vPayMode = "Card";
        }

        private void TXTCashAmount_MouseClick(object sender, MouseEventArgs e)
        {
            TXTCashAmount.Text = TXTGrandTotal.Text;
            TXTCardAmount.Text = "0";
            vPayMode = "Cash";
        }

        private void TXTCashAmount_TextChanged(object sender, EventArgs e)
        {
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
                    TXTTaxAmount.Text = "" + qty + "*" + rate + "=" + amts;

                    TXTAmount.Text = String.Format ("{0}", amts);
                }
                else
                {
                    TXTQty.Text = "" + vItem.Qty;

                    MessageBox.Show ("Quantity should be equal or lesser than " + vItem.Qty);
                }
            }


        }

        private void UpdateCustomerField(List<SortedDictionary<string, string>> cinfo)
        {
            if ( cinfo != null && cinfo.Count > 0 )
            {
                SortedDictionary<string, string> cust = cinfo [0];
                TXTFirstName.Text = cust ["FirstName"];
                TXTLastName.Text = cust ["LastName"];
                vCustId = Basic.ToInt (cust ["ID"]);
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

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            List<string> list = sVM.GetBarCodesList (1);
            string s = "";
            for ( int x = 0 ; x <= 9 ; x++ )
            {
                s = s + "\t" + list [x];
            }
            MessageBox.Show (s);
        }

        private void GBItemDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}