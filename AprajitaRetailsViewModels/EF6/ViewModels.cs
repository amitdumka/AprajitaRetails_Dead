using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsViewModels.EF6
{
    class ViewModels<T>:IDisposable
    {
       protected AprajitaRetailsMainDB mainDB;
        protected AprajitaRetailsHRMDB hrmDB;
        protected T MainTable;
        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
            ((IDisposable)hrmDB).Dispose();
        }
    }
}
