using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AprajitaRetails.Data;
using AprajitaRetails.DataModel;
using AprajitaRetails.ViewModel;

namespace AprajitaRetails.Forms
{
    public partial class DailySaleForm : Form
    {
        private DailySalesVM viewModel;

        public DailySaleForm()
        {
            InitializeComponent ();
            Logs.LogMe ("DailySale: Intizlition done");
            viewModel = new DailySalesVM ();
        }

        private void LoadPaymentMode()
        {
            Logs.LogMe ("DailySale:Loading Payment Mode ");
            List<PaymentMode> lists = viewModel.GetPaymentTypes ();
            foreach ( PaymentMode item in lists )
            {
                CBPaymentMode.Items.Add (item);
            }
            Logs.LogMe ("DailySale: Loading Completed");
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
            BTNAdd.Text = "Save";
            Basic.ClearUIFields (TLPInvoiceDetails);
            viewModel.AddData ();
        }

        private void PerformSave()
        {
            if ( ValidateFileds () )
            {
                if ( viewModel.SaveData (ReadFiled ()) )
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show ("Your Record got Save!");
                    RefreshSaleInfo ();
                }
                else
                {
                    MessageBox.Show ("Failed to save data, kindly chech and try again!");
                }
            }
        }

        private DailySaleDM ReadFiled()
        {
            DailySaleDM data = new DailySaleDM ()
            {  //TODO: No Need to Pass Customer Name, Only If new Customer is Clicked.
                Amount = Double.Parse (TXTBillAmount.Text),
                CustomerFullName = TXTCustomerName.Text,
                Discount = Double.Parse (TXTDiscount.Text),
                CustomerMobileNo = CBMobileNo.Text,
                InvoiceNo = TXTInvoiceNo.Text,
                Fabric = (int) NUDFabric.Value,
                RMZ = (int) NUDRmz.Value,
                Tailoring = (int) NUDTailoring.Value,
                NewCustomer = Basic.ReadChechBox (CKNewCustomer),
                PaymentMode = ( (PaymentMode) CBPaymentMode.SelectedItem ).ID,
                SaleDate = DTPDate.Value,
                ID = -1
            };
            return data;
        }

        private bool ValidateFileds()
        {
            bool status = false;
            status = Basic.ValidateFormUI (TLPInvoiceDetails);
            if ( !status )
                return false;
            status = Basic.IsNumeric (TXTBillAmount.Text);
            if ( !status )
            {
                MessageBox.Show ("Bill Amount takes oly Numeric values");
                return false;
            }
            status = Basic.IsNumeric (TXTDiscount.Text);
            if ( !status )
            {
                MessageBox.Show ("Discount Amount takes oly Numeric values");
                return false;
            }
            return status;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if ( BTNAdd.Text == "Save" )
                BTNAdd.Text = "Add";
            if ( BTNUpdate.Text == "Save" )
                BTNUpdate.Text = "Update";
            Basic.ClearUIFields (TLPInvoiceDetails);
        }

        public void RefreshSaleInfo()
        {
            SaleInfo info = viewModel.GetSaleInfo ();
            if ( info != null )
            {
                if ( info.TodaySale != null )
                    LBTodaySale.Text = info.TodaySale;

                if ( info.MonthlySale != null )
                    LBMontlySale.Text = info.MonthlySale;

                if ( info.YearlySale != null )
                    LBYearlySale.Text = info.YearlySale;
            }
        }

        private void DailySaleForm_Load(object sender, EventArgs e)
        {
            LoadPaymentMode ();
            LoadMobileNo ();
            RefreshSaleInfo ();
            LoadSaleList ();
        }

        private void CBPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            CustomersForm c = new CustomersForm ();
            c.IsDailog = true;
            DialogResult r = c.ShowDialog ();
            if ( c.DialogResult == DialogResult.OK )
            {
                TXTCustomerName.Text = c.CustomerFirstName + " " + c.CustomerLastName;
                CBMobileNo.Text = c.CustomerMobileNo;
            }
            c.Dispose ();
        }

        private void CBMobileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( CBMobileNo.Text.Length >= 10 )
            {
                string mob = CBMobileNo.Text;
                Logs.LogMe ("MobileN0: " + mob);
                if ( !mob.StartsWith ("91") )
                    mob = "91" + mob;
                TXTCustomerName.Text = viewModel.GetCustomerName (mob);
            }
            else
            {
                Logs.LogMe ("Less: ");
            }
        }

        public void LoadMobileNo()
        {
            List<string> list = viewModel.GetMobileNoList ();
            for ( int i = 0 ; i < list.Count ; i++ )
            {
                CBMobileNo.Items.Add (list [i]);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void LoadSaleList()
        {
            List<SortedDictionary<string, string>> listItem = viewModel.GetSaleList ();
           
            foreach ( var item in listItem )
            { string [] it = { item ["InvoiceNo"] , item ["Amount"] };
                LVSaleList.Items.Add (new ListViewItem (it));
                    

            }
        }
    }
}