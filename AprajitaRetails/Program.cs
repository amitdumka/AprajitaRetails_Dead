using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Logs.LogMe ("Application Started");
            DataBase.DataBaseName = "aprajitaRetails";
            DBHelper.SetDataBaseName (DataBase.DataBaseName);
            Logs.LogMe ("Database Name is Set:"+DBHelper.SqlDBName);
            Application.Run (new LoginForm ());
            Logs.LogMe ("Loading login Form");
        }
    }
}
