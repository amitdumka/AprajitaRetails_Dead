using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;

namespace AprajitaRetailsViewModels.EF6
{
    public class DayClosingViewModel : IDisposable
    {
        private AprajitaRetailsMainDB mainDB;

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
            return mainDB.SaveChanges();
        }
    }
}