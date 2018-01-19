using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetails.Data;
using CyberN.TableCreator;

namespace AprajitaRetails.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast
    public class NewCustomerDB
    {
        DataBase DB;
        TableClass t;
        string InsertSqlQuery = "";
        string Tablename = "NewCustomer";
        public NewCustomerDB()
        {
            DB = new DataBase (ConType.SQLDB);
            t = new TableClass (typeof (NewCustomer));
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
            SqlCommand cmd = new SqlCommand
            {
                CommandText = InsertSqlQuery
            };
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
}
