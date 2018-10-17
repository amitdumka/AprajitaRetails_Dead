namespace AprajitaRetailMonitor.SeviceWorker
{
    public class LogEvent
    {
        static LogEvent( )
        {
            eventLog = new System.Diagnostics.EventLog()
            {
                Source = "AprajitaRetailsMonitor",
                Log = "AprajitaRetailsLog"
            };
            if (!System.Diagnostics.EventLog.SourceExists("AprajitaRetailsMonitor"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AprajitaRetailsMonitor", "AprajitaRetailsLog");
            }
            eventLog.WriteEntry("LogEvent: LogEntry Constructer called");
        }

        public static System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog()
        {
            Source = "AprajitaRetailsMonitor",
            Log = "AprajitaRetailsLog"
        };

        public static void WriteEvent( string entryLog )
        {
            eventLog.WriteEntry(entryLog);
        }
    }
}