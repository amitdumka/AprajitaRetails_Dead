using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

//TODO: Create Function or class for Database Backup, Daily, Weekaly , Monthly, Quartaly, Yealry
//TODO: While First Run Ask for location of the database. 
//TODO: keep provising to change location of database. 
// TODO: Add password to database
namespace AprajitaRetails
{
    class DataBase : IDisposable
    {
        public static string DataBaseName = "aprajitaRetails";
        static DBHelper db;
        public static int DBType = ConType.SQLDB;
        protected virtual void Dispose(bool disposing)
        {
            if ( disposing )
            {
                // dispose managed resources
                db.Dispose ();
            }
            // free native resources
        }
        public void Dispose()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }
        //Version 2
        public static int IsTableWithDefaultExit(string tablename)
        {
            string query = "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                "  WHERE  TABLE_NAME = @tablename))" +
                "SELECT 1 AS Result ELSE SELECT 0 AS Result;";
            SqlCommand cmd = ( (SqlConnection) GetConnectionObject (ConType.SQLDB) ).CreateCommand ();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue ("@tablename", tablename);
            int result = (int) cmd.ExecuteScalar ();
            Console.WriteLine ("ok1=" + result);
            if ( result == 1 )
            {
                cmd.CommandText = "Select Count(*)as CTR from " + tablename;
                result = (int) cmd.ExecuteScalar ();
                Console.WriteLine ("ok2=" + result);
                if ( result > 0 )
                    return 2;
                else
                    return -2;
            }
            else
                return -1;
        }
        public static bool IsTableExit(string tableName)
        {
            string query = "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                "  WHERE  TABLE_NAME = @tablename))" +
                "SELECT 1 AS Result ELSE SELECT 0 AS Result;";
            SqlCommand cmd = ( (SqlConnection) GetConnectionObject (ConType.SQLDB) ).CreateCommand ();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue ("@tablename", tableName);

            int result = (int) cmd.ExecuteScalar ();
            Console.WriteLine ("table check of {0} is result ={1}", tableName, result);
            if ( result == 1 )
                return true;
            else
                return false;
        }
        public SqlConnection DBCon { private set; get; }

        public DataBase(int type)
        {
            DBHelper.SetDataBaseName (DataBaseName);
            db = new DBHelper ();
            DBType = type;
            if ( DBType == ConType.SQLDB )
                DBCon = (SqlConnection) db.GetConnectioObject (DBType);
            Logs.LogMe ("DataBase(): Connection is Created");

        }
        public void ConnnetDB()
        {
            db.ConnectDB (DBType);

        }
        public void CloseDB()
        {
            if ( DBType == ConType.SQLDB )
            {
                db.CloseDB ();
            }
            if ( DBType == ConType.OLEDB )
            {
                db.CloseDB ();
            }

        }
        public static Object GetConnectionObject(int type)
        {
            Logs.LogMe ("DataBase.GetConnectionObject=" + type);
            return new DBHelper ().GetConnectioObject (type);
        }
        public static int GetSqlStoreProcedureReturnInt(SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            cmd.Connection = con;
            var returnParameter = cmd.Parameters.Add ("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            int ctr = cmd.ExecuteNonQuery ();
            var result = returnParameter.Value;
            con.Close ();
            return Int32.Parse ("" + result);

        }
        public static List<string> GetSqlStoreProcedureString(string sp, string colName)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = sp;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<string> data = new List<string> ();
            ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader ();

                while ( reader.Read () )
                {
                    data.Add ((string) reader [colName]);
                    count++;
                }
            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();

            }
            return data;
        }

        public static List<int> GetSqlStoreProcedureInt(String storeProc, string colName)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = storeProc;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<int> data = new List<int> ();
            ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader ();

                while ( reader.Read () )
                {
                    data.Add ((int) reader [colName]);
                    count++;
                }
            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();

            }
            return data;
        }
        public static List<SortedDictionary<string, string>> GetSqlStoreProcedureString(string sp)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = sp;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<SortedDictionary<string, string>> data = new List<SortedDictionary<string, string>> ();
            ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader ();

                while ( reader.Read () )
                {
                    int noOfField = reader.FieldCount;
                    SortedDictionary<string, string> sdData = new SortedDictionary<string, string> ();
                    for ( int j = 0 ; j < noOfField ; j++ )
                    {
                        sdData.Add (reader.GetName (j), (string) reader.GetValue (j));

                    }
                    data.Add (sdData);
                    count++;

                }
            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();

            }
            return data;
        }

        public static List<SortedDictionary<string, string>> GetSqlStoreProcedureString(SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            cmd.Connection = con;
            int count = 0;
            List<SortedDictionary<string, string>> data = new List<SortedDictionary<string, string>> ();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader ();

                while ( reader.Read () )
                {
                    int noOfField = reader.FieldCount;
                    SortedDictionary<string, string> sdData = new SortedDictionary<string, string> ();
                    for ( int j = 0 ; j < noOfField ; j++ )
                    {
                        sdData.Add (reader.GetName (j), "" + reader.GetValue (j));

                    }
                    data.Add (sdData);
                    count++;

                }
            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message, "GetSqlStoreProcedure");
                Logs.LogMe ("GetSqlStoreProcedure:Error= " + ex.Message);
            }
            finally
            {
                con.Close ();

            }
            return data;
        }


        public void SetDataBasePath(string path)
        {
            //TODO:SetDatabasepath
        }
        public void SetConnectionString()
        {
            //TODO:SetConnnectionString
        }
        public void SetDataBasePassword(string username, string password)
        {
            //TODO:setdatabase password
        }

        public static object QuerryReturn(String sql)
        {
            SqlCommand cmd;

            if ( DBType == ConType.SQLDB )
            {
                cmd = db.QueryStrSql (sql);
                return cmd.ExecuteScalar ();
            }
            else if ( DBType == ConType.OLEDB )
            {
                OleDbCommand ole = db.QueryStrOle (sql);
                return ole.ExecuteScalar ();
                //TODO: read operation
            }
            else
                return -999;


        }

        /// <summary>
        /// Single coloum result and int
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int QuerryReturnInt(String sql)
        {
            SqlCommand cmd;

            if ( DBType == ConType.SQLDB )
            {
                cmd = db.QueryStrSql (sql);
                return (int) cmd.ExecuteScalar ();
            }
            else if ( DBType == ConType.OLEDB )
            {
                OleDbCommand ole = db.QueryStrOle (sql);
                return (int) ole.ExecuteScalar ();
                //TODO: read operation
            }
            else
                return -1;


        }


        // Verson :1

        public void Querry(String sql)
        {

            if ( DBType == ConType.SQLDB )
            {
                db.QueryStrSql (sql);
            }
            if ( DBType == ConType.OLEDB )
            {
                db.QueryStrSql (sql);
            }

        }
        public int Insert(String sql)
        {
            if ( DBType == ConType.SQLDB )
            {
                return db.InsertQuerySql (sql);

            }
            if ( DBType == ConType.OLEDB )
            {
                return db.InsertQueryOle (sql);
            }
            return -1;
        }
        public int Delete(String sql)
        {
            if ( DBType == ConType.SQLDB )
            {
                return db.NonQuerySql (sql);
            }
            if ( DBType == ConType.OLEDB )
            {
                return db.NonQueryOle (sql);
            }
            return -1;
        }
        public int Update(String sql)
        {
            if ( DBType == ConType.SQLDB )
            {
                return db.NonQuerySql (sql);
            }
            if ( DBType == ConType.OLEDB )
            {
                return db.NonQueryOle (sql);
            }
            return -1;

        }

        public int Insert(System.Data.SqlClient.SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            cmd.Connection = con;
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery ();

            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();
            }
            return count;

        }

        public int InsertStoreProcedure(System.Data.SqlClient.SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection) GetConnectionObject (ConType.SQLDB);
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery ();

            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();
            }
            return count;

        }

        public int InsertStoreProcedure(System.Data.OleDb.OleDbCommand cmd)
        {
            OleDbConnection con = (OleDbConnection) GetConnectionObject (ConType.OLEDB);
            cmd.Connection = con;
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery ();

            }
            catch ( Exception ex )
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show (ex.Message);
            }
            finally
            {
                con.Close ();
            }
            return count;


        }


    }

    class BackupData
    {

    }

}


