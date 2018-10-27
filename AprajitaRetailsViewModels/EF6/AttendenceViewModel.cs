using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace AprajitaRetailsViewModels.EF6
{
    internal class AttendenceViewModel
    {
        private AprajitaRetailsHRMDB hrDB = new AprajitaRetailsHRMDB();

        public List<string> GetAllEmpCodes( )
        {
            hrDB.Employees.Load();
            return hrDB.Employees.Local.Select( s => s.EMPCode ).ToList();
        }

        public List<string> GetEmpName( string empCode )
        {
            hrDB.Employees.Load();
            var e = hrDB.Employees.Local.Where( s => s.EMPCode==empCode ).FirstOrDefault();
            //return (List<string>)hrDB.Employees.Local.Where( s => s.EMPCode==empCode ).Select(s=>new List<string> { s.FirstName,s.LastName } ).ToList();

            return new List<string>() { e.FirstName, e.LastName };
        }

        public int SaveData( Attendence attendence )
        {
            hrDB.Attendences.Add( attendence );
            return hrDB.SaveChanges();
            //return aDM.InsertData( attendence );
        }
    }
}