using System;
using System.IO;
using System.Diagnostics;
namespace FILES
{
    public static class FILE_EXPLORER
    {
        public static void ListDisks()
        {
            Console.Clear();
            DriveInfo SDA = new DriveInfo("/");
            string d_name = SDA.Name;
            double d_TotalSize = SDA.TotalSize / 1000000000;
            double d_AvaiSpace = SDA.AvailableFreeSpace / 1000000000;
            double d_Used = (SDA.TotalSize - SDA.AvailableFreeSpace) / 1000000000;
            ConsoleKeyInfo Only_one;
            int pos = 2;
            do
            {
                Only_one = Console.ReadKey();
                switch (Only_one.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        cd(d_name);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                if (pos == 4)
                {
                    pos = 2;
                }
                if (pos == 1)
                {
                    pos = 2;
                }
                Console.Clear();
                Console.WriteLine($"\n\n\tMountpoint: {d_name}\t| Total: {d_TotalSize} GB\tAvailable: {d_AvaiSpace} GB\t Used: {d_Used} GB");
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
            } while (Only_one.Key != ConsoleKey.Q);
        }
        public static void cd(string path)
        {
            Console.Clear();
            int pos = 1;
            ConsoleKeyInfo main_key;
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            ShowDirs(dirs, files);
            do
            {
                main_key = Console.ReadKey();
                switch (main_key.Key)
                {
                    case ConsoleKey.DownArrow:
                        pos++;
                        break;
                    case ConsoleKey.UpArrow:
                        pos--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        cd(dirs[pos]);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Tab:
                        Console.Clear();
                        Console.WriteLine("-----------------------");
                        Console.Write("| Enter name of directory: ");
                        string name = Console.ReadLine();
                        Directory.CreateDirectory(Path.GetFullPath(path) + "/" + name);
                        break;
                    case ConsoleKey.F2:
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Specifiy the name of deleting directory: ");
                        string nam = Console.ReadLine();
                        if (nam == null)
                        {
                            Console.WriteLine("Directory not found\n");
                        }
                        Directory.Delete(Path.GetFullPath(path) + "/" + nam);
                        break;
                    
                }
                
                Console.Clear();
                ShowDirs(dirs, files);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
            } while (main_key.Key != ConsoleKey.Q);
        }
        static void ShowDirs(string [] dirs, string [] files)
        {
            Console.WriteLine("\n\tName                     Creation time                       Type / F1 - create new dir F2 - remove dir");
            foreach (string dir in dirs)
            {
                Console.WriteLine($"\t{Path.GetFileName(dir)}\t\t{File.GetCreationTime(dir)}\t\tdirectory) | ");
            }
            foreach (string fl in files)
            {
                Console.WriteLine($"\t{Path.GetFileName(fl)}\t\t{File.GetCreationTime(fl)}\t\t{Path.GetExtension(fl)}");
            }
        }
    }
    class MAIN_PROGRAM
    {
        static int Main()
        {
            // FILE_EXPLORER.ListDisks();
            FILE_EXPLORER.cd("/home/{USERNAME}");
            return 0;
        }
    }
}