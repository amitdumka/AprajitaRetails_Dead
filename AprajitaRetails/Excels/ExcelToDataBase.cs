using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.ViewModel;
using CyberN;


namespace AprajitaRetails.Excels
{
    class ExcelToDataBase
    {
        public string FileName { get; set; }
        ObjectToDataBase Db;

        public ExcelToDataBase()
        {
            Db = new ObjectToDataBase ();
        }
        private int I(string num)
        {
            return Int32.Parse (num.Trim ());
        }

        private int AddColPurchase(Cell cell, ref Purchase sr, int c)
        {
            Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch ( cell.ColumnIndex )
            {
                case 0:
                    sr.Grnno = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.Grndate = DataConvertor.DateFromExcelFormat (cell.Text);
                    c++;
                    break;
                case 2:
                    sr.Invoiceno = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.Invdate = DataConvertor.DateFromExcelFormat (cell.Text);
                    c++;
                    break;
                case 4:
                    sr.Suppliername = cell.Text;
                    c++;
                    break;
                case 5:
                    sr.Barcode = cell.Text;
                    c++;
                    break;
                case 6:
                    sr.Productname = cell.Text;
                    c++;
                    break;
                case 7:
                    sr.Stylecode = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.Itemdesc = cell.Text;
                    c++;
                    break;
                case 9:
                    sr.Qty = cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.Mrp = cell.Amount;
                    c++;
                    break;
                case 11:
                    sr.Mrpvalue = cell.Amount;
                    c++;
                    break;
                case 12:
                    sr.Cost = cell.Amount;
                    c++;
                    break;
                case 13:
                    sr.Costvalue = cell.Amount;
                    c++;
                    break;
                case 14:
                    sr.Taxamt = cell.Amount;
                    c++;
                    break;
            }

            return c;
        }

        public int ReadPurchase(string fname, int start, int end, ProgressBar pBar, string tablename)
        {
            DataTable dt = new DataTable (tablename);
            int Row = 0;
            int r = 0, c = 0;
            Purchase sr;
            Logs.LogMe ("Started Reading Excel Sheet");
            foreach ( var worksheet in Workbook.Worksheets (fname) )
            {
                Logs.LogMe (worksheet.ToString ());

                foreach ( var row in worksheet.Rows )
                {
                    Logs.LogMe ("Row=" + row.ToString () + "RowNo=" + Row);
                    if ( Row <= end )
                    {
                        if ( Row >= start )
                        {
                            Logs.LogMe ("iRow=" + r);
                            sr = new Purchase ();
                            c = 0;
                            foreach ( var cell in row.Cells )
                            {
                                if ( cell != null )
                                {
                                    c = AddColPurchase (cell, ref sr, c);
                                }
                                else
                                {
                                    Logs.LogMe ("C=" + c + "Null");
                                }
                                c++;
                            }
                            if ( Db.SaveRowData (sr) > 0 )
                            {
                                r++;
                                pBar.BeginInvoke (new Action (() =>
                                {
                                    pBar.PerformStep ();
                                }));
                                Logs.LogMe ("Row=" + r + " got saved");

                            }
                        }
                        Row++;
                        Logs.LogMe ("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe ("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe ("End of line");
            return r;
        }


    }

    class ObjectToDataBase
    {
        DataBase vDb;
        ObjectToItem vOti;
        public ObjectToDataBase()
        {
            vDb = new DataBase (ConType.SQLDB);
            vOti = new ObjectToItem ();
        }

        /// <summary>
        /// Insert Query Sql
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private int InsertQuerySql(SqlCommand cmd)
        {
            try
            {
                int status = cmd.ExecuteNonQuery ();
                if ( status > 0 )
                {
                    Logs.LogMe ("Insert done " + cmd.CommandText);
                    return 1;
                }
                else
                {
                    Logs.LogMe ("Insert Failed " + cmd.CommandText);
                    return 0;
                }
            }
            catch ( Exception e )
            {
                Logs.LogMe ("InsertExp: " + e.Message + "\t" + cmd.CommandText);
                return -1;
            }
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr"> SaleItemWise object</param>
        /// <returns>return no of record added</returns>
        public int SaveRowData(SaleItemWise sr)
        {
            string query = "INSERT INTO [dbo].[SalesRegister] " +
                "( [InvoiceNo], [InvoiceDate], [InvoiceType],  " +
                "BrandName,ProductName,ItemDescrpetion,BarCode,StyleCode" +
                "[Qty], [MRP], [Discount], [BasicAmt], [TaxAmount], " +
                "[RoundOff], LineTotal,[BillAmount], Salesman,[PaymentMode]) " +
                " VALUES (@Inv,@InvD , @InvT, @BName,@PName,@IDes,@BCode,@SCode" +
                "@QTY, @MRP, @Dis, @BAMT, @TAMT,  @ROFF,@Ltotal, @BILL,@Sman,  @PM)";

            SqlCommand cmd = new SqlCommand (query, vDb.DBCon);
            cmd.Parameters.AddWithValue ("@Inv", sr.InvoiceNo);
            cmd.Parameters.AddWithValue ("@InvD", sr.InvDate);
            cmd.Parameters.AddWithValue ("@InvT", sr.InvType);
            cmd.Parameters.AddWithValue ("@QTY", sr.QTY);
            cmd.Parameters.AddWithValue ("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue ("@Dis", sr.Discount);
            cmd.Parameters.AddWithValue ("@BAMT", sr.BasicRate);
            cmd.Parameters.AddWithValue ("@TAMT", sr.Tax);
            cmd.Parameters.AddWithValue ("@ROFF", sr.RoundOff);
            cmd.Parameters.AddWithValue ("@BILL", sr.BillAmnt);
            cmd.Parameters.AddWithValue ("@PM", sr.PaymentType);
            cmd.Parameters.AddWithValue ("@Sman", sr.Saleman);
            cmd.Parameters.AddWithValue ("@BCode", sr.Barcode);
            cmd.Parameters.AddWithValue ("@SCode", sr.StyleCode);
            cmd.Parameters.AddWithValue ("@Ltotal", sr.LineTotal);
            cmd.Parameters.AddWithValue ("@BName", sr.Barcode);
            cmd.Parameters.AddWithValue ("@PName", sr.StyleCode);
            cmd.Parameters.AddWithValue ("@IDes", sr.LineTotal);
            return InsertQuerySql (cmd);
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr">SaleRegister Object</param>
        /// <returns>Return no of Object</returns>
        public int SaveRowData(SaleRegister sr)
        {
            string query = "INSERT INTO [dbo].[SalesRegister] " +
                "( [InvoiceNo], [InvoiceDate], [InvoiceType],  " +
                "[Qty], [MRP], [Discount], [BasicAmt], [TaxAmount], " +
                "[RoundOff], [BillAmount], [PaymentMode]) " +
                /*"[Coupon], [CouponAmt],   [TalioringFlag], " +
                "[InstOrderCD])" +*/
                " VALUES (@Inv,@InvD , @InvT, @QTY, @MRP, @Dis, @BAMT, " +
                "@TAMT,  @ROFF, @BILL,  @PM)";//, @CO,@CAMT,  @TFG, @INST)";
            SqlCommand cmd = new SqlCommand (query, vDb.DBCon);

            cmd.Parameters.AddWithValue ("@Inv", sr.InvoiceNo);
            cmd.Parameters.AddWithValue ("@InvD", sr.InvDate);
            cmd.Parameters.AddWithValue ("@InvT", sr.InvType);
            cmd.Parameters.AddWithValue ("@QTY", sr.QTY);
            cmd.Parameters.AddWithValue ("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue ("@Dis", sr.Discount);
            cmd.Parameters.AddWithValue ("@BAMT", sr.BasicRate);
            cmd.Parameters.AddWithValue ("@TAMT", sr.Tax);
            cmd.Parameters.AddWithValue ("@ROFF", sr.RoundOff);
            cmd.Parameters.AddWithValue ("@BILL", sr.BillAmnt);
            cmd.Parameters.AddWithValue ("@PM", sr.paymentType);
            //cmd.Parameters.AddWithValue("@CO", sr.coupon);
            //cmd.Parameters.AddWithValue("@CAMT", sr.couponAmt);
            //cmd.Parameters.AddWithValue("@TFG", sr.Tailoring);
            //cmd.Parameters.AddWithValue("@INST", sr.instaorder);
            return InsertQuerySql (cmd);
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr"> Purchase Object</param>
        /// <returns>No of recorded added</returns>
        public int SaveRowData(Purchase sr)
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
                "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt)" +
                "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt)";
            SqlCommand cmd = new SqlCommand (query, vDb.DBCon);

            cmd.Parameters.AddWithValue ("@GRNNo", sr.Grnno);
            cmd.Parameters.AddWithValue ("@GRNDate", sr.Grndate);
            cmd.Parameters.AddWithValue ("@InvoiceNo", sr.Invoiceno);
            cmd.Parameters.AddWithValue ("@InvoiceDate", sr.Invdate);
            cmd.Parameters.AddWithValue ("@SupplierName", sr.Suppliername);
            cmd.Parameters.AddWithValue ("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue ("@ProductName", sr.Productname);
            cmd.Parameters.AddWithValue ("@StyleCode", sr.Stylecode);
            cmd.Parameters.AddWithValue ("@ItemDesc", sr.Itemdesc);
            cmd.Parameters.AddWithValue ("@Quantity", sr.Qty);
            cmd.Parameters.AddWithValue ("@MRP", sr.Mrp);
            cmd.Parameters.AddWithValue ("@MRPValue", sr.Mrpvalue);
            cmd.Parameters.AddWithValue ("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue ("@CostValue", sr.Costvalue);
            cmd.Parameters.AddWithValue ("@TaxAmt", sr.Taxamt);
            int x = InsertQuerySql (cmd);
            //TODO: do it thread 
            vOti.PurchaseToStock (sr);
            return x;
        }
    }

    class ObjectToItem
    {
        ProductItemsDB pIDB;
        public ObjectToItem()
        {
            pIDB = new ProductItemsDB ();
        }
        protected string ToSize(string stylecode)
        {
            if ( Basic.IsNumeric (stylecode) )
            {
                return "-1";
            }
            else if ( stylecode.Length > 8 && stylecode.Length < 10 )
            {
                //TODO: do verification for is style code.
                string s1 = stylecode.Substring (0, 4);
                string s2 = stylecode.Substring (4, 4);
                string s3 = stylecode.Substring (8);
                return s3;
            }
            else if ( stylecode.Length > 10 )
            {
                string s1 = stylecode.Substring (0, 4);
                string s2 = stylecode.Substring (4, 6);
                string s3 = stylecode.Substring (10);
                return s3;
            }
            else
            {
                return "-2";
            }
        }

        public void PurchaseToStock(Purchase p)
        {
            ProductItems pItem = new ProductItems ()
            {
                Barcode = p.Barcode,
                Cost = p.Cost,
                SupplierId = p.Suppliername,
                BrandName = "",
                ID = -1,
                ItemDesc = p.Itemdesc,
                MRP = p.Mrp,
                Qty = p.Qty,
                ProductName = p.Productname,
                Size = ToSize (p.Stylecode),
                StyleCode = p.Stylecode,
                Tax = p.Taxamt
            };
            Logs.LogMe ("Insert of Data is " + pIDB.InsertDataWithVerify (pItem));


        }
    }

    class UploaderFormVM
    {
        private BindingSource UploaedDataBindingSource;
        private SqlDataAdapter dataAdapter = new SqlDataAdapter ();
        private DataTable UploadedDataTable;
        public DataGridView UploadedDataGrid { get; private set; }
        public void RefreshDGV(DataGridView dgv, string query)
        {
            UploadedDataGrid = dgv;
            UploaedDataBindingSource = new BindingSource ();
            UploadedDataGrid.DataSource = UploaedDataBindingSource;
            try
            {
                DataTable table;
                dataAdapter = new SqlDataAdapter (query, (SqlConnection) DataBase.GetConnectionObject (ConType.SQLDB));
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder (dataAdapter);
                table = new DataTable ();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill (table);
                UploadedDataTable = table;
                UploadedDataGrid.AutoResizeColumns (DataGridViewAutoSizeColumnsMode.AllCells);
                UploaedDataBindingSource.DataSource = UploadedDataTable;

            }
            catch ( Exception )
            {
                return;
            }
        }


    }
    public class Querys
    {
        public static string qAll = "select* from SalesRegister";
        public static string qByDay = "select InvoiceDate, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by InvoiceDate";
        public static string qByYear = "select  DATEPART(YEAR, InvoiceDate)as Year, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(YEAR, InvoiceDate)";
        public static string qByMonth = "select  DATEPART(MM, InvoiceDate)as Month, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(MM, InvoiceDate)";
        public static string qByDayP = "select InvoiceDate , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by InvoiceDate";
        public static string qByMonthP = "select DATEPART(MM, InvoiceDate)as Month , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by DATEPART(MM, InvoiceDate)";
        public static string qByYearP = "select DATEPART(YEAR, InvoiceDate)as Year,  Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by DATEPART(Year, InvoiceDate)";
        public static string qAllPurchase = "select * from Purchase";
    }

    //TODO: Implement in second stage
    class PurchaseDB : DataOps<Purchase>
    {
        public override int InsertData(Purchase sr)
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
                "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt)" +
                "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt)";
            SqlCommand cmd = new SqlCommand (query, Db.DBCon);

            cmd.Parameters.AddWithValue ("@GRNNo", sr.Grnno);
            cmd.Parameters.AddWithValue ("@GRNDate", sr.Grndate);
            cmd.Parameters.AddWithValue ("@InvoiceNo", sr.Invoiceno);
            cmd.Parameters.AddWithValue ("@InvoiceDate", sr.Invdate);
            cmd.Parameters.AddWithValue ("@SupplierName", sr.Suppliername);
            cmd.Parameters.AddWithValue ("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue ("@ProductName", sr.Productname);
            cmd.Parameters.AddWithValue ("@StyleCode", sr.Stylecode);
            cmd.Parameters.AddWithValue ("@ItemDesc", sr.Itemdesc);
            cmd.Parameters.AddWithValue ("@Quantity", sr.Qty);
            cmd.Parameters.AddWithValue ("@MRP", sr.Mrp);
            cmd.Parameters.AddWithValue ("@MRPValue", sr.Mrpvalue);
            cmd.Parameters.AddWithValue ("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue ("@CostValue", sr.Costvalue);
            cmd.Parameters.AddWithValue ("@TaxAmt", sr.Taxamt);
            return cmd.ExecuteNonQuery ();
        }

        public override Purchase ResultToObject(List<Purchase> data, int index)
        {
            throw new NotImplementedException ();
        }

        public override Purchase ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException ();
        }

        public override List<Purchase> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            throw new NotImplementedException ();
        }
    }
}
