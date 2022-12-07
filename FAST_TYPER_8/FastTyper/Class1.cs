using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
namespace FastTyper
{
    public class Player
    {
        public string Name { get; set; }
        public uint SymsPerMins { get; set; }
        public uint SymsPerSecs { get; set; }
    }

    public class Table
    {
        bool FillTable(string name, uint symbols_per_min, uint symbols_per_sec)
        {
            bool already_exists = false;
            Console.WriteLine("Table: \n");
            List<object> records = new List<object>();
            if ((already_exists = records.Contains(name)) == true || (already_exists = records.Contains(symbols_per_min)) == true || (already_exists = records.Contains(symbols_per_sec)) == true)
            {
                return false;
            }
            else
            {
                records.Add(name);
                records.Add(symbols_per_min);
                records.Add(symbols_per_sec);
            }
                foreach (var objetcs in records)
            {
                Console.WriteLine(name+"\t"+symbols_per_min+"\t"+symbols_per_sec);
                
            }
            return true;
        }
    }
    public class Enter
    {
        public static void TextChallenge(string player_name, uint symbols_per_min, uint symbols_per_sec)
        {
            Console.Clear();
            int forward = 0;
            int heigth = 0;
            string text = "Now NASA is working towards logging some of the smaller asteroids, those measuring 140 metres" +
                          "wide or more. Of the 25,000 estimated asteroids of this size, so far about 8,000 have been logged" +
                          "leaving 17,000 unaccounted for. Considering that a 19-metre asteroid that exploded above the city" +
                          "of Chelyabinsk in Russia in 2013 injured 1,200 people, these middle-sized asteroids would be a   " +
                          "serious danger if they enter Earth's orbit.";

            Console.Write(text);
            Thread start_timer = new Thread(Timer);
            start_timer.Start();
            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(forward, heigth);
                ConsoleKeyInfo sym = Console.ReadKey();
                if (sym.KeyChar == text[i])
                {
                    Console.SetCursorPosition(forward, heigth);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sym.KeyChar);
                    forward++;
                    symbols_per_sec++;
                }
                else 
                {
                    Console.SetCursorPosition(forward, heigth);
                    Console.ForegroundColor = ConsoleColor.Red;
                    forward++;
                }
                if (forward == 120)
                {
                    forward = 0;
                    heigth++;
                }
            }
        }
        private static void Timer()
        {
            int remTime = 60;
            Stopwatch st_Watch = new Stopwatch();
            do
            {
                Console.SetCursorPosition(10, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (remTime == 60)
                {
                    st_Watch.Start();
                    Console.WriteLine("1:0");
                    remTime--;
                }
                else
                {
                    Console.WriteLine($"0:{remTime--}");
                    if (remTime < 10)
                    {
                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine($"0:0{remTime--}");
                    }
                    if (remTime == 0)
                        st_Watch.Stop();
                }
                Thread.Sleep(1000);
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("     ");
            } while (remTime != 0);
            Console.SetCursorPosition(10, 10);
            Console.WriteLine($"0:{remTime}");

        }
    }
}
