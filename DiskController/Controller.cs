using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskController
{
    class Controller
    {
        public Controller()
        {            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Folder Name\n C:\\Download\\ \n D:\\C#\\");
                var a = new CompiuterFollower(Console.ReadLine());
                Task Start = new Task(a.Folower);
                Start.RunSynchronously();
            }
        }        
    }

}
