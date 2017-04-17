using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class UploaderForm : Form
    {
        private int Mode;
        private List<string> itemlist = new List<string> ();
        private ExcelUploader ER;
        private ExcelToDB EDB;
        public int RecordCount = 0;

        public UploaderForm(int mode)
        {
            InitializeComponent ();
            Mode = mode;
            ExcelFileOpenDialogg.InitialDirectory = "C:\\Users\\";
            ExcelFileOpenDialogg.FileName = "";
            itemlist.Add ("SaleRegister");
            itemlist.Add ("Sales");
            itemlist.Add ("Purchase");
            CBUploadType.Items.Add (itemlist [0]);
            CBUploadType.Items.Add (itemlist [1]);
            CBUploadType.Items.Add (itemlist [2]);
            CBUploadType.SelectedIndex = 0;
            ER = new ExcelUploader ();
            EDB = new ExcelToDB ();

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
                 Int32.Parse (TXTEnd.Text.Trim ()), pBar));
            else if ( CBUploadType.Text == "Purchase" )
                t = Task.Run (() => RecordCount = ER.ReadPurchase (TXTFileName.Text,
                Int32.Parse (TXTStart.Text.Trim ()),
                Int32.Parse (TXTEnd.Text.Trim ()), pBar));
            else if ( CBUploadType.Text == "SaleItemWise" )
            {
                return;
            }
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
                EDB.RefreshDGV (DGVUploadedData, Querys.qByMonthP);
            else
                EDB.RefreshDGV (DGVUploadedData, Querys.qByMonth);
        }

        private void BTNByYear_Click(object sender, EventArgs e)
        {
            if ( CKWithProfit.Checked )
                EDB.RefreshDGV (DGVUploadedData, Querys.qByYearP);
            else
                EDB.RefreshDGV (DGVUploadedData, Querys.qByYear);
        }

        private void BTNByDay_Click(object sender, EventArgs e)
        {
            if ( CKWithProfit.Checked )
                EDB.RefreshDGV (DGVUploadedData, Querys.qByDayP);
            else
                EDB.RefreshDGV (DGVUploadedData, Querys.qByDay);
        }

        private void BTNReload_Click(object sender, EventArgs e)
        {
            if ( CBUploadType.Text == "Purchase" )
                EDB.RefreshDGV (DGVUploadedData, Querys.qAllPurchase);
            else if ( CBUploadType.Text == "SaleRegister" )
                EDB.RefreshDGV (DGVUploadedData, Querys.qAll);
        }
    }
}
