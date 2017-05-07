using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    class ProductCategory
    {
        public static readonly int Fabric = 1;
        public static readonly int RMZ = 2;
        public static readonly int Accessiories = 3;
        public static readonly int Tailoring = 4;
    }
    class StockItem
    {
        public int ID { set; get; }
        public int ProductId { set; get; }
        public double QTY { set; get; }

    }
    class ProductItems
    {
        public int ID { set; get; }
        public string StyleCode { get; set; }
        public string Barcode { get; set; }

        public string SupplierId { get; set; }

        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }

        public double MRP { get; set; }
        public double Tax { get; set; }
        public double Cost { get; set; }

        public string Size { get; set; }
        public double Qty { get; set; }

    }

    class Supplier
    {
        public int ID { get; set; }
        public string SuppilerName { get; set; }
        public string Warehouse { get; set; }
    }
    class SaleReturnInvoice
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string SaleInvoiceNo { get; set; }
        public string ReturnInvoiceNo { get; set; }
        public double TotalQty { get; set; }
        public int TotalReturnItem { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime OnDate { get; set; }
        public string NewSaleInvoiceNo { get; set; }
        public string Debit_CreditNotesNo { get; set; }
        public int SalesmanId { get; set; }

    }
    class SaleInvoice
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public DateTime OnDate { get; set; }
        public string InvoiceNo { get; set; }
        public int TotalItems { get; set; }
        public double TotalQty { get; set; }
        public double TotalBillAmount { get; set; }
        public double TotalDiscountAmount { get; set; }
        public double RoundOffAmount { get; set; }
        public double TotalTaxAmount { get; set; }

    }
    class PaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }

    }
    class CardTypes
    {
        public static readonly int DebitCard = 1;
        public static readonly int CreditCard = 2;
        public static readonly int AmexCard = 3;
    }

    class Cards
    {
        public static readonly int Visa = 1;
        public static readonly int MasterCard = 2;
        public static readonly int Mastro = 3;
        public static readonly int Amex = 4;
        public static readonly int Dinners = 5;
        public static readonly int Rupay = 6;

    }
    class CardPaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int CardType { get; set; }
        public double Amount { get; set; }
        public int AuthCode { get; set; }
        public int LastDigit { get; set; }
    }
    class SaleItem
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int ProcductID { get; set; }
        public double Qty { get; set; }
        public double BasicAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double TaxAmount { get; set; }
        public double BillAmount { get; set; }
        public int SalesmanID { get; set; }

    }
    //-----------------------------------------------------------------------

    class SaleInvoiceVM
    {
        //Fields
        SaleInvoiceDB sDB;
        ProductItemsDB pDB;
        private const string ManualSeries = "MI";
        private const long SeriesStart = 10000000;

        //Constructor
        public SaleInvoiceVM()
        {
            sDB = new SaleInvoiceDB ();
            pDB = new ProductItemsDB ();
        }
        public List<string> GetBarCodesList(int x)
        {
            return pDB.GetBarCodeList (x);
        }
        //Functions/Methods
        public void AddData() { }
        public int SaveData(SaleInvoice obj) { return sDB.InsertData (obj); }
        public void SaveItemsDetails() { }
        public void SavePaymentDetails() { }
        public void SaveCardDetails() { }

        public List<string> GetInvoiceNoList()
        {
            return sDB.GetInvoiceList ();
        }
        public List<SortedDictionary<string, string>> GetCustomerInfo(string mobileNo)
        {
            if ( mobileNo.Trim ().Length <= 0 )
                return null;
            return sDB.GetCustomerInfo (0, mobileNo, 2);
        }
        public List<SortedDictionary<string, string>> GetCustomerInfo(int custId)
        {
            return sDB.GetCustomerInfo (custId, "", 1);
        }
        public List<string> GetCustomerMobileNoList() { return sDB.GetCustomerMobileList (); }
        public List<SortedDictionary<string, string>> GetItemDetails(string barcode)
        {
            return sDB.GetItemDetails (barcode);
        }
        public ProductItems GetProductItemDetais(string barcode)
        {
            return pDB.GetProductItemDetais (barcode);
        }
        //Calucation Section 
        public void CalculateTotalSaleAmount() { }
        public void CalculateTotalTaxAmount() { }
        public void CalculateTotalDiscountAmount() { }

        internal SortedDictionary<string, string> GetInvoiceDetails(string invoiceNo)
        {
            throw new NotImplementedException ();
        }
        public int GetInvoiceNoList(ComboBox cBInvoiceNo)
        {
            List<string> itemList = GetInvoiceNoList ();
            foreach ( string item in itemList )
            {
                cBInvoiceNo.Items.Add (item);
            }
            return itemList.Count;
        }
        public int GetCustomerMobileNoList(ComboBox cBMobileNo)
        {
            List<string> itemList = GetCustomerMobileNoList ();
            foreach ( string item in itemList )
            {
                cBMobileNo.Items.Add (item);
            }
            return itemList.Count;
        }
        public InvoiceNo GenerateInvoiceNo()
        {
            InvoiceNo inv = new InvoiceNo (ManualSeries);
            //TODO: series Start should be changed every Finnical Year;
            //TODO: Should have option to check data and based on that generate it 
            string iNo = sDB.GetLastInvoiceNo ();
            if ( iNo.Length > 0 )
            {
                if ( iNo != "0" )
                {
                    Logs.LogMe ("Inv=" + iNo);
                    iNo = iNo.Substring (5);
                    Logs.LogMe ("Inv=" + iNo);
                    long i = long.Parse (iNo);
                    Logs.LogMe ("Inv=" + i);
                    inv.TP = i + 1;
                }
                else
                { inv.TP = SeriesStart + 1; }
            }
            else
            {
                //TODO: check future what happens and what condtion  come here
                inv.TP = SeriesStart + 1;
                Logs.LogMe ("Future check :Inv=" + inv.TP);

            }
            return inv;
        }
    }

    //-------------------------------------------------------------------------

    class SaleInvoiceDB : DataOps<SaleInvoice>
    {
        public List<SortedDictionary<string, string>> GetItemDetails(string barcode)
        {

            string sql = "select * from ProductItem where BarCode=@barcode ";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@barcode", barcode);
            return DataBase.GetSqlStoreProcedureString (cmd);
        }

        public string GetLastInvoiceNo()
        {
            string sql = "select ISNULL( Max(ID),0) from  " + Tablename;
            string inv = "";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            int ids = (int) cmd.ExecuteScalar ();

            if ( ids > 0 )
            {
                sql = "select InvoiceNo from " + Tablename + " where ID=" + ids;
                cmd.CommandText = sql;
                inv = (string) cmd.ExecuteScalar ();

            }
            else
            {
                inv = "0";
            }


            return inv;
        }


        public List<string> GetCustomerMobileList()
        {
            string sql = "select MobileNo from Customer";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetQueryString (cmd, "MobileNo");
        }
        public List<SortedDictionary<string, string>> GetCustomerInfo(int id, string mobileno, int searchMode)
        {   //TODO: Make it to send only one row.
            string sql = "select ID, FirstName, LastName, MobileNo from Customer where ";
            if ( searchMode == 1 )
            {
                sql = sql + " ID=" + id;
            }
            else if ( searchMode == 2 )
            {
                sql = sql + "MobileNo='" + mobileno + "'";
            }
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetSqlStoreProcedureString (cmd);

        }
        public List<string> GetInvoiceList()
        {
            string sql = "select InvoiceNo from SaleInvoice";//TODO: Urgent where OnDate=Year(2017)
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetQueryString (cmd, "InvoiceNo");
        }

        public override int InsertData(SaleInvoice obj)
        {
            throw new NotImplementedException ();
        }

        public override SaleInvoice ResultToObject(List<SaleInvoice> data, int index)
        {
            throw new NotImplementedException ();
        }

        public override SaleInvoice ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException ();
        }

        public override List<SaleInvoice> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            throw new NotImplementedException ();
        }
    }

    class ProductItemsDB : DataOps<ProductItems>
    {
        public List<string> GetBarCodeList(int x)
        {
            string sql = "select BarCode from " + this.Tablename + " where  Size = '44'";
            //select* from ProductItems where Size = '44'
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetQueryString (cmd, "BarCode");
        }
        public List<string> GetItemsList()
        {
            string sql = "select StyleCode from " + this.Tablename;
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetQueryString (cmd, "StyleCode");

        }
        public List<string> GetItemsList(string condition, string value)
        {
            string sql = "select StyleCode from " + this.Tablename +
                " where " + condition + "=@value";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@value", value);
            return DataBase.GetQueryString (cmd, "StyleCode");

        }

        public ProductItems GetProductItemDetais(string barcode)
        {
            return this.GetByColName ("Barcode", barcode);
        }
        public ProductItems GetProductItemByStyle(string styleCode)
        {
            return this.GetByColName ("StyleCode", styleCode);
        }

        public bool IsStyleCodeExist(string styleCode)
        {
            string sql = "select Count(StyleCode) from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@code", styleCode);
            int count = (int) cmd.ExecuteScalar ();
            if ( count > 0 )
                return true;
            else
                return false;
        }
        public double GetQty(string styleCode)
        {
            string sql = "select Qty from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@code", styleCode);

            object count = cmd.ExecuteScalar ();
            Console.WriteLine ("Qty={0}", count);
            double c = double.Parse ("" + count);
            return c;
        }
        public int UpdateQty(string styleCode, double qty, int mode)
        {
            double fQty = 0;
            double pQty = GetQty (styleCode);
            if ( mode == 0 )
                fQty = pQty + qty;
            else if ( mode == 1 )
                fQty = pQty - qty;
            string sql = "Update " + Tablename + " set Qty=" + fQty + "where StyleCode='" + styleCode + "'";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return cmd.ExecuteNonQuery ();

        }
        public int InsertDataWithVerify(ProductItems obj)
        {
            if ( IsStyleCodeExist (obj.StyleCode) )
            {
                //Add Qty
                return UpdateQty (obj.StyleCode, obj.Qty, 0);
            }
            else
            {
                return InsertData (obj);
            }
        }
        public override int InsertData(ProductItems obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@Barcode", obj.Barcode);
            cmd.Parameters.AddWithValue ("@BrandName", obj.BrandName);
            cmd.Parameters.AddWithValue ("@Cost", obj.Cost);
            cmd.Parameters.AddWithValue ("@ItemDesc", obj.ItemDesc);
            cmd.Parameters.AddWithValue ("@MRP", obj.MRP);
            cmd.Parameters.AddWithValue ("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue ("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue ("@Size", obj.Size);
            cmd.Parameters.AddWithValue ("@StyleCode", obj.StyleCode);
            cmd.Parameters.AddWithValue ("@SupplierId", obj.SupplierId);
            cmd.Parameters.AddWithValue ("@Tax", obj.Tax);

            return cmd.ExecuteNonQuery ();
        }

        public override ProductItems ResultToObject(List<ProductItems> data, int index)
        {
            return data [index];
        }

        public override ProductItems ResultToObject(SortedDictionary<string, string> data)
        {
           ProductItems pItem = new ProductItems ()
            {
                ID = Basic.ToInt (data ["ID"]),
                Tax = double.Parse (data ["Tax"]),
                SupplierId = data ["SupplierId"],
                StyleCode = data ["StyleCode"],
                Size = data ["Size"],
                Qty = double.Parse (data ["Qty"]),
                Barcode = data ["Barcode"],
                BrandName = data ["BrandName"],
                Cost = double.Parse (data ["Cost"]),
                ItemDesc = data ["ItemDesc"],
                MRP = double.Parse (data ["MRP"]),
                ProductName = data ["ProductName"]
            };
            return pItem;
        }

        public override List<ProductItems> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            List<ProductItems> listItem = new List<ProductItems> ();
            foreach ( var data in dataList )
            {
                ProductItems pItem = new ProductItems ()
                {
                    ID = Basic.ToInt (data ["ID"]),
                    Tax = double.Parse (data ["Tax"]),
                    SupplierId = data ["SupploerId"],
                    StyleCode = data ["StyleCode"],
                    Size = data ["Size"],
                    Qty = double.Parse (data ["Qty"]),
                    Barcode = data ["Barcode"],
                    BrandName = data ["BrandName"],
                    Cost = double.Parse (data ["Cost"]),
                    ItemDesc = data ["ItemDesc"],
                    MRP = double.Parse (data ["MRP"]),
                    ProductName = data ["ProductName"]
                };
                listItem.Add (pItem);

            }
            return listItem;
        }
    }

}
