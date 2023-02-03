/* форма - shape, размер - size, вкус - flavor, количество коржей - cursts, глазурь - glaze, декор - decor
сумма заказа - amount, 
for quit press P;
*/
using System;
using System.IO;
using System.Collections.Generic;
namespace Cake_obj
{
    public class MenuAndSubMenu
    {
        
        public int price;
        public string named;
        public void Printf()
        {
            Console.WriteLine($"{named}, {price}");
        }
        public MenuAndSubMenu(string name, int cost)
        {
            named = name;
            price = cost;
        }
        private static void RollMenu(string[] m)
        {
            foreach (string x in m)
            {
                Console.WriteLine(x);
            }
        }
        private static void ShowAmount(int amount)
        {
            Console.Write($"\n\n Total ($): {amount}");
        }
        public static void fileSave(List<MenuAndSubMenu> lisst, int amnt, int order_num)
        {
            DateTime date = DateTime.Now;
            string o_num = "\n\n Order №: "+Convert.ToString(order_num);
            string dorder = "\n "+ Convert.ToString(date);
            string det = "\n Cake was ordered, you can see details below:\n";
            string total = "\n\n In Total ($): "+Convert.ToString(amnt) + '\n';
            string path = @"C:\Users\mansu\Documents\Orders.txt";
            File.AppendAllText(path, dorder);
            File.AppendAllText(path, o_num);
            File.AppendAllText(path,total);
            File.AppendAllText(path, det);
            using (StreamWriter wptr = File.AppendText(path))
            {
                foreach (var w in lisst)
                {
                    wptr.WriteLine(string.Format("Feature: {0}; Cost: {1}", w.named, w.price.ToString()));
                }
            wptr.Close();
            }
            }
        public static void listing()
        {
            Console.Clear();
            List<MenuAndSubMenu> als = new List<MenuAndSubMenu>(); 
            int amount = 0;
            int pos = 3;
            int ord_num = 0;
            const string message = "Welcome to Jeff's Cakes! We are glad to see you!\n";
            Console.WriteLine(message + "\n");
            string[] MainMenu = { "   1. Shape ", "   2. Size ", "   3. Flavor ", "   4. Cursts ", "   5. Glaze ", "   6. Decor ", "   7. Write " };
            RollMenu(MainMenu);
            ShowAmount(amount);
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            ConsoleKeyInfo keyin_Main;
            while (true)
            {
                keyin_Main = Console.ReadKey();
                if (keyin_Main.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                }
                else if (keyin_Main.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                }
                else if (keyin_Main.Key == ConsoleKey.P)
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
                Console.WriteLine(message + "\n");
                RollMenu(MainMenu);
                ShowAmount(amount);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                if (pos == 3 && keyin_Main.Key == ConsoleKey.Enter) // listing 1-st sub-menu 
                {
                    Console.Clear();
                    Console.WriteLine("Choose cake's form: \n");
                    MenuAndSubMenu S1 = new MenuAndSubMenu("\tCircle", 6);
                    MenuAndSubMenu S2 = new MenuAndSubMenu("\tCube", 7);
                    MenuAndSubMenu S3 = new MenuAndSubMenu("\tTrigular", 8);
                    MenuAndSubMenu S4 = new MenuAndSubMenu("\tTower", 9);
                    S1.Printf();
                    S2.Printf();
                    S3.Printf();
                    S4.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS1;
                    do
                    {
                        onS1 = Console.ReadKey();
                        if (onS1.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS1.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose cake's form: \n");
                        S1.Printf();
                        S2.Printf();
                        S3.Printf();
                        S4.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS1.Key == ConsoleKey.Enter)
                        {
                            als.Add(S1);
                            amount+=6;
                        }
                        if (p == 3 && onS1.Key == ConsoleKey.Enter)
                        {
                            als.Add(S2);
                            amount+=7;
                        }
                        if (p == 4 && onS1.Key == ConsoleKey.Enter)
                        {
                            als.Add(S3);
                            amount+=8;
                        }
                        if (p == 5 && onS1.Key == ConsoleKey.Enter)
                        {
                            als.Add(S4);
                            amount+=9;
                        }
                    } while (onS1.Key != ConsoleKey.Escape);
                }
                else if (pos == 4 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Choose cake's size: \n");
                    MenuAndSubMenu S5 = new MenuAndSubMenu("\t13x20", 4);
                    MenuAndSubMenu S6 = new MenuAndSubMenu("\t20x25", 5);
                    MenuAndSubMenu S7 = new MenuAndSubMenu("\t25x30", 7);
                    MenuAndSubMenu S8 = new MenuAndSubMenu("\t30x40", 9);
                    S5.Printf();
                    S6.Printf();
                    S7.Printf();
                    S8.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS2;
                    do
                    {
                        onS2 = Console.ReadKey();
                         if (onS2.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS2.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose cake's size: \n");
                        S5.Printf();
                        S6.Printf();
                        S7.Printf();
                        S8.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS2.Key == ConsoleKey.Enter)
                        {
                            als.Add(S5);
                            amount+=4;
                        }
                        if (p == 3 && onS2.Key == ConsoleKey.Enter)
                        {
                            als.Add(S6);
                            amount+=5;
                        }
                        if (p == 4 && onS2.Key == ConsoleKey.Enter)
                        {
                            als.Add(S7);
                            amount+=7;
                        }
                        if (p == 5 && onS2.Key == ConsoleKey.Enter)
                        {
                            als.Add(S8);
                            amount+=9;
                        }

                    } while (onS2.Key != ConsoleKey.Escape);

                }
                else if (pos == 5 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Choose cake's flavor: \n");
                    MenuAndSubMenu S9 = new MenuAndSubMenu("\tRaspberry", 1);
                    MenuAndSubMenu S10 = new MenuAndSubMenu("\tStrawberry", 2);
                    MenuAndSubMenu S11 = new MenuAndSubMenu("\tLime", 4);
                    MenuAndSubMenu S12 = new MenuAndSubMenu("\tRed Valvet", 6);
                    S9.Printf();
                    S10.Printf();
                    S11.Printf();
                    S12.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS3;
                    do
                    {
                        onS3 = Console.ReadKey();
                         if (onS3.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS3.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose cake's flavor: \n");
                        S9.Printf();
                        S10.Printf();
                        S11.Printf();
                        S12.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS3.Key == ConsoleKey.Enter)
                        {
                            als.Add(S9);
                            amount+=1;
                        }
                        if (p == 3 && onS3.Key == ConsoleKey.Enter)
                        {
                            als.Add(S10);
                            amount+=2;
                        }
                        if (p == 4 && onS3.Key == ConsoleKey.Enter)
                        {
                            als.Add(S11);
                            amount+=4;
                        }
                        if (p == 5 && onS3.Key == ConsoleKey.Enter)
                        {
                            als.Add(S12);
                            amount+=6;
                        }

                    } while (onS3.Key != ConsoleKey.Escape);
                }
                else if (pos == 6 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Choose the number of layers for the cake \n");
                    MenuAndSubMenu S13 = new MenuAndSubMenu("\t3 cursts", 6);
                    MenuAndSubMenu S14 = new MenuAndSubMenu("\t4 curts", 7);
                    MenuAndSubMenu S15 = new MenuAndSubMenu("\t6 crusts", 12);
                    MenuAndSubMenu S16 = new MenuAndSubMenu("\t10 crusts", 20);
                    S13.Printf();
                    S14.Printf();
                    S15.Printf();
                    S16.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS4;
                    do
                    {
                        onS4 = Console.ReadKey();
                         if (onS4.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS4.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose the number of layers for the cake \n");
                        S13.Printf();
                        S14.Printf();
                        S15.Printf();
                        S16.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S13);
                            amount+=6;
                        }
                        if (p == 3 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S14);
                            amount+=7;
                        }
                        if (p == 4 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S15);
                            amount+=12;
                        }
                        if (p == 5 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S16);
                            amount+=20;
                        }

                    } while (onS4.Key != ConsoleKey.Escape);
                }
                else if (pos == 7 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Choose cake's glaze \n");
                    MenuAndSubMenu S17 = new MenuAndSubMenu("\tWhite choco glaze", 3);
                    MenuAndSubMenu S18 = new MenuAndSubMenu("\tMilk choco glaze", 3);
                    MenuAndSubMenu S19 = new MenuAndSubMenu("\tColored glaze", 4);
                    MenuAndSubMenu S20 = new MenuAndSubMenu("\tViolet glaze", 6);
                    MenuAndSubMenu S21 = new MenuAndSubMenu("\tBlue glaze", 7);
                    MenuAndSubMenu S22 = new MenuAndSubMenu("\tGold glaze ", 9);
                    S17.Printf();
                    S18.Printf();
                    S19.Printf();
                    S20.Printf();
                    S21.Printf();
                    S22.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS4;
                    do
                    {
                        onS4 = Console.ReadKey();
                         if (onS4.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS4.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose cake's glaze \n");
                        S17.Printf();
                        S18.Printf();
                        S19.Printf();
                        S20.Printf();
                        S21.Printf();
                        S22.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S17);
                            amount+=3;
                        }
                        if (p == 3 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S18);
                            amount+=3;
                        }
                        if (p == 4 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S19);
                            amount+=4;
                        }
                        if (p == 5 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S20);
                            amount+=6;
                        }
                        if (p == 6 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S21);
                            amount+=7;
                        }
                        if (p == 7 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S22);
                            amount+=9;
                        }
                    } while (onS4.Key != ConsoleKey.Escape);
                }
                else if (pos == 8 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Choose cake's decor\n");
                    MenuAndSubMenu S23 = new MenuAndSubMenu("\tMelted choco and and ganache", 3);
                    MenuAndSubMenu S24 = new MenuAndSubMenu("\tFruits", 5);
                    MenuAndSubMenu S25 = new MenuAndSubMenu("\tButtercream", 10);
                    MenuAndSubMenu S26 = new MenuAndSubMenu("\tFlowers", 11);
                    MenuAndSubMenu S27 = new MenuAndSubMenu("\tChocolates", 12);
                    MenuAndSubMenu S28 = new MenuAndSubMenu("\tMarshmallows ", 14);
                    S23.Printf();
                    S24.Printf();
                    S25.Printf();
                    S26.Printf();
                    S27.Printf();
                    S28.Printf();
                    ShowAmount(amount);
                    int p = 2;
                    Console.SetCursorPosition(0,p);
                    Console.WriteLine("->");
                    ConsoleKeyInfo onS4;
                    do
                    {
                        onS4 = Console.ReadKey();
                         if (onS4.Key == ConsoleKey.UpArrow)
                        {
                            p--;
                        }
                        if (onS4.Key == ConsoleKey.DownArrow)
                        {
                            p++;
                        }
                        Console.Clear();
                        Console.WriteLine("Choose cake's decor \n");
                        S23.Printf();
                        S24.Printf();
                        S25.Printf();
                        S26.Printf();
                        S27.Printf();
                        S28.Printf();
                        ShowAmount(amount);
                        Console.SetCursorPosition(0,p);
                        Console.WriteLine("->");
                        if (p == 2 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S23);
                            amount+=3;
                        }
                        if (p == 3 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S24);
                            amount+=5;
                        }
                        if (p == 4 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S25);
                            amount+=10;
                        }
                        if (p == 5 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S26);
                            amount+=11;
                        }
                        if (p == 6 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S27);
                            amount+=12;
                        }
                        if (p == 7 && onS4.Key == ConsoleKey.Enter)
                        {
                            als.Add(S28);
                            amount+=14;
                        }
                    } while (onS4.Key != ConsoleKey.Escape);   
                }
                else if (pos == 9 && keyin_Main.Key == ConsoleKey.Enter)
                {
                    ord_num++;
                    fileSave(als, amount, ord_num);
                    Console.Clear();
                    Console.WriteLine("Thanks for your order! Cake will be delivered to you for 1-2 days! We look forward to seeing you again! :)\n");
                }
            }
        }
    }
    class Main_p
    {
        static void Main()
        {
            MenuAndSubMenu.listing();
        }
    }
}