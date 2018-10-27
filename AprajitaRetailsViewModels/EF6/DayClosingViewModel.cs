using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace AprajitaRetailsViewModels.EF6
{
    public class DayClosingViewModel:IDisposable
    {
        AprajitaRetailsMainDB mainDB; 
        public DayClosingViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
        }

        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }
        public int SaveData( DayClosing dayClosing )
        {
            mainDB.DayClosings.Add( dayClosing );
           return  mainDB.SaveChanges();

        }
    }
}
