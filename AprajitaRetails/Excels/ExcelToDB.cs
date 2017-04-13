using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public class ExcelToDB
    {
        public static string SqlDBName = "aprajitaRetails.mdf";
        private string ConStr = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\" + SqlDBName + ";Integrated Security = True;Connect TimeOut=30";
        private SqlConnection sqlDB;

        private BindingSource PrescribedMedBindingSoure;
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataTable PrescribedMedTable;
        public DataGridView DGVPrescribedMed { get; private set; }

        public void RefreshDGV(DataGridView dgv, string query)
        {
            DGVPrescribedMed = dgv;
            PrescribedMedBindingSoure = new BindingSource();
            DGVPrescribedMed.DataSource = PrescribedMedBindingSoure;
            try
            {
                sqlDB = GetConnection();
                DataTable table;
                if (sqlDB != null && sqlDB.State == ConnectionState.Open)
                {
                    dataAdapter = new SqlDataAdapter(query, sqlDB);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    PrescribedMedTable = table;
                    DGVPrescribedMed.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    PrescribedMedBindingSoure.DataSource = PrescribedMedTable;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public SqlConnection GetConnection()
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Open)
                return sqlDB;
            if (sqlDB != null && sqlDB.State != ConnectionState.Open)
            {
                try
                {
                    sqlDB.Open();
                    return sqlDB;
                }
                catch (Exception)
                {
                    return sqlDB = null;
                    //throw;
                }
            }
            sqlDB = new SqlConnection(ConStr);
            try
            {
                sqlDB.Open();
                return sqlDB;
            }
            catch (Exception)
            {
                return sqlDB = null;
                //throw;
            }
        }

        public ExcelToDB()
        {
            sqlDB = new SqlConnection(ConStr);
            try
            {
                sqlDB.Open();
            }
            catch (Exception)
            {
                sqlDB = null;
                //throw;
            }
        }


        public int InsertQuerySql(SqlCommand cmd)
        {
            try
            {
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Console.WriteLine("Insert done ");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Insert Failed " + cmd.CommandText);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("InsertExp: " + e.Message + "\t" + cmd.CommandText);
                return -1;
            }
        }

        public int SaveRowData(SaleItemWise sr)
        {
            string query = "INSERT INTO [dbo].[SalesRegister] " +
                "( [InvoiceNo], [InvoiceDate], [InvoiceType],  " +
                "BrandName,ProductName,ItemDescrpetion,BarCode,StyleCode"+
                "[Qty], [MRP], [Discount], [BasicAmt], [TaxAmount], " +
                "[RoundOff], LineTotal,[BillAmount], Salesman,[PaymentMode]) " +     
                " VALUES (@Inv,@InvD , @InvT, @BName,@PName,@IDes,@BCode,@SCode" +
                "@QTY, @MRP, @Dis, @BAMT, @TAMT,  @ROFF,@Ltotal, @BILL,@Sman,  @PM)";;
            SqlCommand cmd;
            if (sqlDB == null || sqlDB.State != ConnectionState.Open)
            {
                cmd = new SqlCommand(query, GetConnection());
            }
            else
            {
                cmd = new SqlCommand(query, sqlDB);
            }

            // cmd.CommandText = query;
            //cmd.Connection = GetConnection();
            cmd.Parameters.AddWithValue("@Inv", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvD", sr.InvDate);
            cmd.Parameters.AddWithValue("@InvT", sr.InvType);
            cmd.Parameters.AddWithValue("@QTY", sr.QTY);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@Dis", sr.Discount);
            cmd.Parameters.AddWithValue("@BAMT", sr.BasicRate);
            cmd.Parameters.AddWithValue("@TAMT", sr.Tax);
            cmd.Parameters.AddWithValue("@ROFF", sr.RoundOff);
            cmd.Parameters.AddWithValue("@BILL", sr.BillAmnt);
            cmd.Parameters.AddWithValue("@PM", sr.PaymentType);
            cmd.Parameters.AddWithValue("@Sman", sr.Saleman);
            cmd.Parameters.AddWithValue("@BCode", sr.Barcode);
            cmd.Parameters.AddWithValue("@SCode", sr.StyleCode);
            cmd.Parameters.AddWithValue("@Ltotal", sr.LineTotal);
            cmd.Parameters.AddWithValue("@BName", sr.Barcode);
            cmd.Parameters.AddWithValue("@PName", sr.StyleCode);
            cmd.Parameters.AddWithValue("@IDes", sr.LineTotal);
            return InsertQuerySql(cmd);
        }

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
            SqlCommand cmd;
            if (sqlDB == null || sqlDB.State != ConnectionState.Open)
            {
                cmd = new SqlCommand(query, GetConnection());
            }
            else
            {
                cmd = new SqlCommand(query, sqlDB);
            }

            // cmd.CommandText = query;
            //cmd.Connection = GetConnection();
            cmd.Parameters.AddWithValue("@Inv", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvD", sr.InvDate);
            cmd.Parameters.AddWithValue("@InvT", sr.InvType);
            cmd.Parameters.AddWithValue("@QTY", sr.QTY);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@Dis", sr.Discount);
            cmd.Parameters.AddWithValue("@BAMT", sr.BasicRate);
            cmd.Parameters.AddWithValue("@TAMT", sr.Tax);
            cmd.Parameters.AddWithValue("@ROFF", sr.RoundOff);
            cmd.Parameters.AddWithValue("@BILL", sr.BillAmnt);
            cmd.Parameters.AddWithValue("@PM", sr.paymentType);
            //cmd.Parameters.AddWithValue("@CO", sr.coupon);
            //cmd.Parameters.AddWithValue("@CAMT", sr.couponAmt);
            //cmd.Parameters.AddWithValue("@TFG", sr.Tailoring);
            //cmd.Parameters.AddWithValue("@INST", sr.instaorder);
            return InsertQuerySql(cmd);
        }
        public int SaveRowData(Purchase sr)
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
                "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt)" +
                "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt)";
            SqlCommand cmd;
            if (sqlDB == null || sqlDB.State != ConnectionState.Open)
            {
                cmd = new SqlCommand(query, GetConnection());
            }
            else
            {
                cmd = new SqlCommand(query, sqlDB);
            }
            cmd.Parameters.AddWithValue("@GRNNo", sr.Grnno);
            cmd.Parameters.AddWithValue("@GRNDate", sr.Grndate);
            cmd.Parameters.AddWithValue("@InvoiceNo", sr.Invoiceno);
            cmd.Parameters.AddWithValue("@InvoiceDate", sr.Invdate);
            cmd.Parameters.AddWithValue("@SupplierName", sr.Suppliername);
            cmd.Parameters.AddWithValue("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue("@ProductName", sr.Productname);
            cmd.Parameters.AddWithValue("@StyleCode", sr.Stylecode);
            cmd.Parameters.AddWithValue("@ItemDesc", sr.Itemdesc);
            cmd.Parameters.AddWithValue("@Quantity", sr.Qty);
            cmd.Parameters.AddWithValue("@MRP", sr.Mrp);
            cmd.Parameters.AddWithValue("@MRPValue", sr.Mrpvalue);
            cmd.Parameters.AddWithValue("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue("@CostValue", sr.Costvalue);
            cmd.Parameters.AddWithValue("@TaxAmt", sr.Taxamt);
            return InsertQuerySql(cmd);
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
}
/*
 GRNNo	GRNDate	Invoice No	Invoice Date	Supplier Name	Barcode	Product Name	Style Code
 Item Desc	Quantity	MRP	MRP Value	Cost	Cost Value	TaxAmt
C33GR500001	16/02/2016	DTE5000523	25/01/2016	TAS RMG Warehouse - Bangalore	8907259105888
Apparel/Mens Formal/Shirts	USSH3877XL	Shirts-FS-Black	1.00	1999.00	1999.00	1287.76	1287.76	0.00
 



    GRNNo,GRNDate,InvoiceNo,InvoiceDate,SupplierName,Barcode,ProductName,StyleCode,
    ItemDesc,	Quantity,MRP,MRPValue,Cost,CostValue,TaxAmt
    */
