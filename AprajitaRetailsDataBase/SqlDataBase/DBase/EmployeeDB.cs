using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetailsDataBase.SqlDataBase.Data;
using CyberN.Utility;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class EmployeeDB : DataOps<Employee>
    {
        /// <summary>
        ///   Insert Employee Data to DataBase
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int InsertData( Employee obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);

            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
            cmd.Parameters.AddWithValue("@DateOfJoining", obj.DateOfJoining);
            cmd.Parameters.AddWithValue("@DateOfLeaving", obj.DateOfLeaving);
            cmd.Parameters.AddWithValue("@EMPCode", obj.EMPCode);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@AddressLine1", obj.AddressLine1);
            cmd.Parameters.AddWithValue("@AttendenceId", obj.AttendenceId);
            cmd.Parameters.AddWithValue("@EmpType", obj.EmpType);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Employee ResultToObject( List<Employee> data, int index )
        {
            return data[index];
        }

        public override Employee ResultToObject( SortedDictionary<string, string> item )
        {
            Employee emp = new Employee()
            {
                AddressLine1 = item["AddressLine1"],
                Age = Basic.ToInt(item["Age"]),
                AttendenceId = Basic.ToInt(item["AttendenceId"]),
                City = item["City"],
                Country = item["Country"],
                EMPCode = item["EMPCode"],
                Status = item["Status"],
                FirstName = item["FirstName"],
                LastName = item["LastName"],
                MobileNo = item["MobileNo"],
                State = item["State"],
                ID = Basic.ToInt(item["ID"]),
                EmpType = Basic.ToInt(item["EmpType"]),
                DateOfBirth = DateTime.Parse(item["DateOfBirth"]),
                DateOfJoining = DateTime.Parse(item["DateOfJoining"]),
                DateOfLeaving = DateTime.Parse(item["DateOfLeaving"]),
                Gender = Basic.ToInt(item["Gender"])
            };
            return emp;
        }

        public override List<Employee> ResultToObject( List<SortedDictionary<string, string>> data )
        {
            List<Employee> emps = new List<Employee>();
            foreach (SortedDictionary<string, string> item in data)
            {
                Employee emp = new Employee()
                {
                    AddressLine1 = item["AddressLine1"],
                    Age = Basic.ToInt(item["Age"]),
                    AttendenceId = Basic.ToInt(item["AttendenceId"]),
                    City = item["City"],
                    Country = item["Country"],
                    EMPCode = item["EMPCode"],
                    Status = item["Status"],
                    FirstName = item["FirstName"],
                    LastName = item["LastName"],
                    MobileNo = item["MobileNo"],
                    State = item["State"],
                    ID = Basic.ToInt(item["ID"]),
                    EmpType = Basic.ToInt(item["EmpType"]),
                    DateOfBirth = DateTime.Parse(item["DateOfBirth"]),
                    DateOfJoining = DateTime.Parse(item["DateOfJoining"]),
                    DateOfLeaving = DateTime.Parse(item["DateOfLeaving"]),
                    Gender = Basic.ToInt(item["Gender"])
                };
                emps.Add(emp);
            }
            return emps;
        }

        public List<string> GetEmpCodes( )
        {
            List<string> empCode = new List<string>();
            string sql = "Select EMPCode from Employee";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            empCode = DataBase.GetQueryString(cmd, "EMPCode");
            return empCode;
        }
    }
}