using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using AprajitaRetailsDB.Models.Data;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Employee = AprajitaRetailsDB.DataBase.AprajitaRetails.HRM.Employee;

namespace AprajitaRetailsViewModels.EF6
{
    public class EmployeeViewModel : IDisposable
    {
        #region Declaration

        private AprajitaRetailsHRMDB hrDB;
        private readonly EmpCode empCode;

        public EmployeeViewModel( )
        {
            hrDB=new AprajitaRetailsHRMDB();
            empCode=new EmpCode();
        }

        public void Dispose( )
        {
            ((IDisposable)hrDB).Dispose();
        }

        #endregion Declaration

        #region Get Data

        public Employee GetEmployeeDetails( string empCode )
        {
            hrDB.Employees.Load();
            return hrDB.Employees.Local.Where( s => s.EMPCode==empCode ).FirstOrDefault();
        }

        #endregion Get Data

        #region Extra Function

        public int SetGenderList( ComboBox genderBox )
        {
            genderBox.Items.Add( "Male" );
            genderBox.Items.Add( "Female" );
            genderBox.Items.Add( "Transgender" );
            return genderBox.Items.Count;
        }

        public List<string> GetEmployeeTypeList( )
        {
            List<string> empTypes = new List<string>();
            Type t = GetT();

            foreach (FieldInfo p in t.GetFields())
            {
                empTypes.Add( p.Name );
            }
            return empTypes;
        }

        private static Type GetT( )
        {
            return typeof( EmployeeType );
        }

        public int GetEmployeeTypeList( ComboBox empTypes )
        {
            //List<string> empTypes = new List<string> ();
            Type t = GetT();
            foreach (FieldInfo p in t.GetFields())
            {
                empTypes.Items.Add( p.Name );
            }
            return empTypes.Items.Count;
        }

        public List<string> GetAllEmpCodes( )
        {
            hrDB.Employees.Load();
            return hrDB.Employees.Local.Select( s => s.EMPCode ).ToList();
        }

        #endregion Extra Function

        #region Save Data

        public int SaveData( Employee empData )
        {
            // Employee emp = ToObjectEmployee (empData);
            hrDB.Employees.Add( empData );
            return hrDB.SaveChanges();
            //return eDM.InsertData( empData );
        }

        #endregion Save Data

        #region EmpCode Migrated

        // Code Migrated from EmpCode
        public string GenerateEmpCode( string category, string level )
        {
            int sCode = 0;
            int serial = hrDB.Employees.Local.Where( s => s.EmpTypeID==EmpCode.CatgeoryToEmpType( category ) ).Max( S => S.EMPID );
            if (serial!=-1)
            {
                if (serial==0)
                {
                    sCode=1;
                }
                else if (serial>0)
                {
                    string ecode = hrDB.Employees.Local.Where( s => s.EMPID==serial ).Select( s => s.EMPCode ).FirstOrDefault();
                    ecode=ecode.Trim().Substring( 6 );
                    serial=Basic.ToInt( ecode );
                    if (serial!=-999)
                    {
                        sCode=1+serial;
                    }
                    else
                    {
                        sCode=100;
                    }
                }
            }
            else
            {
                sCode=1;
            }

            return category+level+EmpCode.ToNumericString( sCode );
        }

        public string GenerateEmpCode( int empType, string level )
        {
            // string sql = "select ISNULL(MAX(ID), 0) from Employee where EmpType="+empType;
            int sCode = 0;
            int serial = hrDB.Employees.Local.Where( s => s.EmpTypeID==empType ).Max( s => (int?)s.EMPID )??0;
            if (serial!=-1)
            {
                if (serial==0)
                {
                    sCode=1;
                }
                else if (serial>0)
                {
                    // sql="select EmpCode from Employee where ID="+serial;
                    string ecode = hrDB.Employees.Local.Where( s => s.EMPID==serial ).Select( s => s.EMPCode ).FirstOrDefault();
                    ecode=ecode.Trim().Substring( 6 );
                    serial=Basic.ToInt( ecode );
                    if (serial!=-999)
                    {
                        sCode=1+serial;
                    }
                    else
                    {
                        sCode=100;
                    }
                }
            }
            else
            {
                sCode=1;
            }

            return EmpCode.EmpTypeToCategory( empType )+level+EmpCode.ToNumericString( sCode );
        }

        public static string GenerateEmpCode( string category, string level, int serial )
        {
            return category+level+EmpCode.ToNumericString( serial );
        }

        public string GenerateEmpCode( string category )
        {
            string level = ""+DateTime.Now.Year;
            return GenerateEmpCode( category, level );
        }

        public string GenerateEmpCode( int empType )
        {
            string level = ""+DateTime.Now.Year;
            return GenerateEmpCode( empType, level );
        }

        #endregion EmpCode Migrated
    }
}