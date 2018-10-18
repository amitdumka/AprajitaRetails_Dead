using AprajitaRetailsDataBase.SqlDataBase.Data;
using System.Collections.Generic;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class AttendenceVM
    {
        private AttendenceDB aDM = new AttendenceDB();

        public List<string> GetAllEmpCodes( )
        {
            return aDM.GetEmpCodes();
        }

        public List<string> GetEmpName( string empCode )
        {
            return aDM.GetEmpName(empCode);
        }

        public int SaveData( Attendence attendence )
        {
            return aDM.InsertData(attendence);
        }
    }
}