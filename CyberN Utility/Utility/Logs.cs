using System;
using System.IO;

namespace CyberN.Utility
{
    /// <summary>
    /// It Create log files with current date time.
    /// @Version 2: Locked
    /// </summary>
    public sealed class Logs
    {
        public static string Filename = "log_"+DateTime.Now.ToLongDateString()+"_"+DateTime.Today.ToFileTime()+".txt";

        public static string LogFile { get => Filename; set => Filename=value; }

        public static void LogMe( string logMessage )
        {
            Log( logMessage );
        }

        public static void Loge( string logMessage )
        {
            using (StreamWriter w = File.AppendText( Filename ))
            {
                w.Write( "\r\nError Log : " );
                w.Write( "{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString() );
                w.Write( "  :" );
                w.Write( "  :{0}", logMessage );
                w.Write( "-------------------------------" );
                w.Flush();
                //w.Close();
            }
        }

        public static void Log( string logMessage )
        {
            try
            {
                using (StreamWriter w = File.AppendText( Filename ))
                {
                    w.Write( "\r\nLog Entry : " );
                    w.Write( "{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString() );
                    w.Write( "  :" );
                    w.Write( "  :{0}", logMessage );
                    w.WriteLine( "-------------------------------" );
                    w.Flush();
                    //w.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write( "\r\nLog Entry : " );
                Console.WriteLine( "{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString() );
                Console.WriteLine( "  :" );
                Console.WriteLine( "  :{0}", logMessage );
                Console.WriteLine( "-------------------------------" );
                Console.WriteLine( "EXPS: "+e.Message );
            }
        }
    }
}