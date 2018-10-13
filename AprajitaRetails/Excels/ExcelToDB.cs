using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AprajitaRetails
{
    //This Class is Obsolute and Use as base class to redesign Excel to DataBase
    public class ExcelToDB
    {
        private SqlConnection sqlDB;
        private DataBase DB;
        private BindingSource UploaedDataBindingSource;
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataTable UploadedDataTable;
        public DataGridView UploadedDataGrid { get; private set; }

        public void RefreshDGV( DataGridView dgv, string query )
        {
            UploadedDataGrid = dgv;
            UploaedDataBindingSource = new BindingSource();
            UploadedDataGrid.DataSource = UploaedDataBindingSource;
            try
            {
                if (sqlDB == null || sqlDB.State != ConnectionState.Open)
                    sqlDB = (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB);
                DataTable table;
                if (sqlDB != null && sqlDB.State == ConnectionState.Open)
                {
                    dataAdapter = new SqlDataAdapter(query, sqlDB);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    table = new DataTable
                    {
                        Locale = System.Globalization.CultureInfo.InvariantCulture
                    };
                    dataAdapter.Fill(table);
                    UploadedDataTable = table;
                    UploadedDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    UploaedDataBindingSource.DataSource = UploadedDataTable;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public ExcelToDB( )
        {
            DB = new DataBase(ConType.SQLDB);
            sqlDB = (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB);
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

        public int InsertQuerySql( SqlCommand cmd )
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

        public int SaveRowData( SaleItemWise sr )
        {
            string query = "INSERT INTO [dbo].[SalesRegister] " +
                "( [InvoiceNo], [InvoiceDate], [InvoiceType],  " +
                "BrandName,ProductName,ItemDescrpetion,BarCode,StyleCode" +
                "[Qty], [MRP], [Discount], [BasicAmt], [TaxAmount], " +
                "[RoundOff], LineTotal,[BillAmount], Salesman,[PaymentMode]) " +
                " VALUES (@Inv,@InvD , @InvT, @BName,@PName,@IDes,@BCode,@SCode" +
                "@QTY, @MRP, @Dis, @BAMT, @TAMT,  @ROFF,@Ltotal, @BILL,@Sman,  @PM)";
            ;
            SqlCommand cmd;
            if (sqlDB == null || sqlDB.State != ConnectionState.Open)
            {
                cmd = new SqlCommand(query, (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB));
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

        public int SaveRowData( SaleRegister sr )
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
                cmd = new SqlCommand(query, (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB));
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

        public int SaveRowData( Purchase sr )
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
                "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt)" +
                "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt)";
            SqlCommand cmd;
            if (sqlDB == null || sqlDB.State != ConnectionState.Open)
            {
                cmd = new SqlCommand(query, (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB));
            }
            else
            {
                cmd = new SqlCommand(query, sqlDB);
            }
            cmd.Parameters.AddWithValue("@GRNNo", sr.GRNNo);
            cmd.Parameters.AddWithValue("@GRNDate", sr.GRNDate);
            cmd.Parameters.AddWithValue("@InvoiceNo", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvoiceDate", sr.InvoiceDate);
            cmd.Parameters.AddWithValue("@SupplierName", sr.SupplierName);
            cmd.Parameters.AddWithValue("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue("@ProductName", sr.ProductName);
            cmd.Parameters.AddWithValue("@StyleCode", sr.StyleCode);
            cmd.Parameters.AddWithValue("@ItemDesc", sr.ItemDesc);
            cmd.Parameters.AddWithValue("@Quantity", sr.Quantity);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@MRPValue", sr.MRPValue);
            cmd.Parameters.AddWithValue("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue("@CostValue", sr.CostValue);
            cmd.Parameters.AddWithValue("@TaxAmt", sr.TaxAmt); return InsertQuerySql(cmd);
        }
    }
}