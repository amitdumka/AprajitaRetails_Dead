using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    class CustomerDB : DataOps<Customer>
    {
        public CustomerDB()
        {

        }

        public List<string> GetMobileList()
        {
            SqlCommand cmd = new SqlCommand ("select MobileNo from Customer", Db.DBCon);
            return DataBase.GetQueryString (cmd, "MobileNo");

        }

        public Customer GetCustomer(string mob)
        {
            return GetByColName ("MobileNo", mob);
        }
        public Customer GetCustomerByName(string name)
        {
            return GetByColName ("FirstName", name);
        }
        public List<Customer> GetCustomersByName(string name)
        {
            string Sql = "select * from Customer where FirstName='" + name + "'";
            SqlCommand cmd = new SqlCommand (Sql, Db.DBCon);
            List<SortedDictionary<string, string>> items = DataBase.GetSqlStoreProcedureString (cmd);
            return ResultToObject (items);
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
                    FirstName = ele ["FirstName"],
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
                FirstName = data ["FirstName"],
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
}
