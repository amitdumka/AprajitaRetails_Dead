using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AprajitaRetails
{
    public class Logs
    {
        public static string Filename = "log_" + DateTime.Now.ToLongDateString () + ".txt";

        private static string logfile = "log_" + DateTime.Now.ToLongDateString () + ".txt";
        public static string LogFile { get => logfile; set => logfile = value; }
        public static string GetTempFileName()
        {
            return "";
        }
        public static void LogMe(string logMessage)
        {
            Task t = Task.Run (() => Log (logMessage)     );
        }

        public static void Logf(string logMessage)
        {
            if ( Logs.logfile == "" )
                Logs.logfile = GetTempFileName ();

            using ( StreamWriter w = File.AppendText (Logs.logfile) )
            {
                w.Write ("\r\nLog : ");
                w.WriteLine ("{0} {1}", DateTime.Now.ToLongTimeString (), DateTime.Now.ToLongDateString ());
                w.WriteLine ("  :");
                w.WriteLine ("  :{0}", logMessage);
                w.WriteLine ("-------------------------------");
            }
        }

        public static void Loge(string logMessage)
        {
            if ( Logs.logfile == "" )
                Logs.logfile = GetTempFileName ();

            using ( StreamWriter w = File.AppendText (Logs.logfile) )
            {
                w.Write ("\r\nError Log : ");
                w.Write ("{0} {1}", DateTime.Now.ToLongTimeString (), DateTime.Now.ToLongDateString ());
                w.Write ("  :");
                w.Write ("  :{0}", logMessage);
                w.Write ("-------------------------------");
            }
        }

        public static void Log(string logMessage)
        {
            try
            {
                StreamWriter w = File.AppendText (Filename);
                w.Write ("\r\nLog Entry : ");
                w.Write ("{0} {1}", DateTime.Now.ToLongTimeString (),
                    DateTime.Now.ToLongDateString ());
                w.Write ("  :");
                w.Write ("  :{0}", logMessage);
                w.WriteLine ("-------------------------------");
                w.Flush ();
                w.Close ();
            }
            catch ( Exception )
            {
                Console.Write ("\r\nLog Entry : ");
                Console.WriteLine ("{0} {1}", DateTime.Now.ToLongTimeString (),
                    DateTime.Now.ToLongDateString ());
                Console.WriteLine ("  :");
                Console.WriteLine ("  :{0}", logMessage);
                Console.WriteLine ("-------------------------------");
            }
        }
    }
}