using CyberN.Utility;
using System;
using System.Data;

namespace AprajitaRetailsDataBase.LinqDataBase
{
    public class LinqDatabase: IDisposable
    {
        
        public VoygerDatabase db;
        private static string dbPathWithName = AppPathList.DataBaseDir+"\\"+DBNames.Voy+".mdf";

        public LinqDatabase( )
        {
            db = new VoygerDatabase(dbPathWithName);
            Console.WriteLine("DBExist.#" + db.DatabaseExists().ToString());
            Console.WriteLine("Path:" + db.Connection.Database.ToString() + "\n" + db.Connection.ConnectionString);
            if (!db.DatabaseExists())
            {
                Console.WriteLine("data source:" + db.Connection.DataSource.ToString());
                db.CreateDatabase();
                LogEvent.WriteEvent("Creating Database VoygerDatabase. ");
            }

            if (db.Connection.State == ConnectionState.Closed)
            {
                try
                {
                    db.Connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Linq Database connection is closed or not openning" + e);
                    LogEvent.WriteEvent("Linq Database connection is closed or not openning" + e);

                   
                }
            }
        }

        public void Dispose( )
        {
            ((IDisposable)db).Dispose();
            LogEvent.WriteEvent("Disposing LinqDatabase");
        }
    }
}