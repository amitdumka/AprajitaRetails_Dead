using System;
using System.IO;
using System.Linq;

namespace CyberN.Utility
{
    internal class FileMonitor
    {
        /// <summary>
        /// Check if the file modified  or not
        /// </summary>
        /// <param name="fileNameWithPath"></param>
        /// <param name="lastModifiedTime"></param>
        /// <returns></returns>
        public static bool IsFileChanged( string fileNameWithPath, DateTime lastModifiedTime )
        {
            DateTime dtFile = File.GetLastWriteTime(fileNameWithPath);
            DateTime now = DateTime.Now;

            long sub = (long)(now - dtFile).TotalMilliseconds;
            if (dtFile > lastModifiedTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return New File name with path in particular directory
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static string NewFileInDirectory( string dirName )
        {
            return new DirectoryInfo(dirName).GetFiles().OrderByDescending(f => f.LastWriteTime).First().FullName;

            /* var directory = new DirectoryInfo(dirName);
             var myFile = (from f in directory.GetFiles()
                           orderby f.LastWriteTime descending
                           select f).First();

             // OR
              myFile = directory.GetFiles()
                          .OrderByDescending(f => f.LastWriteTime)
                          .First();
                          */
        }
    }
}