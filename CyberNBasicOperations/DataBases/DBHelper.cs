using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberNBasicOperations
{
    class DBHelper : IDisposable
    {
        public static String OleDBName = "Clinic.mdf";
        public static String SqlDBName = "clinic.mdf";
        String ConStr = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\" + SqlDBName + ";Integrated Security = True;Connect TimeOut=30";
        String oleConStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + DBase.dbName + "; Jet OLEDB:Engine Type=5 ";
        OleDbConnection oleDB;
        SqlConnection sqlDB;
        public const int SQLDB = 1;
        public const int OLEDB = 2;
        protected virtual void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Object GetConnectioObject(int DBTypes)
        {
            if (DBTypes == SQLDB)
            {
                sqlDB = new SqlConnection(ConStr);
                try
                {
                    sqlDB.Open();
                    return sqlDB;
                }
                catch (Exception)
                {

                    //throw;
                    return null;
                }

            }
            else if (DBTypes == OLEDB)
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
            else return null;

        }
        /**
         * ConnectDB : Connnect to Database. 
         * @type INT Type of Database(Currently 1 for sql and 2 for ole)
         * @return true or false
         */
        public bool ConnectDB(int type)
        {
            if (type == OLEDB)
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
            else if (type == SQLDB)
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
        /**
         *CloseDB: Close Database Connection 
         */
        public void CloseDB()
        {
            if (oleDB != null && oleDB.State == ConnectionState.Open)
            {

                oleDB.Close();
            }
            if (sqlDB != null && sqlDB.State == ConnectionState.Open)
                sqlDB.Close();
        }
        public bool IsOpen(int type)
        {
            if (type == OLEDB && oleDB != null && oleDB.State == ConnectionState.Open)
                return true;
            else if (type == SQLDB && sqlDB != null && sqlDB.State == ConnectionState.Open)
                return true;
            return false;
        }
        public OleDbDataReader GetQueryOle(String sql)
        {

            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            // cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Read();
            if (reader.IsClosed) MessageBox.Show("Reader is close");
            oleDB.Close();
            if (reader.IsClosed) MessageBox.Show("Reader is close");
            return reader;


        }
        public SqlDataReader GetQuerySql(String sql)
        {

            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.IsClosed) MessageBox.Show("Reader is close");
            sqlDB.Close();
            if (reader.IsClosed) MessageBox.Show("Reader is close");
            return reader;

        }
        public SqlCommand QueryStrSql(String sql)
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            return cmd;



        }
        public OleDbCommand QueryStrOle(String sql)
        {

            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            return cmd;



        }
        public int InsertQueryOle(String sql)
        {

            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                MessageBox.Show("Record Submitted", "Congrats");
                oleDB.Close(); return 0;
            }
            else
            { oleDB.Close(); return 1; }





        }

        public int InsertQuerySql(String sql)
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                MessageBox.Show("Record Submitted", "Congrats");
                sqlDB.Close(); return 0;
            }
            else
            { sqlDB.Close(); return 1; }

        }
        public int NonQueryOle(String sql)
        {
            if (oleDB != null && oleDB.State == ConnectionState.Closed)
                oleDB.Open();
            else
                ConnectDB(OLEDB);
            OleDbCommand cmd = oleDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = oleDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                //MessageBox.Show("Record Submitted", "Congrats");
                oleDB.Close(); return 0;
            }
            else
            { oleDB.Close(); return 1; }

        }

        public int NonQuerySql(String sql)
        {
            if (sqlDB != null && sqlDB.State == ConnectionState.Closed)
                sqlDB.Open();
            else
                ConnectDB(SQLDB);
            SqlCommand cmd = sqlDB.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlDB;
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                //MessageBox.Show("Record Submitted", "Congrats");
                sqlDB.Close(); return 0;
            }
            else
            { sqlDB.Close(); return 1; }

        }

    }
}
