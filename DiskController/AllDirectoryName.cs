using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskController
{
    class AllDirectoryName
    {
        private string[] drives= Directory.GetLogicalDrives();
        private  List<string> AllFolderNames = new List<string>();
        private List<string> AllFileNames = new List<string>();
        private StringCollection log = new StringCollection();
        
        public List<string> GatFolderNames(string Name)
        {
           DirectoryInfo drivename = new DirectoryInfo(Name);
           WalkDirectoryTree(drivename);
            
           return AllFolderNames;                     
        }
        private void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }            
            catch (UnauthorizedAccessException e)
            {               
                log.Add(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    AllFileNames.Add(fi.FullName);
                }             
                   
                subDirs = root.GetDirectories();
                
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    AllFolderNames.Add(dirInfo.FullName);
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
    }
}
