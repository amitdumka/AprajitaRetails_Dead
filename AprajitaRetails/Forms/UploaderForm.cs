using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Excels;
using AprajitaRetails.Utils;
using AprajitaRetails.Voy;

namespace AprajitaRetails.Forms
{
    public partial class UploaderForm : Form
    {
        private int Mode;
        private List<string> itemlist = new List<string> ();
        private ExcelToDataBase ER;
        //private ExcelToDB EDB;
        private UploaderFormVM EDB;
        public int RecordCount = 0;
        Clients clients= CurrentClient.LoggedClient;

        public UploaderForm(int mode)
        {
            InitializeComponent ();
            Mode = mode;
            ExcelFileOpenDialogg.InitialDirectory = "C:\\Users\\";
            ExcelFileOpenDialogg.FileName = "";
            itemlist.Add ("SaleRegister");
            itemlist.Add ("Customer");
            itemlist.Add ("SaleItemWise");
            itemlist.Add ("Purchase");
            itemlist.Add ("VoyBill");

            //itemlist.Add ("PurchaseRegister");
            for ( int x = 0 ; x < itemlist.Count ; x++ )
                CBUploadType.Items.Add (itemlist [x]);
            CBUploadType.SelectedIndex = 0;
            ER = new ExcelToDataBase ();
            EDB = new UploaderFormVM ();

        }

        private void BTNGetExcel_Click(object sender, EventArgs e)
        {
            DialogResult result = ExcelFileOpenDialogg.ShowDialog ();
            if ( ExcelFileOpenDialogg.FileName != "" )
            {
                TXTFileName.Text = ExcelFileOpenDialogg.FileName;
            }
            else
                TXTFileName.Text = "NotSelected";
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            RecordCount = 0;
            pBar.Enabled = true;
            pBar.Visible = true;
            pBar.Style = ProgressBarStyle.Continuous;
            pBar.Step = 1;
            pBar.PerformStep ();
            pBar.Minimum = Int32.Parse (TXTStart.Text);
            pBar.Maximum = Int32.Parse (TXTEnd.Text);
            Task t = null;
            if ( CBUploadType.Text == "SaleRegister" )
                t = Task.Run (() => RecordCount = ER.ReadDataSaleRegister (TXTFileName.Text,
                Int32.Parse (TXTStart.Text.Trim ()),
                Int32.Parse (TXTEnd.Text.Trim ()), pBar, "SaleRegister"));
            else if ( CBUploadType.Text == "Purchase" )
                t = Task.Run (() => RecordCount = ER.ReadPurchase (TXTFileName.Text,
                Int32.Parse (TXTStart.Text.Trim ()),
                Int32.Parse (TXTEnd.Text.Trim ()), pBar, "Puchase"));
            else if ( CBUploadType.Text == "SaleItemWise" )
            {
                t = Task.Run (() => RecordCount = ER.ReadDataSales (TXTFileName.Text,
                Int32.Parse (TXTStart.Text.Trim ()),
                Int32.Parse (TXTEnd.Text.Trim ()), pBar, "Sale"));
            }
            else if ( CBUploadType.Text == "Customer" )
            {
                t = Task.Run (() => RecordCount = ER.ReadCustomer (TXTFileName.Text,
               Int32.Parse (TXTStart.Text.Trim ()),
               Int32.Parse (TXTEnd.Text.Trim ()), pBar, "Customer"));
            }
            else if ( CBUploadType.Text == "VoyBill" )
            {   //Current Process
                t = Task.Run (()=>VoyBillUpload.ReadVoyBillXML(TXTFileName.Text ));
                //return;
            }

            //else if ( CBUploadType.Text == "PurchaseRegister" )
            //{
            //    return;
            //}
            else
            {
                return;
            }


            Task q = Task.Run (() =>
            {
                t.Wait ();
                if ( t.IsCompleted )
                {
                    MessageBox.Show ("Record save, " + RecordCount);
                    //
                    pBar.BeginInvoke (new Action (() =>
                    {
                        pBar.Minimum = 0;
                        pBar.Maximum = 0;
                        pBar.Value = 0;
                        pBar.Refresh ();

                    }));

                }
                else
                {
                    Console.WriteLine ("Sleeping for 5 sec");
                    Task.Delay (5000);
                }
            });

        }

        private void BTNByMonth_Click(object sender, EventArgs e)
        {
            if ( CKWithProfit.Checked )
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByMonthP);
            else if (CBUploadType.Text == "SaleItemWise")
                EDB.RefreshDGV(DGVUploadedData, QuerySales.qByMonth);
            else
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByMonth);
        }

        private void BTNByYear_Click(object sender, EventArgs e)
        {
            if ( CKWithProfit.Checked )
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByYearP);
            
            else
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByYear);
        }

        private void BTNByDay_Click(object sender, EventArgs e)
        {
            if ( CKWithProfit.Checked )
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByDayP);
            else
                EDB.RefreshDGV (DGVUploadedData, QuerySales.qByDay);
        }

        private void BTNReload_Click(object sender, EventArgs e)
        {
            if ( CBUploadType.Text == "Purchase" )
                EDB.RefreshDGV (DGVUploadedData, Querys.qAllPurchase);
            else if ( CBUploadType.Text == "SaleRegister" )
                EDB.RefreshDGV (DGVUploadedData, Querys.qAll);
            else if (CBUploadType.Text == "SaleItemWise")
                EDB.RefreshDGV(DGVUploadedData, QuerySales.qAll);
        }

        private void BTNQuery_Click(object sender, EventArgs e)
        {
            EDB.RefreshDGV (DGVUploadedData, TXTFileName.Text);
        }

        private void CBUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( CBUploadType.Text == "SaleRegister" )
            {
                TXTStart.Text = "7";
                TXTEnd.Text = "10";
            }
            else if ( CBUploadType.Text == "SaleItemWise" )
            {
                TXTStart.Text = "7";
                TXTEnd.Text = "10";
            }
            else if ( CBUploadType.Text == "Purchase" )
            {
                TXTStart.Text = "6";
                TXTEnd.Text = "10";
            }
        }

        private void UploaderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
