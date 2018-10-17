using AprajitaRetailMonitor.SeviceWorker;

//using AprajitaRetailsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testingapp
{
    public partial class UploaderForm : Form
    {
        // private int Mode;
        private List<string> itemlist = new List<string>();

        // private ExcelToDataBase ER;

        //private ExcelToDB EDB;
        // private UploaderFormVM EDB;

        public int RecordCount = 0;
        //private Clients clients = CurrentClient.LoggedClient;

        public UploaderForm( int mode )
        {
            InitializeComponent();
            //   Mode = mode;
            ExcelFileOpenDialogg.InitialDirectory = "C:\\Users\\";
            ExcelFileOpenDialogg.FileName = "";
            //  itemlist.Add("SaleRegister");
            // itemlist.Add("Customer");
            // itemlist.Add("SaleItemWise");
            /// itemlist.Add("Purchase");
            itemlist.Add("VoyBill");

            //itemlist.Add ("PurchaseRegister");
            for (int x = 0; x < itemlist.Count; x++)
                CBUploadType.Items.Add(itemlist[x]);
            CBUploadType.SelectedIndex = 0;
            //ER = new ExcelToDataBase();
            // EDB = new UploaderFormVM();
            db = new VoygerDatabase(InsertData.pathName + "\\" + InsertData.dbName);
            //db.DeleteDatabase();
            //db.CreateDatabase();
        }

        private VoygerDatabase db;

        public UploaderForm( )
        {
        }

        private void BTNGetExcel_Click( object sender, EventArgs e )
        {
            DialogResult result = ExcelFileOpenDialogg.ShowDialog();
            if (ExcelFileOpenDialogg.FileName != "")
            {
                TXTFileName.Text = ExcelFileOpenDialogg.FileName;
            }
            else
                TXTFileName.Text = "NotSelected";
        }

        private void BTNSave_Click( object sender, EventArgs e )
        {
            RecordCount = 0;
            pBar.Enabled = true;
            pBar.Visible = true;
            pBar.Style = ProgressBarStyle.Continuous;
            pBar.Step = 1;
            pBar.PerformStep();
            pBar.Minimum = Int32.Parse(TXTStart.Text);
            pBar.Maximum = Int32.Parse(TXTEnd.Text);
            Task t = null;
            //if (CBUploadType.Text == "SaleRegister")
            //    t = Task.Run(( ) => RecordCount = ER.ReadDataSaleRegister(TXTFileName.Text,
            //   Int32.Parse(TXTStart.Text.Trim()),
            //   Int32.Parse(TXTEnd.Text.Trim()), pBar, "SaleRegister"));
            //else if (CBUploadType.Text == "Purchase")
            //    t = Task.Run(( ) => RecordCount = ER.ReadPurchase(TXTFileName.Text,
            //   Int32.Parse(TXTStart.Text.Trim()),
            //   Int32.Parse(TXTEnd.Text.Trim()), pBar, "Puchase"));
            //else if (CBUploadType.Text == "SaleItemWise")
            //{
            //    t = Task.Run(( ) => RecordCount = ER.ReadDataSales(TXTFileName.Text,
            //   Int32.Parse(TXTStart.Text.Trim()),
            //   Int32.Parse(TXTEnd.Text.Trim()), pBar, "Sale"));
            //}
            //else if (CBUploadType.Text == "Customer")
            //{
            //    t = Task.Run(( ) => RecordCount = ER.ReadCustomer(TXTFileName.Text,
            //  Int32.Parse(TXTStart.Text.Trim()),
            //  Int32.Parse(TXTEnd.Text.Trim()), pBar, "Customer"));
            //}
            //           else
            if (CBUploadType.Text == "VoyBill")
            {   //Current Process
                // t = Task.Run (()=>VoyBillUpload.ReadVoyBillXML(TXTFileName.Text ));
                //return;
                t = Task.Run(( ) => ServiceAction.InsertInvoiceXML(TXTFileName.Text));
                //VoygerXMLReader.ReadVoyBillXML(TXTFileName.Text));
            }

            //else if ( CBUploadType.Text == "PurchaseRegister" )
            //{
            //    return;
            //}
            else
            {
                return;
            }

            Task q = Task.Run(( ) =>
           {
               t.Wait();
               if (t.IsCompleted)
               {
                   MessageBox.Show("Record save, " + RecordCount);
                   //
                   pBar.BeginInvoke(new Action(( ) =>
                 {
                     pBar.Minimum = 0;
                     pBar.Maximum = 0;
                     pBar.Value = 0;
                     pBar.Refresh();
                 }));
               }
               else
               {
                   Console.WriteLine("Sleeping for 5 sec");
                   Task.Delay(5000);
               }
           });
        }

        private void BTNByMonth_Click( object sender, EventArgs e )
        {
            var d = (from hj in db.LineItems select hj).ToList();
            DGVUploadedData.DataSource = d;
        }

        private void BTNByYear_Click( object sender, EventArgs e )
        {
            var c = (from fd in db.VoyBill select fd).ToList();

            DGVUploadedData.DataSource = c;

            //    if (CKWithProfit.Checked)
            //        EDB.RefreshDGV(DGVUploadedData, QuerySales.qByYearP);
            //    else
            //        EDB.RefreshDGV(DGVUploadedData, QuerySales.qByYear);
        }

        private void BTNByDay_Click( object sender, EventArgs e )
        {
            //DGVUploadedData.DataSource;
            var v = (from xs in db.VPaymentMode select xs).ToList();
            DGVUploadedData.DataSource = v;

            //IEnumerable<VoyBill> voys = db.VoyBills;
        }

        //{
        //    if (CKWithProfit.Checked)
        //        EDB.RefreshDGV(DGVUploadedData, QuerySales.qByDayP);
        //    else
        //        EDB.RefreshDGV(DGVUploadedData, QuerySales.qByDay);
        //}

        private void BTNReload_Click( object sender, EventArgs e )
        {
            var v = from xs in db.VoyBill select xs;

            string str = "";
            foreach (VoyBill bb in v)
            {
                str = str + "\nID:" + bb.ID + "\t BillNumber:" + bb.BillNumber + " CustName: " + bb.CustomerName;
            }
            MessageBox.Show(str);

            IQueryable<VoyBill> source = db.VoyBill;
            //IQueryable<Product> results = source.Where(product => product.UnitPrice > 100);

            foreach (VoyBill item in source)
            {
                Console.WriteLine("{0}: {1}", item.ID, item.BillNumber);
            }
            //db.Connection.Close();
            //db.Connection.Dispose();
            //db.DeleteDatabase();
            //db.CreateDatabase();
            //db.Connection.Open();
        }

        //{
        //    if (CBUploadType.Text == "Purchase")
        //        EDB.RefreshDGV(DGVUploadedData, Querys.qAllPurchase);
        //    else if (CBUploadType.Text == "SaleRegister")
        //        EDB.RefreshDGV(DGVUploadedData, Querys.qAll);
        //    else if (CBUploadType.Text == "SaleItemWise")
        //        EDB.RefreshDGV(DGVUploadedData, QuerySales.qAll);
        //}

        private void BTNQuery_Click( object sender, EventArgs e )
        {
            // EDB.RefreshDGV(DGVUploadedData, TXTFileName.Text);
        }

        private void CBUploadType_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (CBUploadType.Text == "SaleRegister")
            {
                TXTStart.Text = "7";
                TXTEnd.Text = "10";
            }
            else if (CBUploadType.Text == "SaleItemWise")
            {
                TXTStart.Text = "7";
                TXTEnd.Text = "10";
            }
            else if (CBUploadType.Text == "Purchase")
            {
                TXTStart.Text = "6";
                TXTEnd.Text = "10";
            }
        }

        private void UploaderForm_Load( object sender, EventArgs e )
        {
        }

        private void TXTStart_TextChanged( object sender, EventArgs e )
        {
        }

        private void DGVUploadedData_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
        }
    }
}