using AprajitaRetailMonitor.SeviceWorker;
using System.IO;

namespace AprajitaRetailMonitor
{
    public class Watcher
    {
        private static System.Diagnostics.EventLog eventLog1;

        public Watcher( System.Diagnostics.EventLog eventLog )
        {
            eventLog1 = eventLog;
            eventLog1.WriteEntry("File is getting started..");
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
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = filter;

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers.
        private static void OnChanged( object source, FileSystemEventArgs e )
        {
            // Specify what is done when a file is changed, created, or deleted.
            eventLog1.WriteEntry("File: " + e.FullPath + " " + e.ChangeType);

            if (e.FullPath == (PathList.InvoiceXMLPath + "\\" + PathList.InvoiceXMLFile))
                ServiceAction.InsertInvoiceXML(e.FullPath);
            else
            {
                eventLog1.WriteEntry("Some other file is changed !!!");
            }

            StreamWriter ws = File.AppendText("d:\\FileChanged.text");
            ws.WriteLine("Change is file is dected and file name is " + e.FullPath + " and event happed is " + e.ChangeType);
            ws.Flush(); ws.Close();
        }

        private static void OnRenamed( object source, RenamedEventArgs e )
        {
            // Specify what is done when a file is renamed.
            eventLog1.WriteEntry("File/ renamed to " + e.OldFullPath + "//" + e.FullPath);
            //TODO: Not Needed in our context
        }
    }
}