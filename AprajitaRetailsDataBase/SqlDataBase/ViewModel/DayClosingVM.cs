using AprajitaRetailsDataBase.SqlDataBase.Data;

//TODO: Keep implementing this as others parts are completed
//TODO: keep and Collect Data now Onwarrds
namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class DayClosingVM
    {
        private DayClosingDB DB;

        public DayClosingVM( )
        {
            DB = new DayClosingDB();
        }

        public int SaveData( DayClosing dayClosing )
        {
            return DB.InsertData(dayClosing);
        }
    }
}