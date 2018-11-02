using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsViewModels.EF6
{
    class PaySlipViewModel:ViewModels<PaySlip>
    {
        public PaySlipViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
            hrmDB=new AprajitaRetailsHRMDB();
        }
        #region GetData
        public  void GetSalaryDetails( string empCode)
        {

        }
        public void GetEmpoyeeDetails(string empCode ) { }
        public void GetAttendences(string empCode ) { }
        public void GetLeaves(string empCode ) { }
        public void GetAdvances(string empCode ) { }
        public void GetDuesCleared(string empCode ) { }
        public void GetDuesList(string empCode ) { }
       
        #endregion

        #region Leaves

        #endregion
        
        #region Deductions 

        #endregion
        
        #region Calucaltions

        #endregion

    }
}
