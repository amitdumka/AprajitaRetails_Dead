using System;
using System.IO;

namespace ClinicManager
{
    class Logs
    {
        private static string logfile = "";
        public static string LogFile { get => logfile; set => logfile = value; }
        public static string GetTempFileName()
        {
            return "";
        }
        public static void Log(string logMessage)
        {
            if (Logs.logfile == "")
                Logs.logfile = GetTempFileName();

            using (StreamWriter w = File.AppendText(Logs.logfile))
            {
                w.Write("\r\nLog : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }
        public static void Loge(string logMessage)
        {
            if (Logs.logfile == "")
                Logs.logfile = GetTempFileName();

            using (StreamWriter w = File.AppendText(Logs.logfile))
            {
                w.Write("\r\nError Log : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }


    }
}
