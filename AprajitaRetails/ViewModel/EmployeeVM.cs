using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Data;
using AprajitaRetails.DataModel;

namespace AprajitaRetails.ViewModel
{
    class EmployeeVM
    {
        EmployeeDB eDM;

        /// <summary>
        /// Get Employee Type List
        /// </summary>
        /// <returns> Rerturn list of employee type name list</returns>
        public List<string> GetEmployeeTypeList()
        {
            List<string> empTypes = new List<string> ();
            Type t = typeof (EmployeeType);
           
            foreach ( FieldInfo p in t.GetFields () )
            {                 
                empTypes.Add (p.Name);
            }
            return empTypes;
        }

        /// <summary>
        /// Add Employee type list to Combobox 
        /// </summary>
        /// <param name="empTypes">ComboBox in which list EmpType added</param>
        /// <returns></returns>
        public int GetEmployeeTypeList(ComboBox empTypes)
        {
            //List<string> empTypes = new List<string> ();
            Type t = typeof (EmployeeType);
            foreach ( FieldInfo p in t.GetFields () )
            {
                empTypes.Items.Add (p.Name);
            }
            return empTypes.Items.Count;
        }
        /// <summary>
        /// Default Constructor
        /// </summary>        
        public EmployeeVM()
        {
            eDM = new EmployeeDB ();
        }

        /// <summary>
        /// Add Data Opertation
        /// </summary>
        public void AddData()
        {

        }

        /// <summary>
        ///  Save data
        /// </summary>
        /// <param name="empData">Employee Data</param>
        /// <returns>Returns no of recored added</returns>
        public int SaveData(EmployeeDM empData)
        {
            Employee emp = ToObjectEmployee (empData);

            return eDM.InsertData (emp);

        }

        /// <summary>
        /// Map EmployeeDM Object to Employee
        /// </summary>
        /// <param name="eDM">EmployeeDM object</param>
        /// <returns>Returns Employee Object</returns>
        public Employee ToObjectEmployee(EmployeeDM eDM)
        {
            return new Employee () {
                AddressLine1=eDM.AddressLine1,Age=eDM.Age,
                AttendenceId=eDM.AttendenceId,City= eDM.City,Country= eDM.Country,
                DateOfBirth= eDM.DateOfBirth, DateOfJoining= eDM.DateOfJoining,
                DateOfLeaving= eDM.DateOfLeaving,EMPCode=eDM.EMPCode,
                EmpType=eDM.EmpType,FirstName= eDM.FirstName,ID= eDM.ID,LastName= eDM.LastName,
                State=eDM.State,Status= eDM.Status
            };

        }
    }

    class EmployeeDB : DataOps<Employee>
    {
        /// <summary>
        ///   Insert Employee Data to DataBase
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
