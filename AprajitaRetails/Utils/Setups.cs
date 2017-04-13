using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails
{
    class Setups
    {
        public static bool IsDataBasePresent()
        {
            if ( DataBase.GetConnectionObject (ConType.SQLDB) != null )
            {
                return true;
            }
            else
                return false;
        }
        public static int IsUserTableExit()
        {
            return
            DataBase.IsTableWithDefaultExit ("Users");
        }
    }
}
