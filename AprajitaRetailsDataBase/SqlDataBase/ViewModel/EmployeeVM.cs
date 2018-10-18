using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.SqlDataBase.DataModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

//using System.Windows.Forms;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class EmployeeVM
    {
        private EmployeeDB eDM;

        public int SetGenderList( ComboBox genderBox )
        {
            genderBox.Items.Add("Male");
            genderBox.Items.Add("Female");
            genderBox.Items.Add("Transgender");
            return genderBox.Items.Count;
        }

        public Employee GetEmployeeDetails( string empCode )
        {
            return eDM.GetByColName("EMPCode", empCode);
        }

        /// <summary>
        /// Get Employee Type List
        /// </summary>
        /// <returns> Rerturn list of employee type name list</returns>
        public List<string> GetEmployeeTypeList( )
        {
            List<string> empTypes = new List<string>();
            Type t = typeof(EmployeeType);

            foreach (FieldInfo p in t.GetFields())
            {
                empTypes.Add(p.Name);
            }
            return empTypes;
        }

        /// <summary>
        /// Add Employee type list to Combobox
        /// </summary>
        /// <param name="empTypes">ComboBox in which list EmpType added</param>
        /// <returns></returns>
        public int GetEmployeeTypeList( ComboBox empTypes )
        {
            //List<string> empTypes = new List<string> ();
            Type t = typeof(EmployeeType);
            foreach (FieldInfo p in t.GetFields())
            {
                empTypes.Items.Add(p.Name);
            }
            return empTypes.Items.Count;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EmployeeVM( )
        {
            eDM = new EmployeeDB();
        }

        public List<string> GetAllEmpCodes( )
        {
            return eDM.GetEmpCodes();
        }

        /// <summary>
        /// Add Data Opertation
        /// </summary>
        public void AddData( )
        {
        }

        /// <summary>
        ///  Save data
        /// </summary>
        /// <param name="empData">Employee Data</param>
        /// <returns>Returns no of recored added</returns>
        public int SaveData( Employee empData )
        {
            // Employee emp = ToObjectEmployee (empData);

            return eDM.InsertData(empData);
        }

        /// <summary>
        /// Map EmployeeDM Object to Employee
        /// </summary>
        /// <param name="eDM">EmployeeDM object</param>
        /// <returns>Returns Employee Object</returns>
        public Employee ToObjectEmployee( EmployeeDM eDM )
        {
            return new Employee()
            {
                AddressLine1 = eDM.AddressLine1,
                Age = eDM.Age,
                AttendenceId = eDM.AttendenceId,
                City = eDM.City,
                Country = eDM.Country,
                DateOfBirth = eDM.DateOfBirth,
                DateOfJoining = eDM.DateOfJoining,
                DateOfLeaving = eDM.DateOfLeaving,
                EMPCode = eDM.EMPCode,
                EmpType = eDM.EmpType,
                FirstName = eDM.FirstName,
                ID = eDM.ID,
                LastName = eDM.LastName,
                State = eDM.State,
                Status = eDM.Status
            };
        }
    }
}