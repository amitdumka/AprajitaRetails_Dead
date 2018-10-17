using AprajitaRetailMonitor.SeviceWorker;
using System.IO;

namespace AprajitaRetailMonitor
{
    public class Watcher
    {
        public static int NoOfEvent = 0;
        private static System.Diagnostics.EventLog eventLog1;

        public Watcher( System.Diagnostics.EventLog eventLog )
        {
            eventLog1 = eventLog;
            NoOfEvent = 0;
        }

        public void Watch( string filter, string folder )
        {
            // If a directory is not specified, exit program.
            if (filter == "" && folder == "")
            {
                // Display the proper way to call the program.
                eventLog1.WriteEntry("Usage: Watcher.exe (directory)");
                return;
            }
            else
            {
                eventLog1.WriteEntry("Watching: " + folder + "\\" + filter);
            }
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = folder;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            //| NotifyFilters.LastAccess
            // | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = filter;

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private static void OnDeleted( object source, FileSystemEventArgs e )
        {
            // Specify what is done when a file is changed, created, or deleted.
            eventLog1.WriteEntry(" Deleted File: " + e.FullPath + " # " + e.ChangeType);
        }

        private static void OnCreated( object source, FileSystemEventArgs e )
        {
            // Specify what is done when a file is changed, created, or deleted.
            eventLog1.WriteEntry(" created File: " + e.FullPath + " # " + e.ChangeType);
        }

        // Define the event handlers.
        private static void OnChanged( object source, FileSystemEventArgs e )
        {
            // Specify what is done when a file is changed, created, or deleted.
            // eventLog1.WriteEntry("File: " + e.FullPath + " # " + e.ChangeType);

            if (e.FullPath == (PathList.InvoiceXMLPath + "\\" + PathList.InvoiceXMLFile))
            {
                NoOfEvent++;
                if (NoOfEvent == 1)
                {
                    eventLog1.WriteEntry(" Event No: # " + NoOfEvent + " , Process File : " + e.FullPath);
                    ServiceAction.InsertInvoiceXML(e.FullPath, eventLog1);
                    //eventLog1.WriteEntry(" Event No: 1 is now # " + NoOfEvent);
                }
                else
                {
                    // eventLog1.WriteEntry("Second Entry Exit...");
                    return;
                }
            }
            else
            {
                eventLog1.WriteEntry("Some other file is changed !!!");
            }
        }

        private static void OnRenamed( object source, RenamedEventArgs e )
        {
            // Specify what is done when a file is renamed.
            eventLog1.WriteEntry("File/ renamed to " + e.OldFullPath + "//" + e.FullPath);
            //TODO: Not Needed in our context
        }
    }
}