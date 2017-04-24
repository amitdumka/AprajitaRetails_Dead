using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CyberN.TableCreator;

namespace AprajitaRetails.ViewModel
{
    /// <summary>
    /// Astract Data Opertations 
    /// Implements to use basic function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class DataOps<T>
    {
        public string Tablename = "";
        protected DataBase Db;
        protected TableClass table;
        protected string InsertSqlQuery = "";

        public DataOps()
        {
            Db = new DataBase (ConType.SQLDB);
            table = new TableClass (typeof (T));
            Tablename = table.ClassName;
            InsertSqlQuery = table.CreateInsertScript ();
            if ( !IsTableExist () )
            {
                CreateTable ();
            }
        }

        public int CreateTable()
        {
            SqlCommand cmd = new SqlCommand (table.CreateTableScript (), Db.DBCon);
            return cmd.ExecuteNonQuery ();
        }

        public int CreateTable(string insertquery)
        {
            SqlCommand cmd = new SqlCommand (insertquery, Db.DBCon);
            return cmd.ExecuteNonQuery ();
        }


        public int Delete(object obj)
        {
            throw new NotImplementedException ();
        }

        public int GenerateId()
        {
            throw new NotImplementedException ();
        }

        public List<T> GetAllRecord()
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename;
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            return ResultToObject (resultData);
        }


        public T GetByColName(string colName, Object colValue)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename + " where " + colName + "=@values";
            cmd.Parameters.AddWithValue ("@values", colValue);
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            return ResultToObject (resultData [0]);

        }


        public T GetByID(int id)
        {
            SqlCommand cmd = new SqlCommand ();
            cmd.CommandText = "select * from " + Tablename + " where ID =" + id;
            List<SortedDictionary<string, string>> resultData = DataBase.GetSqlStoreProcedureString (cmd);
            return ResultToObject (resultData [0]);
        }

        public int GetID(string colName, object colValue)
        {
            string cmdText = "select ID from " + Tablename + " where " + colName + "= @values";
            SqlCommand cmd = new SqlCommand (cmdText, Db.DBCon);
            cmd.Parameters.AddWithValue ("@values", colValue);
            return (int) cmd.ExecuteScalar ();
        }

        public abstract int InsertData(T obj);

        /// <summary>
        /// Checks Table Exist or not
        /// </summary>
        /// <returns></returns>
        public bool IsTableExist()
        {
            return DataBase.IsTableExit (Tablename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool IsTableExist(string table)
        {
            return DataBase.IsTableExit (table);
        }


        public int UpdateData(T obj)
        {
            throw new NotImplementedException ();
        }

        public abstract T ResultToObject(List<T> data, int index);

        public abstract T ResultToObject(SortedDictionary<string, string> data);

        public abstract List<T> ResultToObject(List<SortedDictionary<string, string>> dataList);

    }
}
