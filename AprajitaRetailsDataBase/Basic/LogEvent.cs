namespace AprajitaRetailsDataBase
{
    internal class LogEvent
    {
        static LogEvent( )
        {
            eventLog = new System.Diagnostics.EventLog()
            {
                Source = "AprajitaRetailsDataBase",
                Log = "AprajitaRetailsLog"
            };
            if (!System.Diagnostics.EventLog.SourceExists("AprajitaRetailsDataBase"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AprajitaRetailsDataBase", "AprajitaRetailsLog");
            }
            eventLog.WriteEntry("LogEvent: LogEntry Constructer called");
        }

        public static System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog()
        {
            Source = "AprajitaRetailsDataBase",
            Log = "AprajitaRetailsLog"
        };

        public static void WriteEvent( string entryLog )
        {
            eventLog.WriteEntry(entryLog);
        }
    }
}