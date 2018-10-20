using AprajitaRetailsDataBase;
using AprajitaRetailsDataBase.LinqDataBase;
using AprajitaRetailsDataBase.SqlDataBase;
using System;
using System.IO;

namespace CyberN.Utility
{
    public class Setups
    {
        public static bool IsDataBasePresent( )
        {
            if (DataBase.GetConnectionObject(ConType.SQLDB) != null)
            {
                return true;
            }
            else
                return false;
        }

        public static int IsUserTableExit( )
        {
            Logs.LogMe("Checking UserTable with default id exist or not...");
            return DataBase.IsTableWithDefaultExit("Users");
        }
    }
    public class SetUpDataBase
    {
        public static bool IsApplicationDirPresent( )
        {
            int c = 0;
            if (!Directory.Exists(AppPathList.BaseDir))
            {
                c++;
            }
            if (!Directory.Exists(AppPathList.DataBaseDir))
            {
                c++;
            }
            if (!Directory.Exists(AppPathList.SettingDir))
            {
                c++;
            }
            if (c > 0) return false; else return true;

        }
        public static  bool CreateApplicationDir( )
        {
            int c = 0;
            if (!Directory.Exists(AppPathList.BaseDir))
            {
                Directory.CreateDirectory(AppPathList.BaseDir);
                c++;
            }
            if (!Directory.Exists(AppPathList.DataBaseDir))
            {
                Directory.CreateDirectory(AppPathList.DataBaseDir);
                c++;
            }
            if (!Directory.Exists(AppPathList.SettingDir))
            {
                Directory.CreateDirectory(AppPathList.SettingDir);
                c++;
            }
            if (c > 0) return true; else return false;
        }
        public static bool IsDataBasePresent( )
        {
            VoygerDatabase db = new VoygerDatabase();
            bool status= db.DatabaseExists();
            bool status1 = false;
            //TODO: check for Aprajita Retials 
            if (DataBase.GetConnectionObject(ConType.SQLDB) != null)
            {
                status1= true;
            }
            if (status && status1) return status; else return false;

        }
        public static void CreateDataBases( )
        {
            LinqDatabase db = new LinqDatabase();
            LogEvent.WriteEvent("Setup is creating Databases");
            //TODO: create for Aprajita Retials 
        }
        public static void CopyDatabase( )
        {
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "aprajitaRetails.mdf", AppPathList.DataBaseDir + @"\aprajitaRetails.mdf");
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "aprajitaRetails.ldf",  AppPathList.DataBaseDir + @"\aprajitaRetails.ldf");
        }

    }
    public class AppPathList
    {
        public const string BaseDir = @"D:\AprajitaRetails";
        public const string DataBaseDir = BaseDir + @"\DataBases";
        public const string SettingDir = BaseDir + @"\Settings";
        public const string LogFileDir = BaseDir + @"\Logs";
    }
    public class DBNames
    {
        public const string Voy = "VoygerDatabase";
        public const string TAS = "aprajitaRetails";
    }
}