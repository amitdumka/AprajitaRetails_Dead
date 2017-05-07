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

        public List<string> GetMobileNoList()
        {
            string sql = "select  MobileNo from Customer	  Where MobileNo <> 'NA'";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            return DataBase.GetQueryString (cmd, "MobileNo");

        }

        public string GetCustomerName(string mobileno)
        {
            string sql = "select FirstName, LastName from Customer where MobileNo=@mob";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@mob", mobileno);
            SqlDataReader reader = cmd.ExecuteReader ();
            string custname = "";
            if ( reader != null && reader.HasRows )
            {
                reader.Read ();
                custname = reader ["FirstName"] + " " + reader ["LastName"];
                Logs.LogMe ("Cust " + reader [0]);
            }
            else
                Logs.LogMe ("Customer: Error " + mobileno);
            reader.Close ();
            return custname;
        }
        public string GetCustomerName(int Id)
        {
            string sql = "select FirstName, LastName, MobileNo from Customer where ID=" + Id;
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            SqlDataReader reader = cmd.ExecuteReader ();
            string custname = "";
            if ( reader != null && reader.HasRows )
            {
                reader.Read ();
                custname = reader ["MobileNo"] + " " + reader ["FirstName"] + " " + reader ["LastName"] + "  ";
                Logs.LogMe ("Cust " + reader [0]);
            }
            else
                Logs.LogMe ("Customer: Error " + Id);
            reader.Close ();
            return custname;
        }

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
                Fabric = Basic.ToInt (element ["Fabric"]),
                PaymentMode = Basic.ToInt (element ["PaymentMode"]),
                RMZ = Basic.ToInt (element ["RMZ"]),
                Tailoring = Basic.ToInt (element ["Tailoring"]),
                Amount = Double.Parse (element ["Amount"]),
                CustomerID = Basic.ToInt (element ["CustomerID"]),
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
            SqlCommand cmd = new SqlCommand ()
            {
                CommandText = InsertSqlQuery
            };
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

        public List<SortedDictionary<string, string>> GetSaleList()
        {
            string sql = " select  InvoiceNo, Amount, ID from DailySale " +
                    " where DATEDIFF(day, SaleDate,@dates)= 0 order by ID Desc ";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@dates", DateTime.Now.ToShortDateString ());

            return DataBase.GetSqlStoreProcedureString (cmd);

        }

        public SaleInfo GetSaleInfo(DateTime saleDate)
        {

            Logs.LogMe ("Sale Info Date: " + saleDate.ToShortDateString ());
            string cd = "" + saleDate.Month + "/" + saleDate.Day + "/" + saleDate.Year;
            string cy = "" + saleDate.Year;
            string cm = "" + saleDate.Month;
            Logs.LogMe ("Date " + cd + "=" + saleDate.ToLongDateString ());

            SqlCommand cmd = new SqlCommand (SaleQuery.QueryAll, Db.DBCon);
            cmd.Parameters.AddWithValue ("@CDate", cd);
            cmd.Parameters.AddWithValue ("@CYear2", cy);
            cmd.Parameters.AddWithValue ("@CMon", cm);
            cmd.Parameters.AddWithValue ("@CYear", cy);
            SqlDataReader reader = cmd.ExecuteReader ();
            SaleInfo info = new SaleInfo ();
            if ( reader != null && reader.HasRows )
            {
                reader.Read ();
                info.MonthlySale = "" + reader ["MAmount"];
                info.TodaySale = "" + reader ["TAmount"];
                info.YearlySale = "" + reader ["YAmount"];
                Logs.LogMe ("Sale Info: " + reader ["TAmount"] + "==" + reader ["MAmount"] + "==" + reader ["YAmount"]);

            }
            reader.Close ();
            return info;

        }

        public SaleInfo GetSaleInfo()
        {
            DateTime s = DateTime.Now;
            Logs.LogMe ("Sale Info Date: " + s.ToShortDateString ());
            string cd = "" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            string cy = "" + DateTime.Now.Year;
            string cm = "" + DateTime.Now.Month;
            Logs.LogMe ("Date " + cd + "=" + DateTime.Now.ToLongDateString ());

            SqlCommand cmd = new SqlCommand (SaleQuery.QueryAll, Db.DBCon);
            cmd.Parameters.AddWithValue ("@CDate", cd);
            cmd.Parameters.AddWithValue ("@CYear2", cy);
            cmd.Parameters.AddWithValue ("@CMon", cm);
            cmd.Parameters.AddWithValue ("@CYear", cy);
            SqlDataReader reader = cmd.ExecuteReader ();
            SaleInfo info = new SaleInfo ();
            if ( reader != null && reader.HasRows )
            {
                reader.Read ();
                info.MonthlySale = "" + reader ["MAmount"];
                info.TodaySale = "" + reader ["TAmount"];
                info.YearlySale = "" + reader ["YAmount"];
                Logs.LogMe ("Sale Info: " + reader ["TAmount"] + "==" + reader ["MAmount"] + "==" + reader ["YAmount"]);

            }
            reader.Close ();
            return info;

        }
    }
    public static class SaleQuery
    {
        public static string qYearly = "select sum(Amount),DATEPART(YY,SaleDate) as Year from DailySale " +
            "where DATEPART(YY, SaleDate)=@year group by DATEPART(YY, SaleDate)";
        public static string QMontly = "select 	 sum(Amount) as TAmount,DATEPART(MM,SaleDate) as Months, " +
            "DATEPART(YY,SaleDate) as Years from DailySale" +
             "where DATEPART(YY, SaleDate)=@year    and DATEPART(MM, SaleDate)=@month" +
              "group by DATEPART(MM, SaleDate)  , DATEPART(YY, SaleDate)";
        public static string QDaily = "select  Sum(Amount) as TAmount  from DailySale "
           + "where datediff(day, SaleDate,@date) = 0 ";

        public static string QueryAll = "select TAmount, MAmount, YAmount  from " +
        "(select Sum(Amount) as TAmount from DailySale  where datediff(day, SaleDate, @CDate) = 0  ) as DS," +
         "(select Sum(Amount) as MAmount ,DatePart(MM, SaleDate) as Months, DatePart(YY, SaleDate) as Years from DailySale " +
         "where    DatePart(MM, SaleDate)=@CMon	  and DatePart(YY, SaleDate)=@CYear " +
         "Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ) as MS , " +
         " (  select Sum(Amount) as YAmount , DatePart(YY, SaleDate) as Years from DailySale " +
         " where   DatePart(YY, SaleDate)=@CYear2   Group By DatePart(YY, SaleDate) ) as YS";


    }
}


/*
 
select  Sum(Amount) as TAmount  from DailySale
 where datediff(day, SaleDate, '2017/04/29') = 0


 select Sum(Amount) as MAmount ,DatePart(MM, SaleDate) as Months, DatePart(YY, SaleDate) as Years from DailySale
 where 	  DatePart(MM, SaleDate)=04	  and DatePart(YY, SaleDate)=2017
 Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ;


 select Sum(Amount) as YAmount , DatePart(YY, SaleDate) as Years from DailySale
 where 	 DatePart(YY, SaleDate)=2017
 Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ;
 
    */
