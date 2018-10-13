using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public class ConType
    {
        public static readonly int SQLDB = 1;
        public static readonly int OLEDB = 2;
    }

    internal class DBHelper : IDisposable
    {
        public static String OleDBName = "database.mdf";
        public static String SqlDBName = "database.mdf";
        private String ConStr = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\" + SqlDBName + ";Integrated Security = True;Connect TimeOut=30";
        private String oleConStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + OleDBName + "; Jet OLEDB:Engine Type=5 ";
        private OleDbConnection oleDB;
        private SqlConnection sqlDB;

        public DBHelper( )
        {
            Logs.LogMe("DBHelper:()");
        }

        protected virtual void Dispose( bool disposing )
        {
            if (disposing)
            {
                // dispose managed resources
                //newFile.Close();
                this.oleDB.Dispose();
                this.sqlDB.Dispose();
            }
            // free native resources
        }

        public void Dispose( )
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static void SetDataBaseName( string database )
        {
            OleDBName = database + ".mdf";
            SqlDBName = database + ".mdf";
            Logs.LogMe("Setting Both Database Name to " + database);
        }

        /// <summary>
        /// Get Connection Objects
        /// </summary>
        /// <param name="DBTypes"></param>
        /// <returns></returns>
        public Object GetConnectioObject( int DBTypes )
        {
            Logs.LogMe("Preparing to Send Connection Object");
            if (DBTypes == ConType.SQLDB)
            {
                sqlDB = new SqlConnection(ConStr);
                Logs.LogMe("SqlConnection Object is Created");
                try
                {
                    sqlDB.Open();
                    Logs.LogMe("DataBase got Opened");
                    return sqlDB;
                }
                catch (Exception e)
                {
                    Logs.LogMe("Exceptoin Happend! Exp:" + e.Message);
                    Logs.LogMe("Constr=" + ConStr);
                    //throw;
                    return null;
                }
            }
            else if (DBTypes == ConType.OLEDB)
            {
                oleDB = new OleDbConnection(oleConStr);
                try
                {
                    oleDB.Open();
                    return oleDB;
                }
                catch (Exception)
                {
                    //throw;
                    return null;
                }
            }
            else
                return null;
        }

        /// <summary>
        ///  ConnectDB : Connnect to Database.
        /// @type INT Type of Database(Currently 1 for sql and 2 for ole)
        /// @return true or false
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ConnectDB( int type )
        {
            if (type == ConType.OLEDB)
            {
                if (oleDB == null)
                    oleDB = new OleDbConnection(oleConStr);
                try
                {
                    oleDB.Open();
                }
                catch (Exception)
                {
                    //throw;
                    return false;
                }
                return true;
            }
            else if (type == ConType.SQLDB)
            {
                if (sqlDB == null)
                    sqlDB = new SqlConnection(ConStr);
                try
                {
                    sqlDB.Open();
                }
                catch (Exception)
                {
                    //throw;
                    return false;
                }

                return true;
            }
            else
                return false;
        }

        ///**
        // *CloseDB: Close Database Connection
        // */
        public void CloseDB( )
        {
            if (oleDB != null && oleDB.State == ConnectionState.Open)
            {
                oleDB.Close();
            }
            if (sqlDB != null && sqlDB.State == ConnectionState.Open)
                sqlDB.Close();
        }

        /// <summary>
        /// Check connection is open
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsOpen( int type )
        {
            if (type == ConType.OLEDB && oleDB != null && oleDB.State == ConnectionState.Open)
                return true;
            else if (type == ConType.SQLDB && sqlDB != null && sqlDB.State == ConnectionState.Open)
                return true;
            return false;
        }

        /// <summary>
        /// Get Query from OLE Database
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OleDbDataReader GetQueryOle( String sql )
        {
            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(ConType.OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            // cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            if (reader.IsClosed)
                MessageBox.Show("Reader is close");
            oleDB.Close();
            if (reader.IsClosed)
                MessageBox.Show("Reader is close");
            return reader;
        }

        /// <summary>
        /// Get Query from SQL Database
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader GetQuerySql( String sql )
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(ConType.SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.IsClosed)
                MessageBox.Show("Reader is close");
            sqlDB.Close();
            if (reader.IsClosed)
                MessageBox.Show("Reader is close");
            return reader;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlCommand QueryStrSql( String sql )
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(ConType.SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            return cmd;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OleDbCommand QueryStrOle( String sql )
        {
            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(ConType.OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            return cmd;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int InsertQueryOle( String sql )
        {
            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(ConType.OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                MessageBox.Show("Record Submitted", "Congrats");
                oleDB.Close();
                return 0;
            }
            else
            { oleDB.Close(); return 1; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int InsertQuerySql( String sql )
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(ConType.SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                MessageBox.Show("Record Submitted", "Congrats");
                sqlDB.Close();
                return 0;
            }
            else
            { sqlDB.Close(); return 1; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int NonQueryOle( String sql )
        {
            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(ConType.OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                //MessageBox.Show("Record Submitted", "Congrats");
                oleDB.Close();
                return 0;
            }
            else
            { oleDB.Close(); return 1; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int NonQuerySql( String sql )
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(ConType.SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                //MessageBox.Show("Record Submitted", "Congrats");
                sqlDB.Close();
                return 0;
            }
            else
            { sqlDB.Close(); return 1; }
        }
    }
}