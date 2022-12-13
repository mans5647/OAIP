using System;
using System.Collections.Generic;
using Resources_main;
namespace TaskManager_Common
{
    class taskMRunTime
    {
        static int Main()
        {
            /*
             The code running there is called from Resources.cs (class file) and show his functions 
             See Resources.cs for more details
             */
            Resources.ShowAllProcesses();
            return 0;
        }
    }
}