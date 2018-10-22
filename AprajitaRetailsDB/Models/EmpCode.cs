using System;
//using CyberN.Utility;

namespace AprajitaRetailsDB.Models.Data
{
    public class EmpCode
    {
        public string CategoryCode;
        public string LevelCode;
        public int SerialNo;

    }
    //public class EmpCode_DB{/// <summary>
    //    ///    Get EmployeeType from Employee Type Name
    //    /// </summary>
    //    /// <param name="category"></param>
    //    /// <returns></returns>
    //    public static int GetCategory( string category )
    //    {
    //        int res = 0;
    //        switch (category)
    //        {
    //            case "Accountant":
    //                res = EmployeeType.Accountant;
    //                break;

    //            case "AssistanceManager":
    //                res = EmployeeType.AssistanceManager;
    //                break;

    //            case "HouseKeeping":
    //                res = EmployeeType.HouseKeeping;
    //                break;

    //            case "Others":
    //                res = EmployeeType.Others;
    //                break;

    //            case "Owner":
    //                res = EmployeeType.Owner;
    //                break;

    //            case "SalesMan":
    //                res = EmployeeType.SalesMan;
    //                break;

    //            case "StoreManager":
    //                res = EmployeeType.StoreManager;
    //                break;

    //            default:
    //                res = EmployeeType.SalesMan;
    //                break;
    //        }

    //        return res;
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="category"></param>
    //    /// <returns></returns>
    //    public static int CatgeoryToEmpType( string category )
    //    {
    //        int res = 0;
    //        switch (category)
    //        {
    //            case "AC":
    //                res = EmployeeType.Accountant;
    //                break;

    //            case "AM":
    //                res = EmployeeType.AssistanceManager;
    //                break;

    //            case "HK":
    //                res = EmployeeType.HouseKeeping;
    //                break;

    //            case "ET":
    //                res = EmployeeType.Others;
    //                break;

    //            case "MD":
    //                res = EmployeeType.Owner;
    //                break;

    //            case "SL":
    //                res = EmployeeType.SalesMan;
    //                break;

    //            case "SM":
    //                res = EmployeeType.StoreManager;
    //                break;

    //            default:
    //                res = EmployeeType.SalesMan;
    //                break;
    //        }

    //        return res;
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="emptype"></param>
    //    /// <returns></returns>
    //    public static string EmpTypeToCategory( int emptype )
    //    {
    //        string res = "";
    //        switch (emptype)
    //        {
    //            case (int)EmployeeType.EmpType.Accountant:
    //                res = "AC";
    //                break;

    //            case (int)EmployeeType.EmpType.AssistanceManager:
    //                res = "AM";
    //                break;

    //            case (int)EmployeeType.EmpType.HouseKeeping:
    //                res = "HK";
    //                break;

    //            case (int)EmployeeType.EmpType.Others:
    //                res = "ET";
    //                break;

    //            case (int)EmployeeType.EmpType.Owner:
    //                res = "MD";
    //                break;

    //            case (int)EmployeeType.EmpType.SalesMan:
    //                res = "SL";
    //                break;

    //            case (int)EmployeeType.EmpType.StoreManager:
    //                res = "SM";
    //                break;

    //            default:
    //                res = "SL";
    //                break;
    //        }

    //        return res;
    //    }

    //    public static string GenerateEmpCode( string category, string level, int serial )
    //    {
    //        return category + level + ToNumericString(serial);
    //    }

    //    public static string GenerateEmpCode( string category )
    //    {
    //        string level = "" + DateTime.Now.Year;
    //        return GenerateEmpCode(category, level);
    //    }

    //    public static string GenerateEmpCode( int empType )
    //    {
    //        string level = "" + DateTime.Now.Year;
    //        return GenerateEmpCode(empType, level);
    //    }

    //    public static string GenerateEmpCode( int empType, string level )
    //    {
    //        string sql = "select ISNULL(MAX(ID), 0) from Employee where EmpType=" + empType;
    //        int sCode = 0;
    //        int serial = DataBase.QuerryReturnInt(sql);
    //        if (serial != -1)
    //        {
    //            if (serial == 0)
    //            {
    //                sCode = 1;
    //            }
    //            else if (serial > 0)
    //            {
    //                sql = "select EmpCode from Employee where ID=" + serial;
    //                string ecode = (string)DataBase.QuerryReturn(sql);
    //                ecode = ecode.Trim().Substring(6);
    //                serial = Basic.ToInt(ecode);
    //                if (serial != -999)
    //                {
    //                    sCode = 1 + serial;
    //                }
    //                else
    //                {
    //                    sCode = 100;
    //                }
    //            }
    //        }
    //        else
    //            sCode = 1;
    //        return EmpTypeToCategory(empType) + level + ToNumericString(sCode);
    //    }

    //    public static string GenerateEmpCode( string category, string level )
    //    {
    //        string sql = "select Max(ID) from Employee where EmpType=" + CatgeoryToEmpType(category);
    //        int sCode = 0;
    //        int serial = DataBase.QuerryReturnInt(sql);
    //        if (serial != -1)
    //        {
    //            if (serial == 0)
    //            {
    //                sCode = 1;
    //            }
    //            else if (serial > 0)
    //            {
    //                sql = "select EmpCode from Employee where ID=" + serial;
    //                string ecode = (string)DataBase.QuerryReturn(sql);
    //                ecode = ecode.Trim().Substring(6);
    //                serial = Basic.ToInt(ecode);
    //                if (serial != -999)
    //                {
    //                    sCode = 1 + serial;
    //                }
    //                else
    //                {
    //                    sCode = 100;
    //                }
    //            }
    //        }
    //        else
    //            sCode = 1;
    //        return category + level + ToNumericString(sCode);
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="num"></param>
    //    /// <returns></returns>
    //    public static string ToNumericString( int num )
    //    {
    //        string sNum = "";
    //        if (num < 10)
    //            sNum = "000" + num;
    //        else if (num < 100)
    //            sNum = "00" + num;
    //        else if (num < 1000)
    //            sNum = "0" + num;
    //        else
    //            sNum = "" + num;
    //        return sNum;
    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString( )
    //    {
    //        return CategoryCode + LevelCode + SerialNo;
    //    }
    //}

}