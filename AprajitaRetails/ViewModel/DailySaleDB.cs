using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetails.Data;
using CyberN.TableCreator;

namespace AprajitaRetails.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast
    class DailySaleDB : iDatabase<DailySale>
    {
        public static string Tablename = "DailySale";
        DataBase Db;
        TableClass t;
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
            t = new TableClass (typeof (DailySale));
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
}
