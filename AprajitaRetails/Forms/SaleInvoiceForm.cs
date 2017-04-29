using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.ViewModel;

namespace AprajitaRetails.Forms
{
    public partial class SaleInvoiceForm : Form
    {
        SaleInvoiceVM sVM;
        bool vIsNew = false;
        DataTable itemTable;
        public SaleInvoiceForm()
        {
            InitializeComponent ();
            sVM = new SaleInvoiceVM ();
            itemTable = new DataTable ();
            

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
        private void PerformAdd()
        {
            vIsNew = true;
        }
        private void PerformSave() { }
        private void ReadFeilds() { }
        private void ReadPaymentDetails() { }

        private void CBMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCustomerField (sVM.GetCustomerInfo (CBMobileNo.Text));
        }

        private void UpdateCustomerField(List<SortedDictionary<string, string>> cinfo)
        {
            if ( cinfo != null && cinfo.Count > 0 )
            {
                SortedDictionary<string, string> cust = cinfo [0];
                TXTFirstName.Text = cust ["FirstName"];
                TXTLastName.Text = cust ["LastName"];
            }
        }

        private void BTNNewCustomer_Click(object sender, EventArgs e)
        {
            //TODO: when MobileNo is added to text , disable  field change event
            CustomersForm c = new CustomersForm ();
            c.IsDailog = true;
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

        private void CBInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSaleUI (CBInvoiceNo.Text);
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
        private void LoadMobileNoList()
        {
            sVM.GetCustomerMobileNoList (CBMobileNo);
        }
        private void LoadInvoiceNoList()
        {
            sVM.GetInvoiceNoList (CBInvoiceNo);
        }

        private void LoadUiElements()
        {
            LoadInvoiceNoList ();
            LoadMobileNoList ();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Basic.ClearUIFields (TLPInvoiceDetails);
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }

        private void TXTBarCode_TextChanged(object sender, EventArgs e)
        {
            GetItemDetais (TXTBarCode.Text);
        }
        private void GetItemDetais(string barCode)
        {
            SortedDictionary<string, string> item = sVM.GetItemDetails (barCode) [0];
            if ( item != null && item.Count > 0 )
            {
                TXTItemDetail.Text = item ["ItemDetail"];
                TXTRate.Text = item ["MRP"];
            }
        }

        private void TXTQty_TextChanged(object sender, EventArgs e)
        {
            if ( Basic.IsNumeric (TXTQty.Text) )
            {
                double qty = double.Parse (TXTQty.Text);
                double rate = double.Parse (TXTRate.Text);
                rate = rate * qty;
                TXTAmount.Text = "" + rate;
            }
        }

        private void BTNItemAdd_Click(object sender, EventArgs e)
        {
            AddItemRow ();
        }
        private void AddItemRow()
        {

        }
        private void ShowDVGData()
        {

        }
    }
}
