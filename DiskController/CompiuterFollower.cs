using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskController
{
    class CompiuterFollower
    {
        List<string> FolderNames = new List<string>();

        public CompiuterFollower(string Name)
        {
            AllDirectoryName a = new AllDirectoryName();
            FolderNames = a.GatFolderNames(Name);            
        }

        public void Folower()
        {   
            Console.WriteLine("Enter To START");
            Console.ReadKey();
            try
            {
                for (int i = 0; i < FolderNames.Count; i++)
                {
                    var watcher = new FileSystemWatcher { Path = FolderNames[i] };
                    watcher.Created += new FileSystemEventHandler(WatcherChenged);
                    watcher.Deleted += WatcherChenged;
                    watcher.EnableRaisingEvents = true;
                }
                Console.WriteLine("Progress....");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WatcherChenged(object sender, FileSystemEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(e.FullPath);
            Console.WriteLine(e.Name);
            Console.WriteLine(e.ChangeType);            
        }
    }

}
