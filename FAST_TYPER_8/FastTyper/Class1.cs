using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            Console.WriteLine("Таблица участников: \n");
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
            Player pl = new Player();
            bool isCountedToEnd = false;
            Console.Clear();
            int forward = 0;
            int heigth = 0;
            string text = "Написание текстов для главных страниц сайта – дело непростое. Проблема в том, что существует сразу несколько подходов к подготовке таких материалов.\r\n\r\nКаждый подход, как это и водится, имеет свои плюсы и минусы. Где-то можно выиграть в оптимизации, но потерять в живых читателях. Где-то можно приобрести живых читателей, но придется жертвовать SEO-показателями и, возможно, по этой причине отставать от конкурентов.\r\n\r\nПостоянные сомнения, касающиеся оптимальных путей создания текстов для главной, стали вполне привычными спутниками авторов.";

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
                    symbols_per_min++;
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
                if (forward == text.Length)
                {
                    isCountedToEnd = true;
                    start_timer.Abort();
                }
            }
            if (isCountedToEnd)
            {
                Console.WriteLine("Время вышло! Вы допечатали до конца!");
            }
            start_timer.Abort();
            Console.WriteLine("Время вышло!");
            Thread.Sleep(1000);
            Console.Clear();
            List<Player> write = new List<Player>();
            pl.Name = player_name;
            pl.SymsPerSecs = symbols_per_sec;
            pl.SymsPerMins = symbols_per_min / 60;
            write.Add(pl);
            string json_t = JsonConvert.SerializeObject(write);
        }
        private static void Timer()
        {
            int remTime = 4;
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
