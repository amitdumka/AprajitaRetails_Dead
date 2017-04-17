using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    public class CustomerVM
    {
        public void AddData()
        {

        }
        public int SaveData(Customer cust)
        {
            return DB.InsertData (cust);
        }
        CustomerDB DB;
        public CustomerVM()
        {
            DB = new CustomerDB ();
        }
    }


    class CustomerDB : DataOps<Customer>
    {
        public CustomerDB()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int InsertData(Customer obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);

            cmd.Parameters.AddWithValue ("@Age", obj.Age);
            cmd.Parameters.AddWithValue ("@City", obj.City);
            cmd.Parameters.AddWithValue ("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue ("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue ("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue ("@MobileNo", obj.MobileNo);
            cmd.Parameters.AddWithValue ("@NoOfBills", obj.NoOfBills);
            cmd.Parameters.AddWithValue ("@TotalAmount", obj.TotalAmount);
            return cmd.ExecuteNonQuery ();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Customer ResultToObject(List<Customer> data, int index)
        {
            return data [index];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override List<Customer> ResultToObject(List<SortedDictionary<string, string>> data)
        {
            List<Customer> result = new List<Customer> ();
            foreach ( SortedDictionary<string, string> ele in data )
            {
                Customer customer = new Customer ()
                {
                    FirstName = ele ["FistName"],
                    LastName = ele ["LastName"],
                    MobileNo = ele ["MobileNo"],
                    Age = Int32.Parse (ele ["Age"]),
                    Gender = Int32.Parse (ele ["Gender"]),
                    TotalAmount = Double.Parse (ele ["TotalAmount"]),
                    ID = Int32.Parse (ele ["ID"]),
                    NoOfBills = Int32.Parse (ele ["NoOfBills"]),
                    City = ele ["City"]
                };
                result.Add (customer);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override Customer ResultToObject(SortedDictionary<string, string> data)
        {
            Customer customer = new Customer ()
            {
                FirstName = data ["FistName"],
                LastName = data ["LastName"],
                Age = Int32.Parse (data ["Age"]),
                Gender = Int32.Parse (data ["Gender"]),
                MobileNo = data ["MobileNo"],
                TotalAmount = Double.Parse (data ["TotalAmount"]),
                ID = Int32.Parse (data ["ID"]),
                NoOfBills = Int32.Parse (data ["NoOfBills"]),
                City = data ["City"]
            };
            return customer;
        }
    }
    /// <summary>
    /// Astract Data Opertations 
    /// Implements to use basic function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class DataOps<T>
    {
        public string Tablename = "";
        protected DataBase Db;
        protected TableCreator.TableClass table;
        protected string InsertSqlQuery = "";
        public DataOps()
        {
            Db = new DataBase (ConType.SQLDB);
            table = new TableCreator.TableClass (typeof (T));
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


        public T GetByColName(string colName, Type colValue)
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

        public int UpdateData(T obj)
        {
            throw new NotImplementedException ();
        }

        public abstract T ResultToObject(List<T> data, int index);

        public abstract T ResultToObject(SortedDictionary<string, string> data);

        public abstract List<T> ResultToObject(List<SortedDictionary<string, string>> data);

    }
}
