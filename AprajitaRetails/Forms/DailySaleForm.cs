using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.SqlDataBase.DataModel;
using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class DailySaleForm : Form
    {
        private DailySalesVM viewModel;

        public DailySaleForm( )
        {
            InitializeComponent();
            Logs.LogMe("DailySale: Intizlition done");
            viewModel = new DailySalesVM();
        }

        private void LoadPaymentMode( )
        {
            Logs.LogMe("DailySale:Loading Payment Mode ");
            List<PaymentMode> lists = viewModel.GetPaymentTypes();
            foreach (PaymentMode item in lists)
            {
                CBPaymentMode.Items.Add(item);
            }
            Logs.LogMe("DailySale:PaymentMode Loading is Completed");
        }

        private void BTNAdd_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text == "Add")
            {
                PerformAdd();
            }
            else if (BTNAdd.Text == "Save")
            {
                PerformSave();
            }
        }

        private void PerformAdd( )
        {
            BTNAdd.Text = "Save";
            Basic.ClearUIFields(TLPInvoiceDetails);
            viewModel.AddData();
            CKNewCustomer.Checked = false;
            TXTInvoiceNo.Focus();
        }

        private void RefeshUI( )
        {
            RefreshSaleInfo();
            LoadSaleList();
        }

        private void PerformSave( )
        {
            if (ValidateFileds())
            {
                if (viewModel.SaveData(ReadFiled()))
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show("Your Record got Save!");
                    RefeshUI();
                }
                else
                {
                    MessageBox.Show("Failed to save data, kindly chech and try again!");
                }
            }
        }

        private DailySaleDM ReadFiled( )
        {
            DailySaleDM data = new DailySaleDM()
            {  //TODO: No Need to Pass Customer Name, Only If new Customer is Clicked.
                Amount = Double.Parse(TXTBillAmount.Text),
                CustomerFullName = TXTCustomerName.Text,
                Discount = Double.Parse(TXTDiscount.Text),
                CustomerMobileNo = CBMobileNo.Text,
                InvoiceNo = TXTInvoiceNo.Text,
                Fabric = (int)NUDFabric.Value,
                RMZ = (int)NUDRmz.Value,
                Tailoring = (int)NUDTailoring.Value,
                NewCustomer = Basic.ReadChechBox(CKNewCustomer),
                PaymentMode = ((PaymentMode)CBPaymentMode.SelectedItem).ID,
                SaleDate = DTPDate.Value,
                ID = -1
            };
            return data;
        }

        private bool ValidateFileds( )
        {
            bool status = false;
            status = Basic.ValidateFormUI(TLPInvoiceDetails);
            if (!status)
                return false;
            status = Basic.IsNumeric(TXTBillAmount.Text);
            if (!status)
            {
                MessageBox.Show("Bill Amount takes oly Numeric values");
                return false;
            }
            status = Basic.IsNumeric(TXTDiscount.Text);
            if (!status)
            {
                MessageBox.Show("Discount Amount takes oly Numeric values");
                return false;
            }
            return status;
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text == "Save")
                BTNAdd.Text = "Add";
            if (BTNUpdate.Text == "Save")
                BTNUpdate.Text = "Update";
            Basic.ClearUIFields(TLPInvoiceDetails);
        }

        public void RefreshSaleInfo( )
        {
            SaleInfo info = viewModel.GetSaleInfo();
            if (info != null)
            {
                if (info.TodaySale != null)
                    LBTodaySale.Text = info.TodaySale;

                if (info.MonthlySale != null)
                    LBMontlySale.Text = info.MonthlySale;

                if (info.YearlySale != null)
                    LBYearlySale.Text = info.YearlySale;
            }
        }

        private void DailySaleForm_Load( object sender, EventArgs e )
        {
            LoadPaymentMode();
            LoadMobileNo();
            RefeshUI();
        }

        private void CBPaymentMode_SelectedIndexChanged( object sender, EventArgs e )
        {
        }

        private void BTNDelete_Click( object sender, EventArgs e )
        {
            CustomersForm c = new CustomersForm()
            {
                IsDailog = true
            };
            DialogResult r = c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                TXTCustomerName.Text = c.CustomerFirstName + " " + c.CustomerLastName;
                CBMobileNo.Text = c.CustomerMobileNo;
            }
            c.Dispose();
            CKNewCustomer.Checked = true;
        }

        private void CBMobileNo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (CBMobileNo.Text.Length >= 10)
            {
                string mob = CBMobileNo.Text;
                Logs.LogMe("MobileN0: " + mob);
                if (!mob.StartsWith("91"))
                    mob = "91" + mob;
                TXTCustomerName.Text = viewModel.GetCustomerName(mob);
            }
            else
            {
                Logs.LogMe("Less: ");
            }
        }

        public void LoadMobileNo( )
        {
            List<string> list = viewModel.GetMobileNoList();
            for (int i = 0; i < list.Count; i++)
            {
                CBMobileNo.Items.Add(list[i]);
            }
        }

        private void ShowDailySaleData( DailySale saleD )
        {
            TXTBillAmount.Text = "" + saleD.Amount;

            string s1 = viewModel.GetCustomerName(saleD.CustomerID);
            string[] s = s1.Split(' ');
            CBMobileNo.Text = s[0];
            s[0] = "";
            TXTCustomerName.Text = String.Join(" ", s);
            Logs.LogMe("CustN=" + s1);
            //TODO: get Customer Details from Customer Table
            TXTDiscount.Text = "" + saleD.Discount;
            NUDFabric.Text = "" + saleD.Fabric;
            TXTInvoiceNo.Text = saleD.InvoiceNo;
            CBPaymentMode.SelectedIndex = saleD.PaymentMode - 1;
            NUDRmz.Text = "" + saleD.RMZ;
            DTPDate.Value = saleD.SaleDate;
            NUDTailoring.Text = "" + saleD.Tailoring;
        }

        private void ListView1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (BTNAdd.Text != "Save")
            {
                var item = LVSaleList.SelectedItems;
                if (item.Count > 0)
                {
                    string s = item[0].SubItems[0].Text;
                    //MessageBox.Show ("Selected Invocie No=" + s);
                    ShowDailySaleData(viewModel.GetInvoiceDetails(s.Trim()));
                }
            }
        }

        private void LoadSaleList( )
        {
            List<SortedDictionary<string, string>> listItem = viewModel.GetSaleList();
            LVSaleList.Items.Clear();
            foreach (var item in listItem)
            {
                string[] it = { item["InvoiceNo"], item["Amount"], item["ID"] };

                LVSaleList.Items.Add(new ListViewItem(it));
            }
        }

        private void DailySaleForm_Shown( object sender, EventArgs e )
        {
            //LoadPaymentMode ();
            //LoadMobileNo ();
            //RefeshUI ();
        }
    }
}