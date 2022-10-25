using System;
using NAM;
namespace NAM
{
    public class namespa
    {
        public DateTime date_d_1;
        public DateTime date_d_2;
        public DateTime date_d_3;
        public DateTime date_d_4;
        public DateTime date_d_5;
        public string descripFOR1 = string.Empty;
        public string descripFOR2 = string.Empty;
        public string descripFOR3 = string.Empty;
        public string descripFOR4 = string.Empty;
        public string descripFOR5 = string.Empty;
        // FOR TASKS ON 1-ND DAY
        public string time1_task1 = string.Empty;
        public string time1_task2 = string.Empty;
        public string time1_task3 = string.Empty;
        // FOR TASKS ON 2-ND DAY 
        public string time2_task1 = string.Empty;
        public string time2_task2 = string.Empty;
        // FOR TASLKS ON 3-TH DAY
        public string time3_task1 = string.Empty;
        public string time3_task2 = string.Empty;
        public string time3_task3 = string.Empty;
        // CONTINUE...
        public string time4_task1 = string.Empty;
        public string time4_task2 = string.Empty;
    }
}
namespace MAiN_program
{
    class Master
    {
        
        static void menu(DateTime date)
        {
            Console.Clear();
            Console.WriteLine("Date selected: "+date);
        }
        static void DAY1(DateTime date)
        {
            Console.Clear();
            namespa Date = new namespa();
            Date.date_d_1 = new DateTime(2022,11,06);
            namespa DES = new namespa();
            menu(Date.date_d_1);
            DES.descripFOR1 = "\t1. Wash car\n"+
                              "\t2. Help grandmother\n"+
                              "\t3. Write a letter to Mom";
            // Call Menu() function:
            namespa TIME1_TASK1 = new namespa();
            TIME1_TASK1.time1_task1 = "\t Wash car! :::: Scheduled on: 06 nov 8:00 AM\n"+
                                      "\t 1. Prepare hose\n"+
                                      "\t 2. Prepare water\n"+
                                      "\t 3. Wash: roof, side and tyres from dirt\n";
            namespa TIME1_TASK2 = new namespa();
            TIME1_TASK2.time1_task2 = "\t Help grandmother! :::: Scheduled on: 06 nov 11:50 AM\n"+
                                      "\t 1. Fix fence\n"+
                                      "\t 2. Supervisor on cow\n"+
                                      "\t 3. Tidy up in room\n";
            namespa TIME1_TASK3 = new namespa();
            TIME1_TASK3.time1_task3 = "\t Write a letter to mom! :::: Scheduled on: 06 nov 15:30 PM\n"+
                                      "\t 1. Prepare paper\n"+
                                      "\t 2. Write about village life\n"+
                                      "\t 3. Ask how do she do\n"+
                                      "\t 4. Write a conclusion\n"; 
            int pos = 1;
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo control_key;
            menu(Date.date_d_1);
            Console.WriteLine(DES.descripFOR1);
            do // first do: to exit TO MENU IN LIST OF NOTE
            {
                control_key = Console.ReadKey();
                if (control_key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == -1 || pos == 0) pos = 1;
                }
                else if (control_key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == 4 || pos == 5) pos = 3;
                }
                Console.Clear();
                menu(Date.date_d_1);
                Console.WriteLine(DES.descripFOR1);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("~~>");
                if (pos == 1 && control_key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.Write("Date: "+ Date.date_d_1+"\n");
                        Console.Write(TIME1_TASK1.time1_task1);
                        Console.Write("\n: Nothing to write, q to exit from description");
                    }
                else if (pos == 2 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date.date_d_1+"\n");
                    Console.Write(TIME1_TASK2.time1_task2);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
                else if (pos == 3 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date.date_d_1+"\n");
                    Console.Write(TIME1_TASK3.time1_task3);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
            } while (control_key.Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static void DAY2(DateTime date2)
        {
            Console.Clear();
            namespa Date2 = new namespa();
            Date2.date_d_2 = new DateTime(2022,11,07);
            namespa DES2 = new namespa();
            DES2.descripFOR2 = "\t 1. Go to Town's Day\n"+
                               "\t 2. Help brother in programming\n";
            namespa TIME2_TASK1 = new namespa();
            TIME2_TASK1.time2_task1 = "\t Go to Town's Day! :::: Scheduled on: 07 nov 12:00 PM\n"+
                                      "\t1. Call friends and gather at square\n"+
                                      "\t2. Celebrate all with holiday\n"+
                                      "\t3. Have fun!\n";
            namespa TIME2_TASK2 = new namespa();
            TIME2_TASK2.time2_task2 = "\t Help brother in programming! :::: Scheduled on: 07 nov 15:00 PM\n"+
                                      "\t 1. Explain new topic\n"+
                                      "\t 2. Provide practical work for fix theory\n"+
                                      "\t 3. Examine details\n";
            int pos = 1;
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo control_key;
            menu(Date2.date_d_2);
            Console.WriteLine(DES2.descripFOR2);
            do // first do: to exit TO MENU IN LIST OF NOTE
            {
                control_key = Console.ReadKey();
                if (control_key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == -1 || pos == 0) pos = 1;
                }
                else if (control_key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == 3 || pos == 4) pos = 2;
                }
                Console.Clear();
                menu(Date2.date_d_2);
                Console.WriteLine(DES2.descripFOR2);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("~~>");
                if (pos == 1 && control_key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.Write("Date: "+ Date2.date_d_2+"\n");
                        Console.Write(TIME2_TASK1.time2_task1);
                        Console.Write("\n: Nothing to write, q to exit from description");
                    }
                else if (pos == 2 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date2.date_d_2+"\n");
                    Console.Write(TIME2_TASK2.time2_task2);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
            } while (control_key.Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static void DAY3(DateTime date)
        {
            Console.Clear();
            namespa Date3 = new namespa();
            Date3.date_d_3 = new DateTime(2022,11,08);
            namespa DES3 = new namespa();
            DES3.descripFOR3 = "\t 1. Watch the film\n"+
                               "\t 2. Read a book\n"+
                               "\t 3. Meet with friends";
            namespa TIME3_TASK1 = new namespa();
            TIME3_TASK1.time3_task1 = "\t Watch the film! Scheduled on 08 nov 10:00 AM"+
                                      "\t 1. Call sister and brother\n"+
                                      "\t 2. Find the film on Google\n"+
                                      "\t 3. Start to watch!";
            namespa TIME3_TASK2 = new namespa();
            TIME3_TASK2.time3_task2 = "\t Read a book! :::: Scheduled on: 07 nov 14:00 PM\n"+
                                      "\t 1. Find bookmark at last reading\n"+
                                      "\t 2. Examine new events that author provided in context\n"+
                                      "\t 3. Write interesting moments\n";
            namespa TIME3_TASK3 = new namespa();
            TIME3_TASK3.time3_task3 = "\t Meet with friends! :::: Scheduled on: 07 nov 16:00 PM\n"+
                                      "\t 1. Ask how are they\n"+
                                      "\t 2. Walk in park\n"+
                                      "\t 3. Go to KFC\n";
            int pos = 1;
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo control_key;
            menu(Date3.date_d_2);
            Console.WriteLine(DES3.descripFOR2);
            do // first do: to exit TO MENU IN LIST OF NOTE
            {
                control_key = Console.ReadKey();
                if (control_key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == -1 || pos == 0) pos = 1;
                }
                else if (control_key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == 4 || pos == 5) pos = 3;
                }
                Console.Clear();
                menu(Date3.date_d_3);
                Console.WriteLine(DES3.descripFOR3);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("~~>");
                if (pos == 1 && control_key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.Write("Date: "+ Date3.date_d_3+"\n");
                        Console.Write(TIME3_TASK1.time3_task1);
                        Console.Write("\n: Nothing to write, q to exit from description");
                    }
                else if (pos == 2 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date3.date_d_3+"\n");
                    Console.Write(TIME3_TASK2.time3_task2);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
                else if (pos == 3 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date3.date_d_3+"\n");
                    Console.Write(TIME3_TASK3.time3_task3);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
            } while (control_key.Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static void DAY4(DateTime date)
        {
            Console.Clear();
            namespa Date4 = new namespa();
            Date4.date_d_4 = new DateTime(2022,11,09);
            namespa DES4 = new namespa();
            DES4.descripFOR4 = "\t 1. Training\n"+
                               "\t 2. Bake a bread \n"+
                               "\t 3. Go to show";
            namespa TIME4_TASK1 = new namespa();
            TIME4_TASK1.time4_task1 = "\t Training! Scheduled on 09 nov 6:00 AM"+
                                      "\t 1. Prepare sport outfit\n"+
                                      "\t 2. Find comfortable place\n"+
                                      "\t 3. Perform various excercises";
            namespa TIME4_TASK2 = new namespa();
            TIME4_TASK2.time3_task2 = "\t Bake a bread! :::: Scheduled on: 09 nov 10:00 AM\n"+
                                      "\t 1. Find recipe\n"+
                                      "\t 2. Buy neccesaty ingredients\n"+
                                      "\t 3. Watch step by step how to cook\n";
            int pos = 1;
            Console.SetCursorPosition(0, pos);
            ConsoleKeyInfo control_key;
            menu(Date4.date_d_4);
            Console.WriteLine(DES4.descripFOR4);
            do // first do: to exit TO MENU IN LIST OF NOTE
            {
                control_key = Console.ReadKey();
                if (control_key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == -1 || pos == 0) pos = 1;
                }
                else if (control_key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == 3 || pos == 4) pos = 2;
                }
                Console.Clear();
                menu(Date4.date_d_4);
                Console.WriteLine(DES4.descripFOR4);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("~~>");
                if (pos == 1 && control_key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.Write("Date: "+ Date4.date_d_4+"\n");
                        Console.Write(TIME4_TASK1.time4_task1);
                        Console.Write("\n: Nothing to write, q to exit from description");
                    }
                else if (pos == 2 && control_key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.Write("Date: "+ Date4.date_d_2+"\n");
                    Console.Write(TIME4_TASK2.time4_task2);
                    Console.Write("\n: Nothing to write, q to exit from description");
                }
            } while (control_key.Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static void Main()
        {
            DateTime default_date = new DateTime(2022,11,06);
            Console.Clear();
            menu(default_date);
            ConsoleKeyInfo main_key;
            while (true)
            {
                if (default_date.Day == 6 && default_date.Month == 11 && default_date.Year == 2022)
                {
                    Console.Clear();
                    DAY1(default_date);
                    main_key = Console.ReadKey();
                    if (main_key.Key == ConsoleKey.UpArrow || main_key.Key == ConsoleKey.DownArrow)
                    {
                        DAY1(default_date);
                    }
                    if (main_key.Key == ConsoleKey.RightArrow)
                    {
                        default_date = default_date.AddDays(1);
                        Console.Clear();
                    }
                    if (main_key.Key == ConsoleKey.LeftArrow)
                    {
                        default_date = default_date.AddDays(-1);
                        Console.Clear();
                    }
                }
                if (default_date.Day == 7 && default_date.Month == 11 && default_date.Year == 2022)
                {
                    Console.Clear();
                    DAY2(default_date);
                    main_key = Console.ReadKey();
                    if (main_key.Key == ConsoleKey.UpArrow || main_key.Key == ConsoleKey.DownArrow)
                    {
                        DAY2(default_date);
                    }
                    if (main_key.Key == ConsoleKey.RightArrow)
                    {
                        default_date = default_date.AddDays(1);
                        Console.Clear();
                    }
                    if (main_key.Key == ConsoleKey.LeftArrow)
                    {
                        default_date = default_date.AddDays(-1);
                        Console.Clear();
                    }
                }
                if (default_date.Day == 8 && default_date.Month == 11 && default_date.Year == 2022)
                {
                    Console.Clear();
                    DAY3(default_date);
                    main_key = Console.ReadKey();
                    if (main_key.Key == ConsoleKey.UpArrow || main_key.Key == ConsoleKey.DownArrow)
                    {
                        DAY3(default_date);
                    }
                    if (main_key.Key == ConsoleKey.RightArrow)
                    {
                        default_date = default_date.AddDays(1);
                        Console.Clear();
                    }
                    if (main_key.Key == ConsoleKey.LeftArrow)
                    {
                        default_date = default_date.AddDays(-1);
                        Console.Clear();
                    } 
                if (default_date.Day == 9 && default_date.Month == 11 && default_date.Year == 2022)
                {
                    Console.Clear();
                    DAY4(default_date);
                    main_key = Console.ReadKey();
                    if (main_key.Key == ConsoleKey.UpArrow || main_key.Key == ConsoleKey.DownArrow)
                    {
                        DAY4(default_date);
                    }
                    if (main_key.Key == ConsoleKey.RightArrow)
                    {
                        default_date = default_date.AddDays(1);
                        Console.Clear();
                    }
                    if (main_key.Key == ConsoleKey.LeftArrow)
                    {
                        default_date = default_date.AddDays(-1);
                        Console.Clear();
                    }
                } 
                }
                else
                        Console.Clear();
                        menu(default_date);
                        main_key = Console.ReadKey();
                        if (main_key.Key == ConsoleKey.RightArrow)
                        {
                            default_date = default_date.AddDays(1);
                        }
                        if (main_key.Key == ConsoleKey.LeftArrow)
                        {
                            default_date = default_date.AddDays(-1);
                        }
             Console.Clear();
            }
            }  
    }
}