using System.IO;
using System.Security.Permissions;
namespace AprajitaRetails.Utils
{
    public class Watcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        ~Watcher( )
        {
            ws.WriteLine("File is getting closed");
            ws.Flush();
            ws.Close();
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public Watcher( )
        {
            if (ws == null)
                ws = File.AppendText("D:\\LogsAprajitaRetsilsMonitor.txt");
            ws.WriteLine("File is getting started..");

        }
        public static string WatchFilePath { set; get; }
        public static string WatchFileFolder { set; get; }
        public static StreamWriter ws = File.AppendText("D:\\LogsAprajitaRetsilsMonitor.txt");

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Watch( string filter, string folder )
        {
            // If a directory is not specified, exit program.
            if (filter == "" && folder == "")
            {
                // Display the proper way to call the program.
                ws.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }
            else
            {
                ws.WriteLine("Watching: " + folder + "\\" + filter);
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
            ws.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

        }

        private static void OnRenamed( object source, RenamedEventArgs e )
        {
            // Specify what is done when a file is renamed.
            ws.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            //TODO: Not Needed in our context
        }
    }
}
