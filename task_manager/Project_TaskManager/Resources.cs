/*
 * 'Main()' in Program.cs 
 */
using System.Diagnostics;
namespace Resources_main
{
    enum Delet
    {
        by_d = -1,
        by_del = -2
    }
    static class Resources
    {
        private static int Instance_info(Process process_name)
        {
            int EXIT_STATUS = 0;

            Process[] isAlive = Process.GetProcessesByName(process_name.ToString());
            ConsoleKeyInfo KILL;
            int h = 1;
            char icon = '>';
            string path = Path.GetFullPath(process_name.ToString());
            Console.Clear();
            Console.WriteLine($"Process name: {process_name} -- File location: {path}");
            Console.WriteLine(@"1.    Terminate process: D
                                2.    Terminate all processes matching with name: Delete");
            do
            {
                KILL = Console.ReadKey();
                try
                {

                    switch (KILL.Key)
                    {
                        case ConsoleKey.D:
                            if (isAlive.Length == 0)
                            {
                                ConsoleKeyInfo c;
                                Console.WriteLine("Process not found.");
                                Console.Write("Tap 'Backspace' to go back to list: ");
                                c = Console.ReadKey();
                                if (c.Key == ConsoleKey.Backspace)
                                    return EXIT_STATUS;
                                else
                                    return EXIT_STATUS;

                            }
                            else
                            {
                                process_name.Kill();
                                EXIT_STATUS = (int)Delet.by_d;
                                break;
                            }
                        case ConsoleKey.Delete:

                            if (isAlive.Length == 0)
                            {
                                ConsoleKeyInfo c;
                                Console.WriteLine("Process not found.");
                                Console.Write("Tap 'Backspace' to go back to list: ");
                                c = Console.ReadKey();
                                if (c.Key == ConsoleKey.Backspace)
                                    return EXIT_STATUS;
                                else
                                    return EXIT_STATUS;

                            }
                            else
                            {
                                foreach (Process named in Process.GetProcesses())
                                {
                                    if (named == process_name)
                                    {
                                        named.Kill();
                                    }

                                }
                                EXIT_STATUS = (int)Delet.by_del;
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            h--;
                            break;
                        case ConsoleKey.DownArrow:
                            h++;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Couldn't stop the proccess: {process_name}. Permission denied");
                    EXIT_STATUS = -3;
                }
                finally
                {
                    Console.WriteLine("All is done. You can back to list");
                    EXIT_STATUS = -4;
                }
                Console.Clear();
                Console.WriteLine($"Process name: {process_name} -- File location: {path}");
                Console.WriteLine(@"1.    Terminate process: D
                                        2.    Terminate all processes matching with name: Delete");
                Console.Write("  ");
                Console.SetCursorPosition(0, h);
                Console.WriteLine(icon);
            } while (KILL.Key != ConsoleKey.Backspace);

            return EXIT_STATUS;
        }
        private static void Show(Process[] pattern)
        {
            foreach (Process INDIVID in pattern)
            {
                Console.WriteLine($"{INDIVID.ProcessName + '\t' + INDIVID.TotalProcessorTime + '\t' + INDIVID.VirtualMemorySize64}");
            }
        }
        /// <summary>
        /// Shows all processes after main() calling
        /// </summary>
        public static void ShowAllProcesses()
        {
            int pos = 1;
            Process[] prc = Process.GetProcesses();
            char icon = '>';
            ConsoleKeyInfo K;
            Show(prc);
            while (true)
            {
                K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.DownArrow:
                        pos++;
                        break;
                    case ConsoleKey.UpArrow:
                        pos--;
                        break;
                    case ConsoleKey.Enter:
                        Process[] pname = Process.GetProcessesByName(prc[pos].ToString());
                        if (pname.Length == 0)
                        {
                            Console.Write("\t\t\t\t\t\tProcess not found | \n");
                        }
                        else

                        {
                            int res = Instance_info(prc[pos]);
                            if (res == -1)

                                Console.Write("\t\t\t\t\t\tProcess killed!");
                            else if (res == -2)
                            {
                                Console.Write("\t\t\t\t\t\tMultiple processes killed!");
                            }
                            else if (res == -3)
                            {
                                Console.Write("\t\t\t\t\t\tProcess was not killed. Permission denied");
                            }
                            else if (res == -4)
                            {
                                Console.WriteLine("\t\t\t\t\t\tUnknown error occured. Please check windows task manager :)");
                            }
                        }
                        break;
                    default:
                        continue;
                }
                Console.Clear();
                Show(prc);
                Console.WriteLine("  ");                
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(icon);
            }
        }
    }
}
