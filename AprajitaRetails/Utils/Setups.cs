namespace AprajitaRetails
{
    internal class Setups
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
            return
            DataBase.IsTableWithDefaultExit("Users");
        }
    }
}