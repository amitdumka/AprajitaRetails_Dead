using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;
using AprajitaRetails.DataModel;

namespace AprajitaRetails.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast

    class DailySalesVM
    {
        DailySaleDB DB;
        public DailySalesVM()
        {
            Logs.LogMe ("DailySaleVM: Creating DailySaleDB Object");
            DB = new DailySaleDB ();
            Logs.LogMe ("DailySaleVM: DailySaleDB object created");
        }

        public string AddData()
        {
            return "";
            //GenerateInvoiceNo ();

        }

        public string GenerateInvoiceNo()
        {

            throw new NotImplementedException ();
        }

        public int GetCustomerID(string mobile)
        {  //TODO: Make CustomerID function static
            return 111;
            //TODO: Remove when Implemented
            CustomerDB cDM = new CustomerDB ();
            return cDM.GetID ("MobileNo", mobile);

        }

        public bool SaveData(DailySaleDM data)
        {
            bool status = false;
            DailySale dailySale = new DailySale ()
            {
                ID = -1,
                Discount = data.Discount,
                Fabric = data.Fabric,
                Amount = data.Amount,
                InvoiceNo = data.InvoiceNo,
                RMZ = data.RMZ,
                SaleDate = data.SaleDate,
                Tailoring = data.Tailoring,
                PaymentMode = data.PaymentMode,
                CustomerID = GetCustomerID (data.CustomerMobileNo)
            };
            if ( DB.InsertData (dailySale) > 0 )
            {
                status = true;
                Logs.LogMe ("DailySale is added!");
            }
            if ( data.NewCustomer == 1 )
            {
                NewCustomer newCust = new NewCustomer ()
                {
                    CustomerID = dailySale.CustomerID,
                    ID = -1,
                    InvoiceNo = data.InvoiceNo,
                    OnDate = data.SaleDate,
                    CustomerFullName = data.CustomerFullName
                };
                NewCustomerDB nDB = new NewCustomerDB ();
                if ( nDB.Insert (newCust) > 0 )
                {
                    status = true;
                }
                else
                {
                    if ( status )
                    {

                        Logs.LogMe ("New Customer Data not able to add!");
                    }
                }
            }
            return status;
        }

        public void InsertInvoiceDetails(DailySaleDM data)
        {

        }

        public void GetInvoiceDetails(string invoiceno)
        {

        }

        public void UpdateInvoiceDetails(DailySaleDM data)
        {

        }

        public void DeleteInvoiceNo(string invoiceno)
        {

        }

        /// <summary>
        /// Get all Payment Modes
        /// </summary>
        /// <returns></returns>
        public List<PaymentMode> GetPaymentTypes()
        {
            List<PaymentMode> listItem = new List<PaymentMode> ();
            Logs.LogMe ("GetPaymentTypes():Calling GetDataForm");
            List<SortedDictionary<string, string>> result = DB.GetDataFrom ("PaymentMode");
            foreach ( SortedDictionary<string, string> item in result )
            {
                PaymentMode mode = new PaymentMode ()
                {
                    ID = Int32.Parse (item ["ID"]),
                    PayMode = item ["PayMode"]
                };
                listItem.Add (mode);
            }
            return listItem;
        }
    }

    class DailySaleDB : iDatabase<DailySale>
    {
        public static string Tablename = "DailySale";
        DataBase Db;
        TableCreator.TableClass t;
        string InsertSqlQuery = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        public List<SortedDictionary<string, string>> GetDataFrom(string tabName)
        {   //TODO: Move to Static one
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + tabName;
            Logs.LogMe ("GetDataFrom:TableName=" + tabName);
            return DataBase.GetSqlStoreProcedureString (cmd);

        }


        /// <summary>
        /// Send One DailySale Record
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DailySale ToDailySale(List<SortedDictionary<string, string>> data)
        {
            DailySale dailySale;
            SortedDictionary<string, string> element = data [0];

            dailySale = new DailySale ()
            {
                Amount = Double.Parse (element ["Amount"]),
                CustomerID = Basic.ToInt (element ["CustomerId"]),
                Discount = Double.Parse (element ["Discount"]),
                ID = Basic.ToInt (element ["ID"]),
                InvoiceNo = element ["InvoiceNo"],
                SaleDate = DateTime.Parse (element ["SaleDate"])
            };

            return dailySale;

        }
        /// <summary>
        /// Send More then one DailySale Records
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<DailySale> ToDailySales(List<SortedDictionary<string, string>> data)
        {
            List<DailySale> listData = new List<DailySale> ();
            DailySale dailySale;
            foreach ( SortedDictionary<string, string> element in data )
            {
                dailySale = new DailySale ()
                {
                    Amount = Double.Parse (element ["Amount"]),
                    CustomerID = Basic.ToInt (element ["CustomerId"]),
                    Discount = Double.Parse (element ["Discount"]),
                    ID = Basic.ToInt (element ["ID"]),
                    InvoiceNo = element ["InvoiceNo"],
                    SaleDate = DateTime.Parse (element ["SaleDate"])
                };

            }
            return listData;

        }
        //public DailySaleDM ToDailySaleDM(List<SortedDictionary<string, string>> data)
        //{

        //}

        public DailySaleDB()
        {
            Logs.LogMe ("DailySaleDB: Init");
            Db = new DataBase (ConType.SQLDB);
            Logs.LogMe ("DailySaleDB: DB is created");
            t = new TableCreator.TableClass (typeof (DailySale));
            Logs.LogMe ("DailySaleDB:Table is Created");
            InsertSqlQuery = t.CreateInsertScript ();
            Logs.LogMe ("DailySaleDB:InsertQuery=" + InsertSqlQuery);
            Tablename = t.ClassName;
            Logs.LogMe ("DailySaleDB:ClassTableName=" + Tablename);
            if ( !IsTableExist () )
            {
                CreateTable ();
            }
        }

        public void CreateTable()
        {
            string sqlQ = t.CreateTableScript ();
            SqlCommand cmd = Db.DBCon.CreateCommand ();
            cmd.CommandText = sqlQ;
            Console.WriteLine ("Sql=" + sqlQ);
            Console.WriteLine ("Table Creation is ", cmd.ExecuteNonQuery ());
        }
        public int Delete(object obj)
        {
            throw new NotImplementedException ();
        }

        public int GenerateId()
        {
            throw new NotImplementedException ();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        /// <returns></returns>
        public DailySale GetByColName(string colName, Object colValue)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename + " where " + colName + "=@values";
            cmd.Parameters.AddWithValue ("@values", colValue);
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            DailySale dailySale = ToDailySale (resultData);
            return dailySale;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DailySale GetByID(int id)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename + " where ID =" + id;
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            DailySale dailySale = ToDailySale (resultData);
            return dailySale;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        /// <returns></returns>
        public int GetID(string colName, Object colValue)
        {    //TODO make it genric put in abstract
            SqlConnection con = (SqlConnection) DataBase.GetConnectionObject (ConType.SQLDB);
            string cmdText = "select ID from " + Tablename + " where " + colName + "= @values";
            SqlCommand cmd = new SqlCommand (cmdText, con);
            cmd.Parameters.AddWithValue ("@values", colValue);
            return (int) cmd.ExecuteScalar ();
        }
        /// <summary>
        /// Insert DailySale
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertData(DailySale obj)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = InsertSqlQuery;
            cmd.Parameters.AddWithValue ("@CustomerId", obj.CustomerID);
            cmd.Parameters.AddWithValue ("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue ("@Discount", obj.Discount);
            cmd.Parameters.AddWithValue ("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue ("@SaleDate", obj.SaleDate);
            cmd.Parameters.AddWithValue ("@Tailoring", obj.Tailoring);
            cmd.Parameters.AddWithValue ("@RMZ", obj.RMZ);
            cmd.Parameters.AddWithValue ("@PaymentMode", obj.PaymentMode);
            cmd.Parameters.AddWithValue ("@Fabric", obj.Fabric);
            return Db.Insert (cmd);
        }

        public bool IsTableExist()
        {
            //TODO: Make Class or const field from where it should fetch tablename
            return DataBase.IsTableExit (Tablename);
        }

        public int UpdateData(DailySale obj)
        {
            throw new NotImplementedException ();
        }

        public List<DailySale> GetAllRecord()
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename;
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            return ToDailySales (resultData);

        }
    }
    public class NewCustomerDB
    {
        DataBase DB;
        TableCreator.TableClass t;
        string InsertSqlQuery = "";
        string Tablename = "NewCustomer";
        public NewCustomerDB()
        {
            DB = new DataBase (ConType.SQLDB);
            t = new TableCreator.TableClass (typeof (NewCustomer));
            InsertSqlQuery = t.CreateInsertScript ();
            Tablename = t.ClassName;
            if ( !IsTableExit () )
            {
                CreateTable ();
            }

        }
        public int CreateTable()
        {
            string tab = t.CreateTableScript ();
            SqlCommand cmd = new SqlCommand (tab, DB.DBCon);
            return cmd.ExecuteNonQuery ();

        }
        public bool IsTableExit()
        {
            return DataBase.IsTableExit (Tablename);
        }
        public int Insert(NewCustomer obj)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = InsertSqlQuery;
            cmd.Parameters.AddWithValue ("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue ("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue ("@OnDate", obj.OnDate);
            cmd.Parameters.AddWithValue ("@CustomerFullName", obj.CustomerFullName);
            return DB.Insert (cmd);
        }
        public List<NewCustomer> GetAll()
        {
            throw new NotImplementedException ();
        }

        public NewCustomer GetById()
        {
            throw new NotImplementedException ();
        }
        public NewCustomer GetByColName(string colName, string colValue)
        {
            throw new NotImplementedException ();
        }


    }
    public interface iDatabase<T>
    {

        int InsertData(T obj);
        int UpdateData(T obj);
        int Delete(object obj);
        bool IsTableExist();
        int GetID(string colName, object colValue);
        T GetByID(int id);
        T GetByColName(string colName, object colValue);
        int GenerateId();
        List<T> GetAllRecord();


    }
}
