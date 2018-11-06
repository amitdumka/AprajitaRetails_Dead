using AprajitaRetailsDataBase.Client;
using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataTypes;
using AprajitaRetailsViewModels.EF6;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    //TODO: auto get selected if any new customer is created and used for billing here.
    //TODO: supply customer name and mobile to new customer saving so same customer . and check checkbox of new customer
    //TODO: pop box to save basic info when customer is not found in database. and make sure that mobile no and customer exist in our db
    //TODO: then only save dailysale data. 
    //TODO: show time diff for pending invoice saving so when it store. it should be pop up dealy and generate a rating for Store Manger. which can be used for further aprisale
    //TODO: pop an dialog to select salesman name for which can be used to save other data. 
    //TODO: save sale Invoice also same time and ask for saleman name for all items or sperate items
    //TODO: Genertate WOW Bill  message option to provide send message to owner email id 

    public partial class DailySaleForm : Form
    {
        DailySaleViewModel viewModel;
        public DailySaleForm( )
        {
            InitializeComponent();
            Logs.LogMe( "DailySale: Intizlition done" );
            viewModel=new DailySaleViewModel();
            //viewModel=new DailySalesVM();
        }

        private void PerformAdd( )
        {
            BTNAdd.Text="Save";
            Basic.ClearUIFields( TLPInvoiceDetails );
            viewModel.AddData();
            CKNewCustomer.Checked=false;
            TXTInvoiceNo.Focus();
        }

        private void RefeshUI( )
        {
            RefreshSaleInfo();
            LoadSaleList();
            ShowUnSaveInvoice();
        }

        private void PerformSave( )
        {
            if (ValidateFileds())
            {
                if (viewModel.SaveData( ReadFiled() ))
                {
                    BTNAdd.Text="Add";
                    MessageBox.Show( "Your Record got Save!" );
                    RefeshUI();
                }
                else
                {
                    MessageBox.Show( "Failed to save data, kindly chech and try again!" );
                }
            }
        }

        private DailySaleDM ReadFiled( )
        {
            DailySale dailySale = new DailySale()
            {
                Amount=decimal.Parse( TXTBillAmount.Text ),
                Discount=decimal.Parse( TXTDiscount.Text ),
                InvoiceNo=TXTInvoiceNo.Text,
                Fabric=(double)NUDFabric.Value,
                RMZ=(int)NUDRmz.Value,
                Tailoring=(int)NUDTailoring.Value,
                PaymentModeID=((PaymentMode)CBPaymentMode.SelectedItem).PaymentModeID,
                SaleDate=DTPDate.Value,
                StoreCode=CurrentClient.LoggedClient.ClientCode,
                CustomerID=viewModel.GetCustomerID( CBMobileNo.Text )

            };
            
            NewCustomer newCustomer = new NewCustomer() {
                CustomerFullName=TXTCustomerName.Text,
                CustomerID=dailySale.CustomerID,
                OnDate=DTPDate.Value,InvoiceNo=dailySale.InvoiceNo
            };
            DailySaleDM data = new DailySaleDM()
            {
                //TODO: No Need to Pass Customer Name, Only If new Customer is Clicked.
                FullCustomerName=TXTCustomerName.Text,
                IsNewCustomer=Basic.IntToBool( Basic.ReadChechBox( CKNewCustomer ))
                ,NewCustomer=newCustomer, DailySale=dailySale
            };
            return data;
        }

        private bool ValidateFileds( )
        {
            bool status = false;
            status=Basic.ValidateFormUI( TLPInvoiceDetails );
            if (!status)
            {
                return false;
            }

            status=Basic.IsNumeric( TXTBillAmount.Text );
            if (!status)
            {
                MessageBox.Show( "Bill Amount takes oly Numeric values" );
                return false;
            }

            status=Basic.IsNumeric( TXTDiscount.Text );
            if (!status)
            {
                MessageBox.Show( "Discount Amount takes oly Numeric values" );
                return false;
            }

            return status;
        }
      
        #region EventHandling

        private void Cancel_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text=="Save")
            {
                BTNAdd.Text="Add";
            }

            if (BTNUpdate.Text=="Save")
            {
                BTNUpdate.Text="Update";
            }

            Basic.ClearUIFields( TLPInvoiceDetails );
        }


        private void BTNAdd_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text=="Add")
            {
                PerformAdd();
            }
            else if (BTNAdd.Text=="Save")
            {
                PerformSave();
            }
        }

        private void CBPaymentMode_SelectedIndexChanged( object sender, EventArgs e )
        {
        }

        private void BTNDelete_Click( object sender, EventArgs e )
        {//TODO check it 
            CustomersForm c = new CustomersForm()
            {
                IsDailog=true
            };
            DialogResult r = c.ShowDialog();
            if (c.DialogResult==DialogResult.OK)
            {
                TXTCustomerName.Text=c.CustomerFirstName+" "+c.CustomerLastName;
                CBMobileNo.Text=c.CustomerMobileNo;
            }

            c.Dispose();
            CKNewCustomer.Checked=true;
            CheckedNewCustomerFlag( true );
        }

        private void CBMobileNo_SelectedIndexChanged( object sender, EventArgs e )
        {
            //TODO: when Saving dailysale data. and Mobile no is not present. ask and make it create new customer 
            //TODO: or Save a customer with just basic info.
            if (CBMobileNo.Text.Length>=10)
            {
                string mob = CBMobileNo.Text;
                Logs.LogMe( "MobileN0: "+mob );
                if (!mob.StartsWith( "+91" ) && mob.Length==10)
                {
                    mob="+91"+mob;
                }
               
                string name= viewModel.GetCustomerName( mob );
                if (name==""||name=="NotFound" && BTNAdd.Text.Trim()=="Save")
                    MessageBox.Show( "Customer Not found Kindly Check mobile and enter again!" );
                else
                    TXTCustomerName.Text=name;
            }
            else 
            {
                Logs.LogMe( "Less: " );
                TXTCustomerName.Text="";
                //MessageBox.Show( "Kindly enter Proper mobile to search!" );
            }
        }


        private void ListView1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (BTNAdd.Text!="Save")
            {
                var item = LVSaleList.SelectedItems;
                if (item.Count>0)
                {
                    string s = item[0].SubItems[0].Text;
                    ShowDailySaleData( viewModel.GetInvoiceDetails( s.Trim() ) );
                }
            }
        }
        #endregion

        #region UI_opertations
        /// <summary>
        /// Load Payment Mode to UI
        /// </summary>
        private void LoadPaymentMode( )
        {
            Logs.LogMe( "DailySale:Loading Payment Mode " );
            List<PaymentMode> lists = viewModel.GetPaymentTypes();
            CBPaymentMode.Items.AddRange( lists.ToArray() );
            Logs.LogMe( "DailySale:PaymentMode Loading is Completed" );

        }

        private void DailySaleForm_Shown( object sender, EventArgs e )
        {
            //LoadPaymentMode ();
            //LoadMobileNo ();
            //RefeshUI ();
        }

        public void RefreshSaleInfo( )
        {
            SaleInfo info = viewModel.GetSaleInfo();
            if (info!=null)
            {
                if (info.TodaySale!=null)
                {
                    LBTodaySale.Text=info.TodaySale;
                }
               
                if (info.MonthlySale!=null)
                {
                    LBMontlySale.Text=info.MonthlySale;
                }
                

                if (info.YearlySale!=null)
                {
                    LBYearlySale.Text=info.YearlySale;
                }
            }
        }

        private void DailySaleForm_Load( object sender, EventArgs e )
        {
            Console.WriteLine( "DailySale_form is loaded" );
            LoadPaymentMode();
            LoadMobileNo();
            RefeshUI();
        }

        private void ShowDailySaleData( DailySale saleD )
        {
            TXTBillAmount.Text=""+saleD.Amount;
            CustomerInfo cInfo = viewModel.GetCustomerInfo( saleD.CustomerID );
            Logs.LogMe( "CustN="+cInfo.CustomerName );
            TXTCustomerName.Text=cInfo.CustomerName;
            CBMobileNo.Text=cInfo.MobileNo;
            //TODO: stop triggering mobileno change event or do some thing else

            TXTDiscount.Text=""+saleD.Discount;
            NUDFabric.Text=""+saleD.Fabric;
            TXTInvoiceNo.Text=saleD.InvoiceNo;
            CBPaymentMode.SelectedIndex=saleD.PaymentModeID-1??0;
            NUDRmz.Text=""+saleD.RMZ;
            DTPDate.Value=saleD.SaleDate;
            NUDTailoring.Text=""+saleD.Tailoring;
            // check properly
        }

        private void LoadSaleList( )
        {
            List<DSInfo> listItem = viewModel.GetSaleList();
            LVSaleList.Items.Clear();
            foreach (DSInfo item in listItem)
            {
                string[] it = { item.InvoiceNo, item.Amount.ToString(), item.DailySaleId.ToString() };

                LVSaleList.Items.Add( new ListViewItem( it ) );
            }
            Console.WriteLine( "salelist:{0}", listItem.Count );
        }
        public void LoadMobileNo( )
        {
            List<string> list = viewModel.GetMobileNoList();
            for (int i = 0; i<list.Count; i++)
            {
                CBMobileNo.Items.Add( list[i] );
                Console.WriteLine( "Mob: "+list[i] );
            }
          }



        #endregion

        #region LinqSql

        private void ShowUnSaveInvoice( )
        {
            List<SortedDictionary<string, string>> listItem = viewModel.GetPendingList();
            if (listItem!=null&&listItem.Count>0)
            {
                LVPendingInvoice.Items.Clear();

                foreach (var item in listItem)
                {
                    string[] it = { item["InvoiceNo"], item["InvoiceDate"], item["Amount"], item["ID"] };

                    LVPendingInvoice.Items.Add( new ListViewItem( it ) );
                }
            }
            else
            {
                if (listItem!=null)
                {
                    Console.WriteLine( "ListItem is empty.#"+listItem.Count );
                }
            }
            LVPendingInvoice.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
            LVPendingInvoice.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
        }

        private void LVPendingInvoice_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (BTNAdd.Text=="Save")
            {
                var item = LVPendingInvoice.SelectedItems;
                if (item.Count>0)
                {
                    string s = item[0].SubItems[0].Text+" have ID: "+item[0].SubItems[3].Text;
                    MessageBox.Show( "Selected Invocie No="+s );
                    PopulateDailySaleFiels( short.Parse( item[0].SubItems[3].Text ) );
                    //ShowDailySaleData(viewModel.GetInvoiceDetails(s.Trim()));
                }
            }
        }

        private void PopulateDailySaleFiels( int id )
        {
            VoygerBill voygerBill = viewModel.GetVoyBillsByID( id );
            TXTInvoiceNo.Text=voygerBill.bill.BillNumber;
            TXTCustomerName.Text=voygerBill.bill.CustomerName;
            TXTBillAmount.Text=""+voygerBill.bill.BillAmount;
            TXTDiscount.Text=""+voygerBill.bill.BillDiscount;
            CBMobileNo.Text=voygerBill.bill.CustomerMobile;
            // TODO: implement in voyger class to so that it will be accross solution
            CBPaymentMode.Text=viewModel.ConvertToPaymentMode(voygerBill.payModes[0].PaymentMode);
        }

        #endregion LinqSql

        private void BTNUpdate_Click( object sender, EventArgs e )
        {
        }

        #region Not Implemented
        public void SendWowBillEmail( string invNo, decimal billAmt, int salesmanID, DateTime bDate ) { }
        public void SaveWowBill( string invNo, decimal billAmt, int salesmanID, DateTime bDate) {
            if (billAmt>=10000)
            {
                viewModel.SaveWowBill( invNo, billAmt, salesmanID, bDate );
                SendWowBillEmail( invNo, billAmt, salesmanID, bDate );
            }
        }
        public void SaveSaleInvoice( string inv) {
            viewModel.SaveSaleInvoices( inv );
        }
        public void UpdateSalesmanForItems( bool allitems/* parameter to take data*/) { }
        public void CheckedNewCustomerFlag(bool check )
        {
            CKNewCustomer.Checked=check;
        }
        public void UpdateCustomersBillCount(int custID, decimal billAmount ) {
            viewModel.UpdateCustomerBillCount( custID, billAmount );
        }
        #endregion
    }
}