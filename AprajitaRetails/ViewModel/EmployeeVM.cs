using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;
using AprajitaRetails.DataModel;

namespace AprajitaRetails.ViewModel
{
    class EmployeeVM
    {
        EmployeeDB eDM;
        public EmployeeVM()
        {
            eDM = new EmployeeDB ();
        }
        public void AddData()
        {

        }
        public int SaveData(EmployeeDM empData)
        {
            Employee emp = new Employee ();

            return eDM.InsertData (emp);

        }
    }
    class EmployeeDB : DataOps<Employee>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int InsertData(Employee obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@Age", obj.Age);
            cmd.Parameters.AddWithValue ("@City", obj.City);
            cmd.Parameters.AddWithValue ("@Country", obj.Country);
            cmd.Parameters.AddWithValue ("@DateOfBirth", obj.DateOfBirth);
            cmd.Parameters.AddWithValue ("@DateOfJoining", obj.DateOfJoining);
            cmd.Parameters.AddWithValue ("@DateOfLeaving", obj.DateOfLeaving);
            cmd.Parameters.AddWithValue ("@EMPCode", obj.EMPCode);
            cmd.Parameters.AddWithValue ("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue ("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue ("@State", obj.State);
            cmd.Parameters.AddWithValue ("@Status", obj.Status);
            cmd.Parameters.AddWithValue ("@AddressLine1", obj.AddressLine1);
            cmd.Parameters.AddWithValue ("@AttendenceId", obj.AttendenceId);
            cmd.Parameters.AddWithValue ("@EmpType", obj.EmpType);
            return cmd.ExecuteNonQuery ();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Employee ResultToObject(List<Employee> data, int index)
        {
            return data [index];
        }

        public override Employee ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException ();
        }

        public override List<Employee> ResultToObject(List<SortedDictionary<string, string>> data)
        {
            throw new NotImplementedException ();
        }
    }
}
